using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Logic.Wrappers
{
    public class MyNumbersWrapper : IMyNumbersWrapper
    {
        public int SumNumbers(int numOne, int numTwo)
        {
            return MyNumbersS.Sum(numOne, numTwo);
        }
    }
}
