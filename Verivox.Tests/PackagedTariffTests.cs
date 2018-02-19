using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Verivox.BusinessLogic.Tariffs;

namespace Verivox.Tests
{
    [TestClass]
    public class PackagedTariffTests
    {
        [TestMethod]
        public void ShouldReturn800WhenConsumption3500()
        {
            var tariff = new PackagedTariff(3500);
            Assert.AreEqual(tariff.YearlyCost, 800);
        }

        [TestMethod]
        public void ShouldReturn950WhenConsumption4500()
        {
            var tariff = new PackagedTariff(4500);
            Assert.AreEqual(tariff.YearlyCost, 950);
        }

        [TestMethod]
        public void ShouldReturn1400WhenConsumption6000()
        {
            var tariff = new PackagedTariff(6000);
            Assert.AreEqual(tariff.YearlyCost, 1400);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowArgumentExceptionWhenConsumptionNegative()
        {
            var tariff = new PackagedTariff(-500);
        }
    }
}
