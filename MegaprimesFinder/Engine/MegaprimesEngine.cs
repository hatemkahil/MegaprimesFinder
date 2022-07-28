using log4net;
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
        private IEnumerable<int> _numbers;
        private List<uint> _megaprimeNumbers;
        private IntHelpers _helpers;
        public MegaprimesEngine(ILog Log, ILog ErrorLog)
        {
            _log = Log;
            _errorLog = ErrorLog;
            _numbers = new List<int>();
            _helpers = new IntHelpers();
        }
        public List<uint> GetMegaprimeNumbers(uint max)
        {
            stopWatch = Stopwatch.StartNew();
            _log.Info($"Stopwatch started for {max} input");
            _megaprimeNumbers = new List<uint>();
            var Numbers = Enumerable.Range(1, Convert.ToInt32(max)).ToList();

            var partitions = _helpers.GroupNumbers(Numbers);
            FindMegaprimesInParallel(partitions);


            stopWatch.Stop();
            _log.Info($"Total engine elapse time {stopWatch.ElapsedMilliseconds} milliseconds");
            return _megaprimeNumbers;
        }
        void FindMegaprimesInParallel(List<IEnumerable<int>> partitions)
        {
            List<List<int>> megaprimesListsList = new();

            var count = 0;
            Parallel.ForEach(partitions, partition =>
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
            foreach (var number in numbers)
            {
                if (IsMegaprime(number))
                    list.Add(number);
            }
            _log.Info($"{index} MegaprimesToList completed");
            return list;
        }

        bool IsMegaprime(int number)
        {
            var digitlist = _helpers.digitSplitter(number);

            foreach (var digit in digitlist)
            {
                if (!DigitIsPrime(digit))
                    return false;
            }

            if (!IsPrime(number))
                return false;
            return true;
        }

        bool DigitIsPrime(int digit)
        {
            switch (digit)
            {
                case 2:
                    return true;
                case 3:
                    return true;
                case 5:
                    return true;
                case 7:
                    return true;
                default:
                    return false;
            }
        }
        //TODO check if you can somehow reduce the amount of running the below loop by saving numbers and carrying on from where you were left
        bool IsPrime(int number)
        {
            int numberOfDivisions = 0;
            for (int i = 1; i <= number; i++)
            {
                if (number % i == 0)
                {
                    numberOfDivisions++;
                }
            }
            return numberOfDivisions == 2;
        }
    }
}
