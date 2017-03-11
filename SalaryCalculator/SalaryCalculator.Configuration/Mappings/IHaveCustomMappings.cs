using AutoMapper;

namespace SalaryCalculator.Configuration.Mappings
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IMapperConfigurationExpression configuration);
    }
}