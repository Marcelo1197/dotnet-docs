using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.Logic.Wrappers;

namespace UnitTest.Logic
{
    public class MyNumbersWithStaticMethods
    {
        public IMyNumbersWrapper _wrapper;

        public MyNumbersWithStaticMethods(IMyNumbersWrapper wrapper)
        {
            _wrapper = wrapper;
        }

        public int SumNumbers(int numOne, int numTwo)
        {
            return _wrapper.SumNumbers(numOne, numTwo);
        }
    }
}
