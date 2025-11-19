using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormFiller.Application.UseCases.Models
{
    public record LoginResponse<T>(T User);
}
