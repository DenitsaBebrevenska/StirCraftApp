namespace StirCraftApp.Application.Exceptions;

/// <summary>
/// Custom exception for resource that is not found in the database.
/// </summary>
/// <param name="message">The message to be displayed when the exception occurs.</param>
public class NotFoundException(string message) : Exception(message);
