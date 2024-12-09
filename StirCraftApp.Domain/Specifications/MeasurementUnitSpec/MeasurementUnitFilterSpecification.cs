using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Domain.Specifications.MeasurementUnitSpec;
public class MeasurementUnitFilterSpecification : BaseSpecification<MeasurementUnit>
{
    public MeasurementUnitFilterSpecification()
    {
        AddOrderBy(mu => mu.Abbreviation);
    }
}

