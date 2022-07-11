using log4net;
using MegaprimesFinder.Constants;
using MegaprimesFinder.DataHandlers;
using System;
using System.Diagnostics;

namespace MegaprimesFinder
{
    class Program
    {
        public static ILog Log;
        public static ILog ErrorLog;
        static Program()
        {
            log4net.Config.XmlConfigurator.Configure();
            Log = LogManager.GetLogger("info");
            ErrorLog = LogManager.GetLogger("error");
        }
        static void Main(string[] args)
        {
            var text = new UIText();
            while (!(Console.KeyAvailable))
            {
                Console.WriteLine(text.ProblemDefinition);

                var megaprimesDataHandler = new MegaprimesHandler(Log, ErrorLog);
                var megaprimesData = megaprimesDataHandler.GetData();

                while (megaprimesData.Numbers.Count == 0)
                {
                    Console.Clear();
                    Console.WriteLine(text.NoMegaprimeNumbers(megaprimesData.ValidInput));
                    Console.WriteLine(text.ProblemDefinition);

                    megaprimesData = megaprimesDataHandler.GetData();
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
