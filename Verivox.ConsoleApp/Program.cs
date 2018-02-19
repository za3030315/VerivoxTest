using System;
using System.Collections.Generic;
using Verivox.BusinessLogic;
using Verivox.BusinessLogic.Tariffs.Abstract;

namespace Verivox.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal consumption = 0;
            var tariffComparer = new TariffComparer();
            var tariffDisplayer = new TariffComparisonDisplayer();


            while (true)
            {
                Console.WriteLine("Enter consumption:");
                try
                {
                    string inputString = Console.ReadLine();
                    if (inputString?.ToLower() == "exit")
                    {
                        Environment.Exit(0);
                    }

                    consumption = Convert.ToDecimal(inputString);
                    var tariffs = tariffComparer.GenerateTariffList(consumption);
                    tariffDisplayer.DisplayComparison(consumption, tariffs);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please specify number in the correct format.");
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Please specify positive number.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Your number is too big.");
                }
            }
        }
    }
}
