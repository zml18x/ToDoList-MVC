using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AppMVC.Infrastructure.Data.Context;

namespace AppMVC.Infrastructure.Data;

public static class DatabaseMigrator
{
    public static IServiceProvider MigrateDatabase(this IServiceProvider serviceProvider)
    {
        using (var scope = serviceProvider.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            context.Database.Migrate();
        }

        return serviceProvider;
    }
}