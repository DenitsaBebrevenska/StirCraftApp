using StirCraftApp.Domain.Entities;
using StirCraftApp.Domain.Specifications.SpecParams;

namespace StirCraftApp.Domain.Specifications.MeasurementUnitSpec;
public class MeasurementUnitFilterSpecification : BaseSpecification<MeasurementUnit>
{
    public MeasurementUnitFilterSpecification(MeasurementUnitParams unitParams)
    : base(mu => (!unitParams.IsSolidSpecific.HasValue || mu.IsSolidSpecific == unitParams.IsSolidSpecific) &&
                  (!unitParams.IsLiquidSpecific.HasValue || mu.IsLiquidSpecific == unitParams.IsLiquidSpecific))
    {
        AddOrderBy(mu => mu.Abbreviation);
    }
}

