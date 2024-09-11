using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application.Exceptions;
using ReadilyAPI.Application.UseCases.Commands.Categories;
using ReadilyAPI.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ReadilyAPI.Implementation.UseCases.Commands.Categories
{
    public class EfActivateCategoryCommand : EfUseCase, IActivateCategoryCommand
    {
        private readonly ReadilyContext _context;

        public EfActivateCategoryCommand(ReadilyContext context) : base(context)
        {
            _context = context;
        }

        private EfActivateCategoryCommand() { }

        public int Id => 4;

        public string Name => "Activate Category";

        public void Execute(int id)
        {
            var category = _context.Categories.Include(x => x.Parent)
            .FirstOrDefault(x => x.Id == id);

            if (category == null)
            {
                throw new EntityNotFoundException(id, nameof(Domain.Category));
            }

            if (category.Parent != null && !category.Parent.IsActive)
            {
                throw new EntityReferencesDeletedEntityException(id,nameof(Domain.Category));
            }

            category.IsActive = true;

            Context.SaveChanges();
        }
    }
}
