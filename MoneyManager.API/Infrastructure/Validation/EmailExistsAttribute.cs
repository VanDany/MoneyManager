using ModelsAPI.Client.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.API.Infrastructure.Validation
{
    public class EmailExistsAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            IAuthRepository authRepository = (IAuthRepository)validationContext.GetService(typeof(IAuthRepository));

            string email = value as string;

            if (!string.IsNullOrWhiteSpace(email))
            {
                if (authRepository.EmailExists(email))
                {
                    return new ValidationResult("e-mail already exists in database");
                }
            }
            else
            {
                return new ValidationResult($"Invalid value in the field : {validationContext.MemberName}");
            }

            return ValidationResult.Success;
        }
    }
}
