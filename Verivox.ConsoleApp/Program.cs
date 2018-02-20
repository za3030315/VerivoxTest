using System;
using Verivox.BusinessLogic;
using Verivox.BusinessLogic.Tariffs.Abstract;

namespace Verivox.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var consumptions = new decimal[] {100, 4000, 5000, 6000, 123123, 255.255m};
            var tariffDisplayer = new TariffComparisonDisplayer();

            var tariffComparer = new TariffComparer();
            tariffComparer.Add(TariffType.BasiElectricity);
            tariffComparer.Add(TariffType.Packaged);

            foreach (var consumption in consumptions)
            {
                var tariffs = tariffComparer.Compare(consumption);
                tariffDisplayer.DisplayComparison(consumption, tariffs);
            }

            Console.ReadKey();
        }
    }
}
