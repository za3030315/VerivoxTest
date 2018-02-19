using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Verivox.BusinessLogic.Tariffs;

namespace Verivox.Tests
{
    [TestClass]
    public class BasicElectricityTariffTests
    {
        [TestMethod]
        public void ShouldReturn830WhenConsumption3500()
        {
            var tariff = new BasicElectricityTariff(3500);
            Assert.AreEqual(tariff.YearlyCost, 830);
        }

        [TestMethod]
        public void ShouldReturn1050WhenConsumption4500()
        {
            var tariff = new BasicElectricityTariff(4500);
            Assert.AreEqual(tariff.YearlyCost, 1050);
        }

        [TestMethod]
        public void ShouldReturn1380WhenConsumption6000()
        {
            var tariff = new BasicElectricityTariff(6000);
            Assert.AreEqual(tariff.YearlyCost, 1380);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowArgumentExceptionWhenConsumptionNegative()
        {
            var tariff = new BasicElectricityTariff(-500);
        }
    }
}
