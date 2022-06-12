using MegaprimesFinder.Constants;
using MegaprimesFinder.Models;
using System;

namespace MegaprimesFinder.DataHandlers
{
    public class DataHandler
    {
        readonly InputVerificationHandler inputVerificationHandler;
        readonly Engine engine;
        readonly MegaprimesData megaprimesData;

        public DataHandler()
        {
            inputVerificationHandler = new InputVerificationHandler();
            engine = new Engine();
            megaprimesData = new MegaprimesData();
        }

        public MegaprimesData getData()
        {
            var text = new UIText();

            megaprimesData.ValidInput = inputVerificationHandler.InvalidDataChecker();
            Console.WriteLine(text.Loading);
            megaprimesData.Numbers = engine.GetMegaprimeNumbers(megaprimesData.ValidInput);

            return megaprimesData;
        }
    }
}



