using log4net;
using MegaprimesFinder.Engine;
using MegaprimesFinder.Engine.Models;
using MegaprimesFinder.UserInteractionInputValidation;

namespace MegaprimesFinder
{
    class Processor
    {
        private readonly ILog _log;
        private readonly ILog _errorLog;
        public Processor(ILog Log, ILog ErrorLog)
        {
            _log = Log;
            _errorLog = ErrorLog;
        }
        public MegaprimesData GetMegaprimesFromValidData()
        {
            var megaprimesData = new MegaprimesData();
            var inputVerificationHandler = new InputVerificationHandler();
            var engine = new MegaprimesEngine(_log, _errorLog);

            megaprimesData.Input = inputVerificationHandler.GetValidData();
            megaprimesData.Numbers = engine.GetMegaprimeNumbers(megaprimesData.Input);
            return megaprimesData;
        }
    }
}
