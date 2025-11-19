using System;
using System.Threading.Tasks;
using FormFiller.Application.UseCases;
using FormFiller.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FormFiller.Presentation.Controllers;

[ApiController]
[Route("generators")]
public class GeneratorController : ControllerBase
{
    public GeneratorUseCases generatorUseCases;
    public GeneratorController(GeneratorUseCases generatorUseCases)
    {
        this.generatorUseCases = generatorUseCases;
    }
    [HttpPost]
    public ActionResult<List<Generator>> GetGeneratorsByIdList(List<Guid> GeneratorsIds)
    {
        try
        {
            if (GeneratorsIds == null || GeneratorsIds.Count == 0)
            {
                return BadRequest("Lista de IDs de geradores não pode ser nula ou vazia");
            }
            var generators = generatorUseCases.GetAllByIdList(GeneratorsIds);
            if (generators == null)
            {
                return NotFound("Nenhum gerador encontrado para os IDs fornecidos");
            }
            return Ok(generators);
        }
        catch(Exception ex)
        {
            return Problem(ex.Message);
        }
    }
    [HttpGet]
    public async Task<ActionResult<List<Generator>>> GetAll()
    {
        var generators = await generatorUseCases.GetAll();
        if(generators == null)
        {
            return NotFound("Nenhum gerador encontrado");
        }
        return Ok(generators);
    }
    
}
