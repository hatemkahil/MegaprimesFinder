using System;
using System.Collections.Generic;
using System.Text;

namespace MegaprimesFinder.Constants
{
    public class UIText
    {
        public string ProblemDefinition => "Please enter a number to check which numbers from 1 to the entered number are Megaprime Numbers.";
        public string InputDefinition => "Please enter an integer that is bigger than or equal to 1";
        public string Loading => "Getting Megaprime numbers...";
        public string Complete => "Megaprime list is ready!";
        public string NoMegaprimeNumbers(uint maxNumber) => $"The are no Megaprimes from 1 to {maxNumber}, please try again";
        public string MegaprimeNumbers(uint maxNumber, int megaprimeCount) => $"There are {megaprimeCount} Megaprime Numbers from 1 to {maxNumber} which are:";
    }
}
