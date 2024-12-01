using StirCraftApp.Domain.Entities;
using StirCraftApp.Domain.Specifications.SpecParams;

namespace StirCraftApp.Domain.Specifications.MeasurementUnitSpec;
public class MeasurementUnitFilterSpecification : BaseSpecification<MeasurementUnit>
{
    public MeasurementUnitFilterSpecification(MeasurementUnitParams unitParams)
    {
        AddOrderBy(mu => mu.Abbreviation);
    }
}

