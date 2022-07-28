using MegaprimesFinder.Constants;
using MegaprimesFinder.Engine.Models;
using System;

namespace MegaprimesFinder.UserInteractionInputValidation
{
    internal class Write
    {
        UIText text = new UIText();
        public void NoMegaprimesFor(uint number)
        {
            Console.Clear();
            Console.WriteLine(text.NoMegaprimeNumbers(number));
            Problem();
        }

        public void Problem()
        {
            Console.WriteLine(text.ProblemDefinition);
        }

        public void SuccessMessageWithMegaprimeNumbers(MegaprimesData megaprimesData)
        {
            Console.Clear();
            Console.WriteLine(text.Complete);
            Console.WriteLine(text.MegaprimeNumbers(megaprimesData.Input, megaprimesData.Numbers.Count));
            foreach (var number in megaprimesData.Numbers)
            {
                Console.Write($"{number}, ");
            }
            Console.Write("\b \b");
            Console.WriteLine("\b \b");
        }
    }
}
