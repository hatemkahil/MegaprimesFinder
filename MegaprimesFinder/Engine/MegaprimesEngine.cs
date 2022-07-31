using log4net;
using MegaprimesFinder.Engine.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MegaprimesFinder.Engine
{
    public class MegaprimesEngine
    {
        public static Stopwatch stopWatch;
        private readonly ILog _log;
        private readonly ILog _errorLog;
        private List<uint> _megaprimeNumbers;
        private int _maxUntilNow = 0;
        private List<uint> _savedMegaprimeNumbers;
        private Logger _logger;
        public MegaprimesEngine(ILog Log, ILog ErrorLog)
        {
            _log = Log;
            _errorLog = ErrorLog;
            _savedMegaprimeNumbers = new List<uint>();
            _logger = new Logger(Log, ErrorLog);
        }
        public List<uint> GetMegaprimeNumbers(uint max)
        {
            var intMax = Convert.ToInt32(max);
            _logger.MegaprimesEngineStartLogger(intMax);

            List<int> Numbers = new ();
            _megaprimeNumbers = new List<uint>();


            if (_savedMegaprimeNumbers.Count > 0)
            {
                int savedMax = Convert.ToInt32(_savedMegaprimeNumbers.Max());

                //Speeding things up from saved megaprimes
                if (savedMax < intMax)
                {
                    _megaprimeNumbers = _savedMegaprimeNumbers;
                    var count = intMax - savedMax;
                    Numbers = Enumerable.Range(savedMax, count).ToList();
                }
                else if (savedMax > intMax)
                {
                    return _savedMegaprimeNumbers.FindAll(x => x < intMax);
                }
            }
            else
                Numbers = Enumerable.Range(1, intMax).ToList();

            var helpers = new IntHelpers();
            var partitions = helpers.GroupNumbers(Numbers);
            FindMegaprimesInParallel(partitions);


            _logger.MegaprimesEngineStopLogger();
            SaveMegaprimesForFasterProcessingNextTime(intMax, _megaprimeNumbers);
            return _megaprimeNumbers;
        }

        private void SaveMegaprimesForFasterProcessingNextTime(int intMax, List<uint> megaprimeNumbers)
        {
            if (_maxUntilNow < intMax)
            {
                _maxUntilNow = intMax;
                _savedMegaprimeNumbers = megaprimeNumbers;
            }
        }

        void FindMegaprimesInParallel(List<IEnumerable<int>> partitions)
        {
            List<List<int>> megaprimesListsList = new();

            var count = 0;
            //For debbugging purposes
            const bool forceNonParallel = false;
            var options = new ParallelOptions { MaxDegreeOfParallelism = forceNonParallel ? 1 : -1 };
            //-------
            Parallel.ForEach(partitions, options, partition =>
            {
                count++;
                var part = partition;
                megaprimesListsList.Add(FindMegaprimesAndAddToList(part, Convert.ToInt32(Task.CurrentId)));
            }
            );



            foreach (var megaprimesList in megaprimesListsList)
            {
                foreach (var megaprimes in megaprimesList)
                {
                    _megaprimeNumbers.Add(Convert.ToUInt32(megaprimes));
                }
            }
            _megaprimeNumbers.Sort();
        }

        List<int> FindMegaprimesAndAddToList(IEnumerable<int> numbers, int index)
        {
            _log.Info($"{index} MegaprimesToList started");
            List<int> list = new List<int>();
            var megaprimeEngine = new MegaprimeEngine();
            foreach (var number in numbers)
            {
                if (megaprimeEngine.IsMegaprime(number))
                    list.Add(number);
            }
            _log.Info($"{index} MegaprimesToList completed");
            return list;
        } 
    }
}
