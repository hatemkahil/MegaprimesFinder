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
        private MegaprimesEngine _engine;
        public Processor(ILog Log, ILog ErrorLog)
        {
            _log = Log;
            _errorLog = ErrorLog;
            _engine = new MegaprimesEngine(_log, _errorLog);
        }
        public MegaprimesData GetMegaprimesFromValidData()
        {
            var megaprimesData = new MegaprimesData();
            var inputVerificationHandler = new InputVerificationHandler();

            megaprimesData.Input = inputVerificationHandler.GetValidData();
            megaprimesData.Numbers = _engine.GetMegaprimeNumbers(megaprimesData.Input);
            return megaprimesData;
        }
    }
}
