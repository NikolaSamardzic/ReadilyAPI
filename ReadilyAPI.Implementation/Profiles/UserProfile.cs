using AutoMapper;
using ReadilyAPI.Application.UseCases.DTO.Address;
using ReadilyAPI.Application.UseCases.DTO.Biography;
using ReadilyAPI.Application.UseCases.DTO.User;
using ReadilyAPI.Domain;
using ReadilyAPI.Implementation.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ReadilyAPI.Implementation.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<CreateAddressDto, Address>();

            CreateMap<CreateBiographyDto, Biography>();

            //CreateMap<Address, AddressDto>();

            CreateMap<Biography, BiographyDto>();

            CreateMap<CreateUserDto, User>()
                .ForMember(d => d.Avatar, s => s.MapFrom(x => new Image 
                {
                    Src = x.Avatar,
                    Alt = "User avatar",
                }))
                .ForMember(d => d.Password, s => s.MapFrom(x => BCrypt.Net.BCrypt.HashPassword(x.Password)))
                .ForMember(d => d.Token, s => s.MapFrom(x => TokenGenerator.GenerateRandomToken(30)));

            CreateMap<UpdateAddressDto, Address>();

            CreateMap<UpdateBiographyDto, Biography>();

            CreateMap<UpdateUserDto, User>()
                .ForMember(d => d.Avatar, s => s.MapFrom(x => new Image
                {
                    Src = x.Avatar,
                    Alt = "User avatar",
                }));

            CreateMap<CreateUserFavoriteCategoriesDto, IEnumerable<UserCategory>>()
                .ConvertUsing(dto => dto.CategoryIds
                    .Select(x => new UserCategory
                    {
                        UserId = dto.UserId,
                        CategoryId = x
                    })
                );

            CreateMap<CreateUserUseCaseDto, IEnumerable<Domain.UserUseCase>>()
                .ConvertUsing(dto => dto.UserUseCases.Select(x => new Domain.UserUseCase 
                { 
                    Status = x.Status, 
                    UseCaseId = x.UseCaseId,
                    UserId = dto.UserId
                }));

            CreateMap<User, UserDto>()
                .ForMember(d => d.Avatar, s => s.MapFrom(x => x.Avatar.Src))
                .ForMember(d => d.Address, s => s.MapFrom(x => new AddressDto
                {
                    Id = x.Address.Id,
                    AddressName = x.Address.AddressName,
                    AddressNumber = x.Address.AddressNumber,
                    City = x.Address.City,
                    State = x.Address.State,
                    PostalCode = x.Address.PostalCode,
                    Country = x.Address.Country,
                }))
                .ForMember(d => d.Address, opt => opt.NullSubstitute(new AddressDto
                {
                    Id = 0,
                    AddressName = "/",
                    AddressNumber = "/",
                    City = "/",
                    State = "/",
                    PostalCode = "/",
                    Country = "/",
                }));
        }
    }
}
