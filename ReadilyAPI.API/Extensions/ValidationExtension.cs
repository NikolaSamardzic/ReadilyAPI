using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using ReadilyAPI.API.DTO.Error;

namespace ReadilyAPI.API.Extensions
{
    public static class ValidationExtension
    {
        public static UnprocessableEntityObjectResult ToUnprocessableEntity(this ValidationResult result)
        {
            var errors = result.Errors.Select(x=> new ValidationError
            {
                Property = x.PropertyName,
                Error = x.ErrorMessage,
            });

            return new UnprocessableEntityObjectResult(errors);
        }
    }
}
