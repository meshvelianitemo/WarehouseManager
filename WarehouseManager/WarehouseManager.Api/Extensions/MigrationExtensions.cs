using Microsoft.EntityFrameworkCore;
using WarehouseManager.Infrastructure.Persistance;

namespace WarehouseManager.Api.Extensions
{
    public static class MigrationExtensions
    {
        // Applies any pending EF Core migrations on startup.
        // Idempotent: EF reads the __EFMigrationsHistory table and applies
        // only migrations not yet recorded there — if the DB is already
        // up to date, this does nothing.
        //
        // The retry loop exists because in Docker the API container can
        // start before SQL Server is ready to accept connections. Each
        // failed attempt waits and retries until the database comes up.
        public static WebApplication ApplyMigrations(this WebApplication app)
        {
            const int maxAttempts = 10;
            var delay = TimeSpan.FromSeconds(5);

            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var logger = services.GetRequiredService<ILogger<WmsDbContext>>();
            var db = services.GetRequiredService<WmsDbContext>();

            for (var attempt = 1; attempt <= maxAttempts; attempt++)
            {
                try
                {
                    logger.LogInformation(
                        "Applying database migrations (attempt {Attempt}/{MaxAttempts})...",
                        attempt, maxAttempts);

                    db.Database.Migrate();

                    logger.LogInformation("Database migrations are up to date.");
                    return app;
                }
                catch (Exception ex) when (attempt < maxAttempts)
                {
                    logger.LogWarning(
                        ex,
                        "Migration attempt {Attempt} failed — the database may not be ready yet. Retrying in {Delay}s...",
                        attempt, delay.TotalSeconds);

                    Thread.Sleep(delay);
                }
            }

            // Final attempt outside the catch — if this throws, let it crash
            // the app so the failure is loud and visible, not silent.
            logger.LogInformation("Applying database migrations (final attempt {MaxAttempts}/{MaxAttempts})...",
                maxAttempts, maxAttempts);
            db.Database.Migrate();
            logger.LogInformation("Database migrations are up to date.");
            return app;
        }
    }
}
