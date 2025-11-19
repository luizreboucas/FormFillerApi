using FormFiller.Application.UseCases;
using FormFiller.Presentation.DTOs.Param;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using FormFiller.Application.UseCases;
using FormFiller.Application.UseCases.Models;
using FormFiller.Presentation.Validators;

namespace FormFiller.Presentation.Controllers
{
    [ApiController]
    [Route("param")]
    public class ParamController: ControllerBase
    {
        public ParamUseCases paramUseCase;
        public ParamCreateValidator validator;
        public ParamController(ParamUseCases _p, ParamCreateValidator _validator)
        {
            this.paramUseCase = _p;
            this.validator = _validator;
        }

        [HttpPost]
        public async Task<ActionResult<ParamCreateDTO>> Create(ParamCreateDTO request)
        {
            try
            {
                var validation = await validator.ValidateAsync(request);
                if (!validation.IsValid)
                {
                    return BadRequest(validation.Errors);
                }
                var param = await paramUseCase.CreateParam(new CreateParamRequest(request.GeneratorId, request.Value));
                if (param == null)
                {
                    return Problem("Parâmetro não pôde ser criado");
                }
                return Ok(param);
            }
            catch (Exception ex)
            {
                return Problem("Ocorreu um erro ao criar o parâmetro: " + ex.Message);
            }
        }
    }
}
