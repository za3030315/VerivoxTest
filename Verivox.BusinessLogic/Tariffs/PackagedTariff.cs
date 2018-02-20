using System;
using Verivox.BusinessLogic.Tariffs.Abstract;

namespace Verivox.BusinessLogic.Tariffs
{
    public class PackagedTariff : ITariff
    {
        public string Name => "Packaged Tariff";

        public decimal YearlyCost { get; }

        private readonly decimal _consumption;
        private readonly decimal _minimumConsumption;
        private readonly decimal _basePrice;
        private readonly decimal _kilowattPrice;

        public PackagedTariff(decimal consumption = 0, decimal minimumConsumption = 4000m, decimal basePrice = 800m, decimal kilowattPrice = 0.3m)
        {
            if (consumption < 0) { throw new ArgumentException("consumption should be higher than 0"); }
            if (minimumConsumption < 0) { throw new ArgumentException("minimumConsumption should be higher than 0"); }
            if (basePrice < 0) { throw new ArgumentException("basePrice should be higher than 0"); }
            if (kilowattPrice < 0) { throw new ArgumentException("kilowattPrice should be higher than 0"); }

            _consumption = consumption;
            _minimumConsumption = minimumConsumption;
            _basePrice = basePrice;
            _kilowattPrice = kilowattPrice;

            YearlyCost = CalculateYearlyCost();
        }

        private decimal CalculateYearlyCost()
        {
            return _consumption <= _minimumConsumption
                       ? _basePrice
                       : _basePrice + (_consumption - _minimumConsumption) * _kilowattPrice;
        }
    }
}
