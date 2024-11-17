namespace StirCraftApp.Application.Contracts;
public interface IDtoFactory<T>
{
    IDto GetDto(T obj, string dtoName);
}
