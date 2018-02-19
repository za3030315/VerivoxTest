using System;
using Verivox.BusinessLogic.Tariffs.Abstract;

namespace Verivox.BusinessLogic.Tariffs
{
    public class PackagedTariff : ITariff
    {
        public string Name => "Packaged Tariff";

        public decimal YearlyCost => _consumption <= _minimumConsumption
                                         ? _basePrice
                                         : _basePrice + (_consumption - _minimumConsumption) * _kilowattPrice;

        private decimal _consumption;
        private readonly decimal _minimumConsumption;
        private readonly decimal _basePrice;
        private readonly decimal _kilowattPrice;

        public PackagedTariff(decimal consumption = 0, decimal minimumConsumption = 4000m, decimal basePrice = 800m, decimal kilowattPrice = 0.3m)
        {
            if (consumption < 0 || minimumConsumption < 0 || basePrice < 0 || kilowattPrice < 0)
            {
                throw new ArgumentException();
            }

            _consumption = consumption;
            _minimumConsumption = minimumConsumption;
            _basePrice = basePrice;
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
