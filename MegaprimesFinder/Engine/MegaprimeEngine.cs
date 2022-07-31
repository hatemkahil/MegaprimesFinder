using log4net;
using MegaprimesFinder.Engine.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaprimesFinder.Engine
{
    public class MegaprimeEngine
    {
        public bool IsMegaprime(int number)
        {
            var helpers = new IntHelpers();
            var digitlist = helpers.digitSplitter(number);

            foreach (var digit in digitlist)
            {
                if (!DigitIsPrime(digit))
                    return false;
            }

            if (!IsPrime(number))
                return false;
            return true;
        }

        bool DigitIsPrime(int digit)
        {
            switch (digit)
            {
                case 2:
                    return true;
                case 3:
                    return true;
                case 5:
                    return true;
                case 7:
                    return true;
                default:
                    return false;
            }
        }

        bool IsPrime(int number)
        {
            for (int i = 2; i < number; i++)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }
    }
}
