using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PCDiagnostics.Core.Domains.Devices;
using PCDiagnostics.Data.DbModels.Diagnostics;

namespace PCDiagnostics.Data.DbModels.Devices;

public class DeviceDbModel
{
	public Guid DiagnosticId { get; set; }
	public string? Name { get; set; }
	public Dictionary<string, string>? Specs { get; set; }

	/* navigation properties */
	public DiagnosticDbModel Diagnostic { get; set; }

	public DeviceDbModel() { }

	public DeviceDbModel(Device coreDevice)
	{
		DiagnosticId = coreDevice.DiagnosticId;
		Name = coreDevice.Name;
		Specs = coreDevice.Specs;
	}

	internal class Map : IEntityTypeConfiguration<DeviceDbModel>
	{
		public void Configure(EntityTypeBuilder<DeviceDbModel> builder)
		{
			builder.ToTable("devices");

			builder.HasKey(it => new { it.DiagnosticId, it.Name });

			builder.HasOne(it => it.Diagnostic)
				.WithMany(it => it.Devices)
				.HasForeignKey(it => it.DiagnosticId);
		}
	}
}
