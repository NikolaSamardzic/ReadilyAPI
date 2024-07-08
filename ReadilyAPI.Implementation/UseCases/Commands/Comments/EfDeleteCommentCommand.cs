using ReadilyAPI.Application;
using ReadilyAPI.Application.Exceptions;
using ReadilyAPI.Application.UseCases.Commands.Comments;
using ReadilyAPI.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Commands.Comments
{
    public class EfDeleteCommentCommand : EfUseCase, IDeleteCommentCommand
    {
        private readonly IApplicationActor _actor;

        public EfDeleteCommentCommand(ReadilyContext context, IApplicationActor actor) : base(context)
        {
            _actor = actor;
        }

        public int Id => 55;

        public string Name => "Delete Comment";

        public void Execute(int data)
        {
            var comment = Context.Comments.FirstOrDefault(x => x.Id == data && x.IsActive);

            if(comment == null) 
            {
                throw new EntityNotFoundException(data,nameof(Domain.Comment));
            }

            if(comment.UserId != _actor.Id)
            {
                throw new ConflictException("Comment is not created by this user");
            }

            comment.IsActive = false;

            Context.SaveChanges();
        }
    }
}
