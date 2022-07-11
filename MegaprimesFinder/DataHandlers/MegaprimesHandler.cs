using log4net;
using MegaprimesFinder.Constants;
using MegaprimesFinder.Models;
using System;

namespace MegaprimesFinder.DataHandlers
{
    public class MegaprimesHandler
    {
        readonly InputVerificationHandler inputVerificationHandler;
        Engine engine;
        readonly MegaprimesData megaprimesData;
        readonly ILog _log;
        readonly ILog _errorLog;

        public MegaprimesHandler(ILog Log, ILog ErrorLog)
        {
            inputVerificationHandler = new InputVerificationHandler();
            megaprimesData = new MegaprimesData();
            engine = new Engine(Log, ErrorLog);
            _log = Log;
            _errorLog = ErrorLog;
        }

        public MegaprimesData GetData()
        {
            var text = new UIText();

            megaprimesData.ValidInput = inputVerificationHandler.InvalidDataChecker();
            Console.WriteLine(text.Loading);
            megaprimesData.Numbers = engine.GetMegaprimeNumbers(megaprimesData.ValidInput);

            return megaprimesData;
        }
    }
}



