﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application.Exceptions;
using ReadilyAPI.Application.UseCases.DTO.Category;
using ReadilyAPI.Application.UseCases.Queries;
using ReadilyAPI.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Queries
{
    public class EfFindCategoryQuery : EfUseCase, IFindCategoryQuery
    {
        private readonly IMapper _mapper;

        public EfFindCategoryQuery(ReadilyContext context, IMapper mapper) : base(context)
        {
            this._mapper = mapper;
        }

        private EfFindCategoryQuery() { }

        public int Id => 5;

        public string Name => "Find Category";

        public CategoryDto Execute(int id)
        {
            var category = Context.Categories
                                    .Include(x => x.Parent)
                                    .Include(x => x.Children)
                                    .Include(x => x.Image)
                                    .FirstOrDefault(x=>x.Id == id && x.IsActive);

            if(category == null)
            {
                throw new EntityNotFoundException(id,nameof(Domain.Category));
            }

            return _mapper.Map<CategoryDto>(category);
        }
    }
}
