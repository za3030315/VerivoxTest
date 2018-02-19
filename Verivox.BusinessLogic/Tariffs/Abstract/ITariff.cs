namespace Verivox.BusinessLogic.Tariffs.Abstract
{
    public interface ITariff
    {
        string Name { get; }
        decimal YearlyCost { get; }
        void SetConsumption(decimal consumption);
    }
}
