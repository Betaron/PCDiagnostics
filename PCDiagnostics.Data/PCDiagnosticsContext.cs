using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using PCDiagnostics.Data.DbModels.Devices;
using PCDiagnostics.Data.DbModels.Diagnostics;
using PCDiagnostics.Data.DbModels.Users;

namespace PCDiagnostics.Data;

public class PCDiagnosticsContext : DbContext
{
	public DbSet<DeviceDbModel> Devices { get; set; }
	public DbSet<DiagnosticDbModel> Diagnostics { get; set; }
	public DbSet<UserDbModel> Users { get; set; }

	public PCDiagnosticsContext(DbContextOptions options) : base(options) { }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(PCDiagnosticsContext).Assembly);
		base.OnModelCreating(modelBuilder);
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.LogTo(Console.WriteLine);
		base.OnConfiguring(optionsBuilder);
	}
}

public class Factory : IDesignTimeDbContextFactory<PCDiagnosticsContext>
{
	public PCDiagnosticsContext CreateDbContext(string[] args)
	{
		var options = new DbContextOptionsBuilder()
			.UseNpgsql("FakeConnectionStringForMigrations")
			.UseSnakeCaseNamingConvention()
			.Options;

		return new PCDiagnosticsContext(options);
	}
}
