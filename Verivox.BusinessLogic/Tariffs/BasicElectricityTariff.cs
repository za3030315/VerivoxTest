using System;
using Verivox.BusinessLogic.Tariffs.Abstract;

namespace Verivox.BusinessLogic.Tariffs
{
    public class BasicElectricityTariff : ITariff
    {
        public string Name => "Basic Electricity Tariff";
        public decimal YearlyCost => _yearlyBasePrice + _kilowattPrice * _consumption;

        private decimal _consumption;
        private readonly decimal _yearlyBasePrice;
        private readonly decimal _kilowattPrice;

        public BasicElectricityTariff(decimal consumption = 0, decimal yearlyBasePrice = 5 * 12, decimal kilowattPrice = 0.22m)
        {
            if (consumption < 0 || yearlyBasePrice < 0 || kilowattPrice < 0)
            {
                throw new ArgumentException();
            }

            _consumption = consumption;
            _yearlyBasePrice = yearlyBasePrice;
            _kilowattPrice = kilowattPrice;
        }

        public void SetConsumption(decimal consumption)
        {
            if (consumption < 0)
            {
                throw new ArgumentException();
            }

            _consumption = consumption;
        }
        
    }
}
