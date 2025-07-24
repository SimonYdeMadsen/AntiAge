using AntiAge.Data.Identity;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

public class CustomPasswordValidator<TUser> : IPasswordValidator<TUser> where TUser : class
{
    
    public Task<IdentityResult> ValidateAsync(UserManager<TUser> manager, TUser user, string? password)
    {

        var errors = new List<IdentityError>();
        var options = manager.Options.Password;

        if (password == null)
        {
            throw new ArgumentNullException(nameof(password));
        }

        if (password.Length < options.RequiredLength)
        {
            errors.Add(new IdentityError
            {
                Code = "PasswordTooShort",
                Description = $"Passwords must be at least {options.RequiredLength} characters."
            });
        }

        if (options.RequireNonAlphanumeric && password.All(char.IsLetterOrDigit))
        {
            errors.Add(new IdentityError
            {
                Code = "PasswordRequiresNonAlphanumeric",
                Description = "Passwords must have at least one non alphanumeric character."
            });
        }

        if (options.RequireDigit && !password.Any(char.IsDigit))
        {
            errors.Add(new IdentityError
            {
                Code = "PasswordRequiresDigit",
                Description = "Passwords must have at least one digit ('0'-'9')."
            });
        }

        if (options.RequireLowercase && !password.Any(char.IsLower))
        {
            errors.Add(new IdentityError
            {
                Code = "PasswordRequiresLower",
                Description = "Passwords must have at least one lowercase letter ('a'-'z')."
            });
        }

        if (options.RequireUppercase && !password.Any(char.IsUpper))
        {
            errors.Add(new IdentityError
            {
                Code = "PasswordRequiresUpper",
                Description = "Passwords must have at least one uppercase letter ('A'-'Z')."
            });
        }

        if (options.RequiredUniqueChars > 1 &&
            password.Distinct().Count() < options.RequiredUniqueChars)
        {
            errors.Add(new IdentityError
            {
                Code = "PasswordRequiresUniqueChars",
                Description = $"Passwords must use at least {options.RequiredUniqueChars} different characters."
            });
        }

        return Task.FromResult(errors.Count == 0
            ? IdentityResult.Success
            : IdentityResult.Failed(errors.ToArray()));
    }

    
}