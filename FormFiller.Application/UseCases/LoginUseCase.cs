using FormFiller.Application.Exceptions;
using FormFiller.Application.UseCases.Models;
using FormFiller.Domain.Entities;
using FormFiller.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormFiller.Application.UseCases
{
    public class LoginUseCase
    {
        public IPasswordHasher passwordHasher;
        public IUserRepository userRepository;

        public LoginUseCase(IPasswordHasher passwordHasher, IUserRepository userRepository)
        {
            this.passwordHasher = passwordHasher;
            this.userRepository = userRepository;
        }

        public async Task<User> LoginExec(LoginRequest LoginData)
        {
            var user = await userRepository.GetByEmail(LoginData.Email);
            if(user == null)
            {
                throw new NotFoundInTheDatabaseExeption("Credenciais incorretas");
            }
            var result = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, LoginData.Password);
            if(!result)
            {
                throw new Exception("Credenciais incorretas");
            }
            return user;
        }
    }
}
