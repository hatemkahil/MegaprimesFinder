using MegaprimesFinder.Constants;
using MegaprimesFinder.DataHandlers;
using System;

namespace MegaprimesFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = new UIText();
            while (!(Console.KeyAvailable))
            {
                Console.WriteLine(text.ProblemDefinition);

                var megaprimesDataHandler = new DataHandler();
                var megaprimesData = megaprimesDataHandler.getData();

                while (megaprimesData.Numbers.Count == 0)
                {
                    Console.Clear();
                    Console.WriteLine(text.NoMegaprimeNumbers(megaprimesData.ValidInput));
                    Console.WriteLine(text.ProblemDefinition);

                    megaprimesData = megaprimesDataHandler.getData();
                }

                Console.Clear();
                Console.WriteLine(text.Complete);
                Console.WriteLine(text.MegaprimeNumbers(megaprimesData.ValidInput, megaprimesData.Numbers.Count));
                foreach (var number in megaprimesData.Numbers)
                {
                    Console.WriteLine(number);
                }
            }

        }
    }
}
