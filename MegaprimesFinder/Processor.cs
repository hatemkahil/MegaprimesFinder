using log4net;
using MegaprimesFinder.Engine;
using MegaprimesFinder.Engine.Models;
using System.Collections.Generic;

namespace MegaprimesFinder
{
    class Processor
    {
        private readonly ILog _log;
        private readonly ILog _errorLog;
        private readonly MegaprimesData _megaprimesData;
        public Processor(ILog Log, ILog ErrorLog)
        {
            _log = Log;
            _errorLog = ErrorLog;
            _megaprimesData = new MegaprimesData();
        }

        public MegaprimesData GetMegaprimesFromValidData()
        {
            _megaprimesData.Input = GetValidData();
            _megaprimesData.Numbers = GetMegaprimes(_megaprimesData.Input);

            return _megaprimesData;
        }

        public uint GetValidData()
        {
            var inputVerificationHandler = new InputVerificationHandler();

            return inputVerificationHandler.GetValidData();
        }

        public List<uint> GetMegaprimes(uint input)
        {
            var engine = new MegaprimesEngine(_log, _errorLog);

            return engine.GetMegaprimeNumbers(input); ;
        }
    }
}
