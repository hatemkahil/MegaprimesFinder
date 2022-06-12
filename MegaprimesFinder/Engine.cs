﻿using System;
using System.Collections.Generic;

namespace MegaprimesFinder
{
    class Engine
    {
        public List<uint> GetMegaprimeNumbers(uint max)
        {
            var megaprimenumbers = new List<uint>();
            for (int i = 1; i <= max; i++)
            {
                if (IsMegaprime(i))
                    megaprimenumbers.Add(Convert.ToUInt32(i));
            }
            return megaprimenumbers;
        }

        bool IsMegaprime(int number)
        {
            if (!IsPrime(number))
                return false;


            var digitlist = digitSplitter(number);

            foreach (var digit in digitlist)
            {
                if (!IsPrime(digit))
                    return false;
            }
            return true;
        }

        bool IsPrime(int digit)
        {
            int numberOfDivisions = 0;
            for (int i = 1; i <= digit; i++)
            {
                if (digit % i == 0)
                {
                    numberOfDivisions++;
                }
            }
            return numberOfDivisions == 2;
        }

        List<int> digitSplitter(int number)
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
    }
}
