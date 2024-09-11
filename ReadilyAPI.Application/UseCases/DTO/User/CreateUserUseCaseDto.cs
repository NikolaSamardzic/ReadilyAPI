using System;
using System.Collections.Generic;
using System.Text;

namespace ReadilyAPI.Application.UseCases.DTO.User
{
    public class CreateUserUseCaseDto
    {
        public int UserId { get; set; }
        public IEnumerable<UserUseCase> UserUseCases { get; set; }
    }

    public class UserUseCase 
    { 
        public int UseCaseId { get; set; }
        public bool Status { get; set; }
    }

}
