using System.Text.Json;

namespace StirCraftApp.Infrastructure.Data.SeedData;
public static class JsonSeedHelper
{
	private static readonly string BaseFolderPath =
		Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\StirCraftApp\StirCraftApp.Infrastructure\Data\SeedData\SeedJsons"));
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
