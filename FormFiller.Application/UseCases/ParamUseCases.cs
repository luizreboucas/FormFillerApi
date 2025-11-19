using FormFiller.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormFiller.Domain.Entities;
using FormFiller.Application.UseCases.Models;

namespace FormFiller.Application.UseCases
{
    public class ParamUseCases
    {
        public IParamRepository paramRepository;
        public IGeneratorRepository generatorRepository;

        public ParamUseCases(IParamRepository _paramRepository, IGeneratorRepository _generatorRepository)
        {
            paramRepository = _paramRepository;
            generatorRepository = _generatorRepository;
        }

        public async Task<ParamCreateResponse> CreateParam(CreateParamRequest paramRequest)
        {
            var generator = await generatorRepository.GetById(paramRequest.GeneratorId);
            if(generator == null)
            {
                throw new Exception("Generator not found");
            }
            var param = new Param
            {
                Value = paramRequest.Value,
                Generator = generator
            };
            var newParam = await paramRepository.Create(param);
            return new ParamCreateResponse(newParam.Id, newParam.Value, newParam.Generator.Id);
        }
    }
}
