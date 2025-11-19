using System;
using System.Threading.Tasks;
using FormFiller.Domain.Entities;
using FormFiller.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace FormFiller.Infrasctructure.Utils;

public class PasswordHasherImpl: IPasswordHasher
{
    public PasswordHasher<User> PasswordHasher { get; set; }

    public PasswordHasherImpl(PasswordHasher<User> _passwordHasher)
    {
        this.PasswordHasher = _passwordHasher;
    }

    public  string HashPassword(User user, string password)
    {
        var result = PasswordHasher.HashPassword(user, password);
        return result;
    }

    public bool VerifyHashedPassword(User user, string hashedPassword, string providedPassword)
    {
        var result = PasswordHasher.VerifyHashedPassword(user, hashedPassword, providedPassword);
        return result == PasswordVerificationResult.Success;
    }
}
