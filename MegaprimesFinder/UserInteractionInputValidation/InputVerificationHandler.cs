using MegaprimesFinder.Constants;
using System;

namespace MegaprimesFinder.UserInteractionInputValidation
{
    class InputVerificationHandler
    {
        readonly UIText text;
        public InputVerificationHandler()
        {
            text = new UIText();
        }
        public uint GetValidData()
        {
            uint validNumber;

            while (!uint.TryParse(Console.ReadLine(), out validNumber) || validNumber == 0)
            {
                DisplayErrorMessage();
            }
            Console.WriteLine(text.Loading);
            return validNumber;
        }

        void DisplayErrorMessage()
        {

            Console.Clear();
            Console.WriteLine(text.ProblemDefinition);
            Console.WriteLine(text.InputDefinition);
        }
    }
}
