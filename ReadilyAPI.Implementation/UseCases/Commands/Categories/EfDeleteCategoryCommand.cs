using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application.Exceptions;
using ReadilyAPI.Application.UseCases.Commands.Categories;
using ReadilyAPI.Application.UseCases.DTO.Category;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Commands.Categories
{
    public class EfDeleteCategoryCommand : EfDeleteUseCase<Category>, IDeleteCategoryCommand
    {
        public EfDeleteCategoryCommand(ReadilyContext context) : base(context)
        {
        }

        private EfDeleteCategoryCommand() { }

        public override int Id => 2;

        public override string Name => "Delete Category";

        protected override IQueryable<Category> IncludeRelatedEntities(IQueryable<Category> query)
        {
            return query
                .Include(x => x.Children);
        }

        protected override void BeforeDelete(Category entity)
        {
            foreach (var item in entity.Children)
            {
                item.IsActive = false;
            }
        }
    }
}
