using MegaprimesFinder.Constants;
using System;

namespace MegaprimesFinder.DataHandlers
{
    class InputVerificationHandler
    {
        public uint InvalidDataChecker()
        {
            uint n;

            while (!uint.TryParse(Console.ReadLine(), out n) || n == 0)
            {
                displayErrorMessage();
            }

            return n;
        }

        void displayErrorMessage()
        {
            var text = new UIText();
            Console.Clear();
            Console.WriteLine(text.ProblemDefinition);
            Console.WriteLine(text.InputDefinition);
        }
    }
}
