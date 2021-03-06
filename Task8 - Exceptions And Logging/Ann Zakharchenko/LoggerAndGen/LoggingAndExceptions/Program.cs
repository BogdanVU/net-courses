﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoggingAndExceptions.Implementation;
using log4net;
using log4net.Config;

namespace LoggingAndExceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlConfigurator.Configure();
            ILog logger = LogManager.GetLogger("TextLogger");
            LoggerService loggerService = new LoggerService(logger);
            FirstProducer firstProducer = new FirstProducer(loggerService);
            SecondProducer secondProducer = new SecondProducer(loggerService);
            BadProducer badProducer = new BadProducer(loggerService);
            Client clientForBadProducer = new Client();

            badProducer.OnGoodPointReceived += clientForBadProducer.GetGoodPoint;

            Task.Run(() =>
            {
                firstProducer.Run((point) => loggerService.Info($"First Function {point}"));
            });

            Task.Run(() => 
            {
                secondProducer.Run((point) => loggerService.Info($"Second Function {point}"));
            });

            Task.Run(() =>
            {
                badProducer.Run((point) => loggerService.Info($"BadProducer Function {point}"));
            });

            Console.ReadLine();

            secondProducer.IsContinue = false;
            firstProducer.IsContinue = false;
            badProducer.IsContinue = false;

            Console.WriteLine("Good Bay!");
            Console.ReadKey();
        }
    }
}
