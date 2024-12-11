namespace StirCraftApp.Application.Exceptions;

/// <summary>
/// Custom exception for validated a certain condition that must be met.
/// </summary>
/// <param name="message">The message to be displayed when the exception occurs.</param>
public class ValidationException(string message) : Exception(message)
{
}
