using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PCDiagnostics.Data.DbModels.Devices;

namespace PCDiagnostics.Data.DbModels.Diagnostics;

public class DiagnosticDbModel
{
	public Guid Id { get; set; }
	public DateTime CheckTime { get; set; }

	/* navigation properties */
	public List<DeviceDbModel>? Devices { get; set; }

	internal class Map : IEntityTypeConfiguration<DiagnosticDbModel>
	{
		public void Configure(EntityTypeBuilder<DiagnosticDbModel> builder)
		{
			builder.ToTable("diagnostics");

			builder.HasKey(it => it.Id).HasName("pk_diagnostic_id");
		}
	}
}
