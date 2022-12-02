using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Module4task4.Data;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        var connectionString = new ConfigurationBuilder().AddJsonFile("config.json").Build()
            .GetConnectionString("DefaultConnection");
        optionsBuilder.UseNpgsql(
            connectionString,
            opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds));

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}