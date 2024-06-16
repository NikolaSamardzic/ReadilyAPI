using ReadilyAPI.Application.UseCases.DTO.Address;
using ReadilyAPI.Application.UseCases.DTO.Biography;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadilyAPI.Application.UseCases.DTO.User
{
    public class UpdateUserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Avatar { get; set; }
        public UpdateAddressDto Address { get; set; }
        public UpdateBiographyDto Biography { get; set; }
    }
}
