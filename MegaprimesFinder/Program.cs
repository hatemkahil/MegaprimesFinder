using log4net;
using System;
using MegaprimesFinder.UserInteractionInputValidation;

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
            var processor = new Processor(Log, ErrorLog);
            var write = new Write();

            while (!(Console.KeyAvailable))
            {
                write.Problem();
                                
                var megaprimesData= processor.GetMegaprimesFromValidData();

                while (megaprimesData.Numbers.Count == 0)
                {
                    write.NoMegaprimesFor(megaprimesData.Input);

                    megaprimesData = processor.GetMegaprimesFromValidData();
                }

                write.SuccessMessageWithMegaprimeNumbers(megaprimesData); 
            }
        }

        
    }
}
