using FluentValidation;
using ReadilyAPI.Application.Exceptions;
using ReadilyAPI.Application.Logging;

namespace ReadilyAPI.API.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IErrorLogger _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, IErrorLogger logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            } catch (ValidationException ex)
            {
                context.Response.StatusCode = 422;

                var errors = ex.Errors.Select(x => new
                {
                    Message = x.ErrorMessage,
                    Property =  x.PropertyName
                });

                await context.Response.WriteAsJsonAsync(errors);
            }
            catch (UnauthorizedException ex) {
                context.Response.StatusCode = 401;
            }
            catch (EntityReferencedException ex)
            {
                context.Response.StatusCode = 409;
                await context.Response.WriteAsJsonAsync(new { 
                    message = ex.Message
                });
            }
            catch (EntityReferencesDeletedEntityException ex)
            {
                context.Response.StatusCode = 409;
                await context.Response.WriteAsJsonAsync(new
                {
                    message = ex.Message
                });
            }
            catch (UnauthorizedAccessException ex)
            {
                context.Response.StatusCode = 401;
            }catch(EntityNotFoundException ex)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsJsonAsync(new
                {
                    message = ex.Message,
                });
            }
            catch (ChildEntityReferencedException ex)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsJsonAsync(new
                {
                    message = ex.Message,
                });
            }
            catch(Exception ex)
            {
                Guid errorId = Guid.NewGuid();
                AppError error = new AppError
                {
                    Exception = ex,
                    Id = errorId,
                };

                _logger.Log(error);

                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";
                var responseBody = new
                {
                    message = $"There was an error, please contact support with this error code: {errorId}"
                };

                await context.Response.WriteAsJsonAsync(responseBody);
            }
        }
    }
}
