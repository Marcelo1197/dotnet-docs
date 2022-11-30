using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Common.Exceptions
{
    public class OddNumberException: Exception
    {
        public OddNumberException(): base("Los números pasados como parámetro deben ser impares. No se aceptan numeros pares.")
        {

        }
    }
}
