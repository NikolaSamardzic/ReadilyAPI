using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application.Exceptions;
using ReadilyAPI.Application.UseCases.Commands.Categories;
using ReadilyAPI.Application.UseCases.DTO.Category;
using ReadilyAPI.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Commands.Categories
{
    public class EfDeleteCategoryCommand : EfUseCase, IDeleteCategoryCommand
    {
        public EfDeleteCategoryCommand(ReadilyContext context) : base(context)
        {
        }

        public int Id => 2;

        public string Name => "Delete Category";

        public void Execute(int data)
        {
            var category = Context.Categories
                                .Include(x=>x.Children)
                                .FirstOrDefault(x=> x.Id == data && x.IsActive);

            if(category == null) {
                throw new EntityNotFoundException(data,nameof(Domain.Category));
            }

            foreach (var item in category.Children)
            {
                item.IsActive = false;
            }

            category.IsActive = false;

            Context.SaveChanges();
        }
    }
}
