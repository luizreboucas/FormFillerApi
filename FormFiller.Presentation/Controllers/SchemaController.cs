using System;
using FormFiller.Application.UseCases;
using FormFiller.Domain.Entities;
using FormFiller.Presentation.DTOs.Schema;
using FormFiller.Presentation.Validators;
using Microsoft.AspNetCore.Mvc;
using FormFiller.Application.UseCases.Models;

namespace FormFiller.Presentation.Controllers;

[ApiController]
[Route("schemas")]
public class SchemaController : ControllerBase
{
    public SchemaUseCases schemaUseCases;
    public SchemaCreateValidator validator;

    public SchemaController(SchemaUseCases schemaUseCases, SchemaCreateValidator _validator)
    {
        this.schemaUseCases = schemaUseCases;
        this.validator = _validator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateSchema(SchemaCreateDTO schema)
    {
        try
        {
            var validation = await validator.ValidateAsync(schema);
            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors);
            }
            var result = await schemaUseCases.Create(new SchemaCreateRequest(schema.Name, schema.GeneratorsIds, schema.UserId));
            if (result == null)
            {
                return Problem("Schema não pôde ser criado");
            }
            return Ok(result);
        }
        catch (Exception ex)
        {
            return Problem("Ocorreu um erro ao criar o schema" + ex.Message);
        }
    }
    [HttpGet]
    public async Task<ActionResult<List<Schema>>> GetSchemasByUserId(Guid UserId)
    {
        try
        {
            var schemas = await schemaUseCases.GetSchemasByUserId(UserId);
            if (schemas == null) return NotFound();
            return Ok(schemas);
        }
        catch
        {
            return Problem("Ocorreu um erro ao buscar os schemas");
        }
    }
}
