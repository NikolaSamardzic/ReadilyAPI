using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application.UseCases.DTO.Address;
using ReadilyAPI.Application.UseCases.DTO.Biography;
using ReadilyAPI.Application.UseCases.DTO.User;
using ReadilyAPI.Application.UseCases.Queries;
using ReadilyAPI.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Queries
{
    public class EfUserProfileQuery : EfUseCase, IUserProfileQuery
    {
        public EfUserProfileQuery(ReadilyContext context) : base(context)
        {
        }

        private EfUserProfileQuery() { }

        public int Id => 38;

        public string Name => "Find User Profile";

        public UserDto Execute(int search)
        {
            var user = Context.Users
                .Include(x => x.Role)
                .Include(x => x.Address)
                .Include(x => x.Biography)
                .Include(x => x.Avatar)
                .First(x => x.Id == search);

            var result = new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                Email = user.Email,
                Phone = user.Phone,
                Role = user.Role.Name,
                Avatar = user.Avatar.Src,
                Biography = new BiographyDto
                {
                    Text = "/"
                },
                Address = new AddressDto
                {
                    AddressName = "/",
                    AddressNumber = "/",
                    City = "/",
                    Country = "/",
                    State = "/",
                    PostalCode = "/",
                }
            };

            if (user.Biography != null)
            {
                result.Biography.Text = user.Biography.Text;
            }

            if (user.Address != null)
            {
                result.Address.AddressNumber = user.Address.AddressNumber;
                result.Address.AddressName = user.Address.AddressName;
                result.Address.City = user.Address.City;
                result.Address.State = user.Address.State;
                result.Address.Country = user.Address.Country;
                result.Address.PostalCode = user.Address.PostalCode;
            }

            return result;
        }
    }
}
