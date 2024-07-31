using MotorcycleRentalSystem.Domain.Contracts;
using MotorcycleRentalSystem.Domain.Entities;
namespace MotorcycleRentalSystem.Infrastructure.Context;

public class UnitOfWork(AppDbContext dbContext) : IUnitOfWork
{
    private readonly AppDbContext _dbContext = dbContext;

    public async Task Commit()
    {
        PromoteTimestampChanges();
        await _dbContext.SaveChangesAsync();
    }

    private void PromoteTimestampChanges()
    {
        if (_dbContext.ChangeTracker.HasChanges())
        {
            var timestamp = DateTime.UtcNow;

            foreach (var entry in _dbContext.ChangeTracker.Entries())
            {
                if (entry.Entity is OrdinaryEntityBase item)
                    if (item.CreateAt == DateTime.MinValue)
                        item.CreateAt = timestamp;
                    else
                        item.ModifiedAt = timestamp;
                else if (entry.Entity is User user)
                    if (user.CreateAt == DateTime.MinValue)
                        user.CreateAt = timestamp;
                    else
                        user.ModifiedAt = timestamp;
            }
        }
    }
}
