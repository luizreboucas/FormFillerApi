using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormFiller.Application.UseCases.Models
{
    public record ParamCreateResponse(Guid Id, string value, Guid GeneratorId);
}
