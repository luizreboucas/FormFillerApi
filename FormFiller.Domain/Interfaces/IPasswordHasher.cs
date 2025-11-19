using System;
using FormFiller.Domain.Entities;

namespace FormFiller.Domain.Interfaces;

public interface IPasswordHasher
{
    public string HashPassword(User user, string password);
    public bool VerifyHashedPassword(User user, string hashedPassword, string providedPassword);
}
