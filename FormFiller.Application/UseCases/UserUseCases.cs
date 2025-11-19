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
using FormFiller.Application.UseCases.Models;

namespace FormFiller.Application.UseCases
{
    public class UserUseCases
    {
        private IUserRepository userRepository;
        private IPasswordHasher passwordHasher;
        public UserUseCases(IUserRepository repository, IPasswordHasher passwordHasher)
        {
            userRepository = repository;
            this.passwordHasher = passwordHasher;
        }
        public async Task<UserCreateResponse> CreateUserUc(UserCreateRequest newUser)
        {
            var thisUserIsAlreadyInTheDb = await userRepository.GetByEmail(newUser.Email);
            if (thisUserIsAlreadyInTheDb != null) throw new AlreadyInTheDatabase("Já existe um usuário cadastrado com esse email.");
            var user = new User
            {
                Username = newUser.Username,
                Email = newUser.Email,
                PasswordHash = newUser.Password,
                Phone = newUser.Phone
            };
            var passwordHash = passwordHasher.HashPassword(user, user.PasswordHash);
            user.PasswordHash = passwordHash;
            var createdUser = await userRepository.Create(user);
            return new UserCreateResponse(createdUser.Id, createdUser.Username, createdUser.Email);
        }

        public async Task<UserUpdateResponse> UpdateUser(UserUpdateRequest userNewData)
        {
            var user = await userRepository.GetById(userNewData.UserId)
                ?? throw new NotFoundInTheDatabaseExeption("Registro não encontrado");
            user.Username = userNewData.Username ?? user.Username;
            user.Email = userNewData.Email ?? user.Email;
            user.Phone = userNewData.Phone ?? user.Phone;
            var updatedUser = await userRepository.Update(user);
            return new UserUpdateResponse(
                updatedUser.Id,
                updatedUser.Username,
                updatedUser.Email,
                updatedUser.Phone
                );
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

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await userRepository.GetByEmail(email);
            if (user == null) throw new NotFoundInTheDatabaseExeption("Registro não encontrado");
            return user;
        }

    }
}
