using AutoMapper;
using ReadilyAPI.Application.UseCases.DTO.Roles;
using ReadilyAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.Profiles
{
    class RoleProfile : Profile
    {
        public RoleProfile() 
        {
            CreateMap<CreateRoleDto, Role>()
                .ForMember(d => d.RoleUseCases, s => s.MapFrom(x => x.RoleUseCases.Select(x => new RoleUseCase { 
                    UseCaseId = x
                })));

            CreateMap<UpdateRoleDto, Role>()
                .ForMember(d => d.RoleUseCases, s => s.MapFrom(x => x.RoleUseCases.Select(x => new RoleUseCase
                {
                    UseCaseId = x
                })));

            CreateMap<Role, RoleDto>()
                .ForMember(d => d.RoleUseCases, s => s.MapFrom(x => x.RoleUseCases.Select(x => x.UseCaseId)));
        }
    }
}
