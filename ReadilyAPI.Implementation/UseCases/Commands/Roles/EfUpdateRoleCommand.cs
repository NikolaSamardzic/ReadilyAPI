using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application.Exceptions;
using ReadilyAPI.Application.UseCases.Commands.Roles;
using ReadilyAPI.Application.UseCases.DTO.Roles;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Domain;
using ReadilyAPI.Implementation.Validators.Role;
using ReadilyAPI.DataAccess.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace ReadilyAPI.Implementation.UseCases.Commands.Roles
{
    public class EfUpdateRoleCommand : EfUpdateUseCase<UpdateRoleDto, Role>, IUpdateRoleCommand
    {
        public EfUpdateRoleCommand(ReadilyContext context, UpdateRoleValidator validator, IMapper mapper) : base(context, mapper, validator)
        {
        }

        private EfUpdateRoleCommand() { }

        public override int Id => 8;

        public override string Name => "Update Role";

        protected override IQueryable<Role> IncludeRelatedEntities(IQueryable<Role> query)
        {
            return query.Include(x => x.RoleUseCases).Where(x => x.IsActive);
        }
    }
}
