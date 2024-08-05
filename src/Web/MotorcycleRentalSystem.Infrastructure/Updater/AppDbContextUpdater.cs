using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MotorcycleRentalSystem.Infrastructure.Context;

namespace MotorcycleRentalSystem.Infrastructure.Updater
{
    public class AppDbContextUpdater
    {
        public void UpdateDatabase(AppDbContext appDbContext, ILogger? logger)
        {
            try
            {
                appDbContext.Database.Migrate();
            }
            catch (Exception ex)
            {
                if (logger is null)
                    throw;

                logger?.LogError(ex, "An error occurred creating the DB.");
            }
        }
    }
}
