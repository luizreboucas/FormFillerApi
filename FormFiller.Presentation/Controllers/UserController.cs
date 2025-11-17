using Microsoft.AspNetCore.Mvc;
using FormFiller.Domain.Entities;
using System.Threading.Tasks;
using FormFiller.Application.UseCases;
using FormFiller.Infrasctructure.Repositories;
using FormFiller.Presentation.DTOs;
using FluentValidation;
using FormFiller.Presentation.Validators;
using FormFiller.Application.UseCases.Models;
using System.Security.Cryptography.X509Certificates;
using FormFiller.Presentation.DTOs.User;

namespace FormFiller.Presentation.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController: ControllerBase
    {
        public UserUseCases userUseCases;
        public UserCreateValidator userCreateValidator;
        public UserUpdateValidator userUpdateValidator;
        public UserController(
            UserUseCases uc, 
            UserCreateValidator _userCreateValidator, 
            UserUpdateValidator _userUpdateValidator
            )
        {
            userUseCases = uc;
            userCreateValidator = _userCreateValidator;
            userUpdateValidator = _userUpdateValidator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            try
            {
                var allUsers = await userUseCases.GetAllUsers();
                return Ok(new ApiResponse(true, "Usuários recuperados com sucesso.", allUsers));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }

        }

        [HttpPost]
        public async Task<ActionResult<UserCreateResponseDTO>> CreateUser(UserCreateDTO userCreateDTO)
        {

            {
                var validation = await userCreateValidator.ValidateAsync(userCreateDTO);
                if (!validation.IsValid) return BadRequest(new ApiResponse(false, "Dados inválidos, verifique o formulário e tente novamente.", validation.Errors.Select(e => e.ErrorMessage)));
                try
                {
                    var newUser = await userUseCases.CreateUserUc(new UserCreateRequest(
                        userCreateDTO.Username,
                        userCreateDTO.Email,
                        userCreateDTO.Password,
                        userCreateDTO.Phone
                    ));
                    return Ok(new ApiResponse(
                        true, 
                        "Usuário criado com sucesso.", 
                        new UserCreateResponseDTO(newUser.Id, newUser.Username, newUser.Email)));
                }
                catch (Exception ex)
                {
                    return Problem(ex.Message);
                }
            }
            }
        [HttpPut("{id}")]
        public async Task<ActionResult<UserUpdateResponseDTO>> UpdateUser(Guid id, UserUpdateRequestDTO userNewData)
        {
            var validation = await userUpdateValidator.ValidateAsync(userNewData);
            if(!validation.IsValid)
            {
                return BadRequest(validation.Errors.Select(e => e.ErrorMessage));
            }
            try
            {
                var updatedUser = await userUseCases.UpdateUser(new UserUpdateRequest(
                    id,
                    userNewData.Username,
                    userNewData.Email,
                    userNewData.Phone
                ));
                var dto = new UserUpdateResponseDTO(
                    updatedUser.Id,
                    updatedUser.Username ?? string.Empty,
                    updatedUser.Email ?? string.Empty,
                    updatedUser.Phone ?? string.Empty
                );

                return Ok(new ApiResponse(true, "Usuário atualizado com sucesso.", dto));
            }
            catch (Exception ex)
        {
                return Problem(ex.Message);
            }
        }
    }
}
