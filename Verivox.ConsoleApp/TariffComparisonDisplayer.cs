using System;
using System.Collections.Generic;
using System.Linq;
using Verivox.BusinessLogic.Tariffs.Abstract;

namespace Verivox.ConsoleApp
{
    internal class TariffComparisonDisplayer
    {
        public void DisplayComparison(decimal consumption, IEnumerable<ITariff> tariffs)
        {
            Console.WriteLine($"---------- Tariff comparison for consumption of {consumption} kWh/year ----------");
            Console.WriteLine("Tariff                         Yearly Price");
            foreach (var tariff in tariffs)
            {
                DisplayTariff(tariff);
            }
            Console.WriteLine();
        }

        private void DisplayTariff(ITariff tariff)
        {
            Console.WriteLine($"{tariff.Name, -30} {tariff.YearlyCost:C}");
        }
    }
}
