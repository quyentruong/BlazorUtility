using System.ComponentModel.DataAnnotations;

namespace Attributes;

public sealed class DuckEmailValidationAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value is string emailAddress)
        {
            // Perform the existing validation check
            var emailValidator = new EmailAddressAttribute();
            if (!emailValidator.IsValid(emailAddress))
            {
                return false;
            }

            // Perform the additional validation check
            if (!emailAddress.Contains("@duck.com"))
            {
                return false;
            }
        }

        return true;
    }
}