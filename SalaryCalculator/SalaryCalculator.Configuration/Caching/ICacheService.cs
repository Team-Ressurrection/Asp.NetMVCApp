using System;

namespace SalaryCalculator.Configuration.Caching
{
    public interface ICacheService
    {
        T Get<T>(string itemName, Func<T> getDataFunc, int durationInSeconds);

        void Remove(string itemName);

    }
}