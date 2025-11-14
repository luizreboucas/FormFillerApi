using FormFiller.Domain.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormFiller.Domain.Entities;
using FormFiller.Domain.Interfaces;
using FormFiller.Application.Exceptions;
using FluentValidation;

namespace FormFiller.Application.UseCases
{
    public class UserUseCases
    {
        private IUserRepository userRepository;
        public UserUseCases(IUserRepository repository)
        {
            userRepository = repository;
        }
        public async Task<User> CreateUserUc(User user, AbstractValidator<User> validator)
        {
            var thisUserIsAlreadyInTheDb = await userRepository.GetByEmail(user.Email);
            if(thisUserIsAlreadyInTheDb != null) throw new AlreadyInTheDatabase("Já existe um usuário cadastrado com esse email.");
            var userData = await validator.ValidateAsync(user);
            if (!userData.IsValid) throw new ValidationException(userData.Errors);
            var createdUser = await userRepository.Create(user);
            return createdUser;
        }

        public async Task<User> UpdateUser(User user, AbstractValidator<User> validator)
        {
            var userData = await validator.ValidateAsync(user);
            if (!userData.IsValid) throw new ArgumentException("Dados inválidos, verifique o formulário e tente novamente.");
            var updatedUser = await userRepository.Update(user);
            return updatedUser;
        }

        public async void DeleteUser(Guid id)
        {
            var userExistsInDb = await userRepository.GetById(id);
            if (userExistsInDb == null) throw new NotFoundInTheDatabaseExeption("Registro não encontrado");
            userRepository.Delete(id);
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await userRepository.GetAll();
        }

        public async Task<User> GetUserById(Guid id)
        {
            var user = await userRepository.GetById(id);
            if (user == null) throw new NotFoundInTheDatabaseExeption("Registro não encontrado");
            return user;
        }

    }
}
