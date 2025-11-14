using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormFiller.Application.Exceptions
{
    public class NotFoundInTheDatabaseExeption(string message) : Exception(message)
    {}
}
