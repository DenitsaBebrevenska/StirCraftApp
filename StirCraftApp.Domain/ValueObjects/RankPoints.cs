using StirCraftApp.Domain.Enums;

namespace StirCraftApp.Domain.ValueObjects;
public class RankPoints
{
	private int Points { get; }

	public RankPoints(int points)
	{
		//not sure if throwing an exception here is a good idea
		if (points < 0)
			throw new ArgumentException("Points cannot be negative");

		Points = points;
	}

	public Rank GetRank()
	{
		return Points switch
		{
			>= 5000 => Rank.StirCraftGod,
			>= 3000 => Rank.CulinaryOverlord,
			>= 2000 => Rank.MasterOfStirCraft,
			>= 1500 => Rank.SeasonedCommander,
			>= 1000 => Rank.FlavorOperative,
			>= 500 => Rank.StirSpecialist,
			_ => Rank.StirCraftNovice
		};
	}
}
