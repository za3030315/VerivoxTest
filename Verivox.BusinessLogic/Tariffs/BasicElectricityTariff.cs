using System;
using Verivox.BusinessLogic.Tariffs.Abstract;

namespace Verivox.BusinessLogic.Tariffs
{
    public class BasicElectricityTariff : ITariff
    {
        public string Name => "Basic Electricity Tariff";
        public decimal YearlyCost { get; }

        private readonly decimal _consumption;
        private readonly decimal _yearlyBasePrice;
        private readonly decimal _kilowattPrice;

        public BasicElectricityTariff(decimal consumption = 0, decimal yearlyBasePrice = 5 * 12, decimal kilowattPrice = 0.22m)
        {
            if (consumption < 0) { throw new ArgumentException("consumption should be higher than 0"); }
            if (yearlyBasePrice < 0) { throw new ArgumentException("yearlyBasePrice should be higher than 0"); }
            if (kilowattPrice < 0) { throw new ArgumentException("kilowattPrice should be higher than 0"); }

            _consumption = consumption;
            _yearlyBasePrice = yearlyBasePrice;
            _kilowattPrice = kilowattPrice;

            YearlyCost = CalculateYearlyCost();
        }

        private decimal CalculateYearlyCost()
        {
            return _yearlyBasePrice + _kilowattPrice * _consumption;
        }
    }
}
