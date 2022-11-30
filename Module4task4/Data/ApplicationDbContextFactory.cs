using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace Module4task4;

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