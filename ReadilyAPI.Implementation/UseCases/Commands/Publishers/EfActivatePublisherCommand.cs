using ReadilyAPI.Application.Exceptions;
using ReadilyAPI.Application.UseCases.Commands.Publishers;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Commands.Publishers
{
    public class EfActivatePublisherCommand : EfUseCase, IActivatePublisherCommand
    {
        public EfActivatePublisherCommand(ReadilyContext context) : base(context)
        {
        }

        public int Id => 18;

        public string Name => "Activate Publisher";

        public void Execute(int data)
        {
            var publsiher = Context.Publishers.FirstOrDefault(x => x.Id == data);

            if (publsiher == null)
            {
                throw new EntityNotFoundException(data, nameof(Publisher));
            }

            publsiher.IsActive = true;

            Context.SaveChanges();
        }
    }
}
