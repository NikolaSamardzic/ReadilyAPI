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
    public class EfActivatePublisherCommand : EfActivateUseCase<Publisher>, IActivatePublisherCommand
    {
        public EfActivatePublisherCommand(ReadilyContext context) : base(context)
        {
        }

        private EfActivatePublisherCommand() { }

        public override int Id => 18;

        public override string Name => "Activate Publisher";
    }
}
