using Microsoft.VisualStudio.TestTools.UnitTesting;
using Verivox.BusinessLogic;
using Verivox.BusinessLogic.Tariffs.Abstract;

namespace Verivox.Tests
{
    [TestClass]
    public class TariffComparerTests
    {
        [TestMethod]
        public void ShouldReturnTwoTariffsWhenTwoTariffsAreCompared()
        {
            var tariffComparer = new TariffComparer();
            tariffComparer.Add(TariffType.BasiElectricity);
            tariffComparer.Add(TariffType.Packaged);

            var tariffs = tariffComparer.Compare(1);

            Assert.AreEqual(tariffs.Count, 2);
        }

        [TestMethod]
        public void ShouldReturnArraySortedByYearlyCostWhenTwoArraysAreCompared()
        {
            var tariffComparer = new TariffComparer();
            tariffComparer.Add(TariffType.BasiElectricity);
            tariffComparer.Add(TariffType.Packaged);

            var tariffs = tariffComparer.Compare(1);

            Assert.IsTrue(tariffs[0].YearlyCost < tariffs[1].YearlyCost);
        }
    }
}
