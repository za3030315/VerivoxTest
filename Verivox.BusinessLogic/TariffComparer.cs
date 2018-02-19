using System.Collections.Generic;
using System.Linq;
using Verivox.BusinessLogic.Tariffs;
using Verivox.BusinessLogic.Tariffs.Abstract;

namespace Verivox.BusinessLogic
{
    public class TariffComparer
    {
        /// <summary>
        /// Generates list of tariffs where each tariff is constructed manually.
        /// </summary>
        /// <returns>List of tariffs ordered by their yearly cost</returns>
        public IList<ITariff> GenerateTariffList(decimal consumption)
        {
            return new List<ITariff>
                   {
                       new BasicElectricityTariff(consumption),
                       new PackagedTariff(consumption),
                   }.OrderBy(x => x.YearlyCost).ToList();
        }
    }
}
