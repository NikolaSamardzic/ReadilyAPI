using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NuGet.Configuration;
using ReadilyAPI.API.DTO.Configuration;
using ReadilyAPI.API.ExceptionLoggers;
using ReadilyAPI.API.Jwt;
using ReadilyAPI.Application;
using ReadilyAPI.Application.Logging;
using ReadilyAPI.Application.UseCaseHandling.Command;
using ReadilyAPI.Application.UseCaseHandling.Query;
using ReadilyAPI.Application.UseCases.Commands.Categories;
using ReadilyAPI.Application.UseCases.Commands.DeliveryTypes;
using ReadilyAPI.Application.UseCases.Commands.OrderStatuses;
using ReadilyAPI.Application.UseCases.Commands.Publishers;
using ReadilyAPI.Application.UseCases.Commands.Roles;
using ReadilyAPI.Application.UseCases.Queries;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Implementation;
using ReadilyAPI.Implementation.UseCases.Commands.Categories;
using ReadilyAPI.Implementation.UseCases.Commands.DeliveryTypes;
using ReadilyAPI.Implementation.UseCases.Commands.OrderStatueses;
using ReadilyAPI.Implementation.UseCases.Commands.Publishers;
using ReadilyAPI.Implementation.UseCases.Commands.Roles;
using ReadilyAPI.Implementation.UseCases.Queries;
using ReadilyAPI.Implementation.Validators.Category;
using ReadilyAPI.Implementation.Validators.DeliveryType;
using ReadilyAPI.Implementation.Validators.OrderStatus;
using ReadilyAPI.Implementation.Validators.Publisher;
using ReadilyAPI.Implementation.Validators.Role;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace ReadilyAPI.API.Extensions
{
    public static class ContainerExtensions
    {
        public static void AddLogger(this IServiceCollection services)
        {
            services.AddTransient<IErrorLogger>(x =>
            {
                var accessor = x.GetService<IHttpContextAccessor>();
                var context = x.GetService<ReadilyContext>();

                if(accessor == null || accessor.HttpContext == null)
                {
                    return new ConsoleErrorLogger();
                }

                var logger = accessor.HttpContext.Request.Headers["Logger"].FirstOrDefault();

                if(logger == "Console")
                {
                    return new ConsoleErrorLogger();
                }else if(logger == "DataBase")
                {
                    return new DbErrorLogger(context);
                }

                return new DbErrorLogger(context);
            });
        }

        public static void AddValidators(this IServiceCollection services)
        {
            services.AddTransient<CreateCategoryValidator>();
            services.AddTransient<UpdateCategoryValidator>();
            services.AddTransient<CreateRoleValidator>();
            services.AddTransient<UpdateRoleValidator>();
            services.AddTransient<CreatePublisherValidator>();
            services.AddTransient<UpdatePublisherValidator>();
            services.AddTransient<CreateOrderStatusValidator>();
            services.AddTransient<UpdateOrderStatusValidatior>();
            services.AddTransient<CreateDeliveryTypeValidator>();
            services.AddTransient<UpdateDeliveryTypeValidator>();
        }

        public static void AddJwt(this IServiceCollection services, AppSettings settings)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = settings.Jwt.Issuer,
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.Jwt.SecretKey)),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };

                cfg.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {

                        var header = context.Request.Headers["Authorization"];

                        var token = header.ToString().Split("Bearer ")[1];

                        var handler = new JwtSecurityTokenHandler();

                        var tokenObj = handler.ReadJwtToken(token);

                        string jti = tokenObj.Claims.FirstOrDefault(x => x.Type == "jti").Value;



                        ITokenStorage storage = context.HttpContext.RequestServices.GetService<ITokenStorage>();

                        bool isValid = storage.TokenExists(jti);

                        if (!isValid)
                        {
                            context.Fail("Token is not valid.");
                        }

                        return Task.CompletedTask;
                    }
                };
            });
        }

        public static void AddCommandHandler(this IServiceCollection services)
        {
            services.AddTransient<ICommandHandler>(x => {

                var actor = x.GetService<IApplicationActor>();
                var logger = x.GetService<IUseCaseLogger>();
                var commandHandler = new CommandHandler();
                var timeTrackingHandler = new TimeTrackingCommandHandler(commandHandler);
                var loggingHandler = new LoggingCommandHandler(timeTrackingHandler, actor, logger);
                var decoration = new AuthorizationCommandHandler(actor, loggingHandler);

                return decoration;
            });
        }

        public static void AddQueryHandler(this IServiceCollection services)
        {
            services.AddTransient<IQueryHandler>(x => {

                var actor = x.GetService<IApplicationActor>();
                var logger = x.GetService<IUseCaseLogger>();
                var queryHandler = new QueryHandler();
                var timeTrackingHandler = new TimeTrackingQueryHandler(queryHandler);
                var loggingHandler = new LoggingQueryHandler(timeTrackingHandler, actor, logger);
                var decoration = new AuthorizationQueryHandler(actor, loggingHandler);

                return decoration;
            });
        }

        public static void AddActorProvider(this IServiceCollection services)
        {
            services.AddScoped<IApplicationActorProvider>(x => {
                var accessor = x.GetService<IHttpContextAccessor>();

                var request = accessor.HttpContext.Request;

                var authHeader = request.Headers.Authorization.ToString();

                return new JwtAuthorizationApplicationActorProvider(authHeader);
            });

            services.AddScoped<IApplicationActor>(x =>
            {
                return x.GetService<IApplicationActorProvider>().GetActor();
            });
        }

        public static void AddCommands(this IServiceCollection services)
        {
            services.AddTransient<ICreateCategoryCommand, EfCreateCategoryCommand>();
            services.AddTransient<IDeleteCategoryCommand, EfDeleteCategoryCommand>();
            services.AddTransient<IUpdateCategoryCommand, EfUpdateCategoryCommand>();
            services.AddTransient<IActivateCategoryCommand, EfActivateCategoryCommand>();
            services.AddTransient<ICreateRoleCommand, EfCreateRoleCommand>();
            services.AddTransient<IUpdateRoleCommand, EfUpdateRoleCommand>();
            services.AddTransient<IDeleteRoleCommand, EfDeleteRoleCommand>();
            services.AddTransient<IActivateRoleCommand, EfActivateRoleCommand>();
            services.AddTransient<ICreatePublisherCommand, EfCreatePublisherCommand>();
            services.AddTransient<IUpdatePublisherCommand, EfUpdatePublisherCommand>();
            services.AddTransient<IDeletePublisherCommand, EfDeletePublisherCommand>();
            services.AddTransient<IActivatePublisherCommand, EfActivatePublisherCommand>();
            services.AddTransient<ICreateOrderStatusCommand,EfCreateOrderStatusesCommand>();
            services.AddTransient<IUpdateOrderStatusCommand, EfUpdateOrderStatusesCommand>();
            services.AddTransient<IDeleteOrderStatusCommand, EfDeleteOrderStatusCommand>();
            services.AddTransient<ICreateDeliveryTypeCommand, EfCreateDeliveryTypesCommand>();
            services.AddTransient<IActivateOrderStatusCommand, EfActivateOrderStatuesCommand>();
            services.AddTransient<IUpdateDeliveryTypeCommand, EfUpdateDeliveryTypeCommand>();
            services.AddTransient<IDeleteDeliveryTypeCommand, EfDeleteDeliveryTypeCommand>();
            services.AddTransient<IActivateDeliveryTypeCommand, EfActivateDeliveryTypeCommand>();
        }

        public static void AddQueries(this IServiceCollection services)
        {
            services.AddTransient<IFindCategoryQuery, EfFindCategoryQuery>();
            services.AddTransient<IGetCategoriesQuery, EfGetCategoriesQuery>();
            services.AddTransient<IFindRoleQuery, EfFindRoleQuery>();
            services.AddTransient<IGetRolesQuery, EfGetRolesQuery>();
            services.AddTransient<IFindPublisherQuery, EfFindPublisherQuery>();
            services.AddTransient<IGetPublishersQuery, EfGetPublishersQuery>();
            services.AddTransient<IFindOrderStatusQuery, EfFindOrderStatusQuery>();
            services.AddTransient<IGetOrderStatusQuery, EfGetOrderStatusesQuery>();
            services.AddTransient<IFindDeliveryTypeQuery, EfFindDeliveryTypeQuery>();
            services.AddTransient<IGetDeliveryTypesQuery,EfGetDeliveryTypeQuery>();
        }
    }
}
