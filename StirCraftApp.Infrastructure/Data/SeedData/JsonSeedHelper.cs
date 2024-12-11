using System.Text.Json;

namespace StirCraftApp.Infrastructure.Data.SeedData;

/// <summary>
/// A utility class to assist with loading JSON data for seeding purposes.
/// This class provides a method to load JSON files from a specific directory and deserialize them into a list of objects.
/// </summary>
public static class JsonSeedHelper
{
    private static readonly string BaseFolderPath =
        Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\StirCraftApp\StirCraftApp.Infrastructure\Data\SeedData\SeedJsons"));

    /// <summary>
    /// Loads data from a JSON file and deserializes it into a list of objects of the specified type.
    /// </summary>
    /// <typeparam name="T">The type of the objects in the list to be deserialized.</typeparam>
    /// <param name="fileName">The name of the JSON file to load data from.</param>
    /// <returns>A list of objects of type <typeparamref name="T"/>.</returns>
    /// <exception cref="ArgumentException">Thrown when the specified file does not exist.</exception>
    /// <exception cref="NullReferenceException">Thrown when deserialization fails or the JSON data is invalid.</exception>
    public static List<T> LoadJsonData<T>(string fileName) where T : class
    {
        var filePath = Path.Combine(BaseFolderPath, $"{fileName}.json");

        if (!File.Exists(filePath))
        {
            throw new ArgumentException($"File does not exist {filePath}");
        }

        var json = File.ReadAllText(filePath);

        return JsonSerializer.Deserialize<List<T>>(json)
               ?? throw new NullReferenceException($"Failed to read {fileName}.json");
    }
}
