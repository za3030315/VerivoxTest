using System.Collections.Generic;
using System.Linq;
using Verivox.BusinessLogic.Tariffs;
using Verivox.BusinessLogic.Tariffs.Abstract;

namespace Verivox.BusinessLogic
{
    public class TariffComparer
    {
        private List<TariffType> tariffTypes = new List<TariffType>();

        public void Add(TariffType type)
        {
            tariffTypes.Add(type);
        }

        public void AddRange(TariffType[] types)
        {
            tariffTypes.AddRange(types);
        }

        /// <summary>
        /// Generates list of tariffs based on tariff types added to comparison.
        /// </summary>
        /// <returns>List of tariffs ordered by their yearly cost</returns>
        public IList<ITariff> Compare (decimal consumption)
        {
            var tariffs = new List<ITariff>();
            foreach (var tariffType in tariffTypes)
            {
                switch (tariffType)
                {
                    case TariffType.BasiElectricity: tariffs.Add(new BasicElectricityTariff(consumption));
                        break;
                    case TariffType.Packaged: tariffs.Add(new PackagedTariff(consumption));
                        break;
                }
            }

            return tariffs.OrderBy(x => x.YearlyCost).ToList();
        }
    }
}
