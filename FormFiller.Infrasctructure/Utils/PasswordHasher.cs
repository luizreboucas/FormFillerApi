using System;
using FormFiller.Domain.Entities;
using FormFiller.Domain.Interfaces;
using Microsoft.EntityFrameworkCore.

namespace FormFiller.Infrasctructure.Utils;

public class PasswordHasherImpl : IPasswordHasher
{
    public PasswordHasher passwordHasher;

    public PasswordHasherImpl()
    public string HashPassword(User user, string password)
    {
        throw new NotImplementedException();
    }

    public bool VerifyHashedPassword(User user, string hashedPassword, string providedPassword)
    {
        throw new NotImplementedException();
    }
}
