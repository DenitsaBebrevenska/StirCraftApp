namespace StirCraftApp.Domain.Specifications.SpecParams;
public class MeasurementUnitParams
{
    private bool? _isSolidSpecific;

    public bool? IsSolidSpecific
    {
        get => _isSolidSpecific;
        set => _isSolidSpecific = value;
    }


    private bool? _isLiquidSpecific;

    public bool? IsLiquidSpecific
    {
        get => _isLiquidSpecific;
        set => _isLiquidSpecific = value;
    }
}
