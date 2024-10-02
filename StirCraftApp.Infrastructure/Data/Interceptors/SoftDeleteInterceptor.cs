using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using StirCraftApp.Domain.Contracts;

namespace StirCraftApp.Infrastructure.Data.Interceptors;
public class SoftDeleteInterceptor : SaveChangesInterceptor
{
	public override ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData,
		int result,
		CancellationToken cancellationToken = new CancellationToken())
	{
		if (eventData.Context is null)
		{
			return base.SavedChangesAsync(eventData, result, cancellationToken);
		}

		IEnumerable<EntityEntry<ISoftDeletable>> entries =
			eventData
				.Context
				.ChangeTracker
				.Entries<ISoftDeletable>()
				.Where(e => e.State == EntityState.Deleted);

		foreach (var entry in entries)
		{
			entry.State = EntityState.Modified;
			entry.Entity.IsDeleted = true;
			entry.Entity.DeletedOnUtc = DateTime.UtcNow;
		}

		return base.SavedChangesAsync(eventData, result, cancellationToken);
	}
}
