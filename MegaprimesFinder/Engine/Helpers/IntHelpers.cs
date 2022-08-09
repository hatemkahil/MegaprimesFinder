using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaprimesFinder.Engine.Helpers
{
    public class IntHelpers
    {
        public List<int> DigitSplitter(int number)
        {
            var digitList = new List<int>();
            var num = number;
            while (num > 0) //do till num greater than  0
            {
                int mod = num % 10; //split last digit from number
                num = num / 10; //divide num by 10. num /= 10 also a valid one 
                digitList.Add(mod);
            }

            digitList.Reverse();

            return digitList;
        }
        //TODO check different numbers below see if it effects speed
        public List<IEnumerable<int>> GroupNumbers(List<int> numbers)
        {
            int divideBy = 0;
            if (numbers.Max() < 100)
                divideBy = 1;
            else if (numbers.Max() > 10000)
                divideBy = 1000;
            else
                divideBy = 100;

            return numbers.Partition(divideBy).ToList();
        }
    }
}
