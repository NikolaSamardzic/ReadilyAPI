using ReadilyAPI.Application;
using ReadilyAPI.Application.Exceptions;
using ReadilyAPI.Application.UseCases.Commands.Comments;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Commands.Comments
{
    public class EfDeleteCommentCommand : EfDeleteUseCase<Comment>, IDeleteCommentCommand
    {
        private readonly IApplicationActor _actor;

        public EfDeleteCommentCommand(ReadilyContext context, IApplicationActor actor) : base(context)
        {
            _actor = actor;
        }

        private EfDeleteCommentCommand() { }

        public override int Id => 55;

        public override string Name => "Delete Comment";

        protected override void BeforeDelete(Comment entity)
        {
            if (entity.UserId != _actor.Id)
            {
                throw new ConflictException("Comment is not created by this user");
            }
        }
    }
}
