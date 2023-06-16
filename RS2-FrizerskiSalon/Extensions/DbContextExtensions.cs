using Microsoft.EntityFrameworkCore;
using RS2_FrizerskiSalon.Database;

namespace RS2_FrizerskiSalon.Extensions;

public static class DbContextExtensions
{
    public static void MigrateAndSeedDatabase(this FrizerskiStudioRsiiContext context)
    {
        if (context == null)
        {
            throw new ArgumentNullException("context");
        }

        context.Database.Migrate();

        if (context.Spols.Any())
        {
            return;
        }
    }
}
