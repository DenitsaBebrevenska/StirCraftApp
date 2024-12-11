namespace StirCraftApp.Application.Exceptions;

/// <summary>
/// Custom exception for mismatch between current user ID and ID of the  user that created a resource.
/// </summary>
/// <param name="message">The message to be displayed when the exception occurs.</param>
public class NotResourceOwnerException(string message) : Exception(message)
{
}
