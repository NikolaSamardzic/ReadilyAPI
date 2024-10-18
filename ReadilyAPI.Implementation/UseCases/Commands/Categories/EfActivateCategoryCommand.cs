using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application.Exceptions;
using ReadilyAPI.Application.UseCases.Commands.Categories;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ReadilyAPI.Implementation.UseCases.Commands.Categories
{
    public class EfActivateCategoryCommand : EfActivateUseCase<Category>, IActivateCategoryCommand
    {
        public EfActivateCategoryCommand(ReadilyContext context) : base(context) { }

        private EfActivateCategoryCommand() { }

        public override int Id => 4;

        public override string Name => "Activate Category";

        protected override IQueryable<Category> IncludeRelatedEntities(IQueryable<Category> query)
        {
            return query.Include(x => x.Parent);
        }

        protected override void BeforeActivate(Category entity)
        {
            if (entity.Parent != null && !entity.Parent.IsActive)
            {
                throw new EntityReferencesDeletedEntityException(entity.Id, nameof(Domain.Category));
            }
        }
    }
}
