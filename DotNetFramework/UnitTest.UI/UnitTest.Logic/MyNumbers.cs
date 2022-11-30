using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.Common.Exceptions;

namespace UnitTest.Logic
{
    public class MyNumbers
    {
        public double Sum(int numOne, int numTwo)
        {
            return numOne + numTwo;
        }

        public int SumOnlyOdd(int numOne, int numTwo)
        {
            var result = 0;
            try
            {
                var areOddNumbers = (numOne % 2 != 0 && numTwo % 2 != 0) ? true : false;
                if (areOddNumbers == false)
                {
                    throw new OddNumberException();
                }
                result = numOne + numTwo;
            }
            catch (OddNumberException ex)
            {
                // We re-throw the CustomException only for UnitTest proposites
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        public static void SumOnlyEven()
        {

        }
    }
}
