using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PCDiagnostics.Core.Domains.Diagnostics;
using PCDiagnostics.Data.DbModels.Devices;

namespace PCDiagnostics.Data.DbModels.Diagnostics;

public class DiagnosticDbModel
{
	public Guid Id { get; set; }
	public DateTime CheckTime { get; set; }

	/* navigation properties */
	public List<DeviceDbModel>? Devices { get; set; }

	public DiagnosticDbModel() { }

	public DiagnosticDbModel(Diagnostic coreDiagnostic)
	{
		Id = coreDiagnostic.Id;
		CheckTime = coreDiagnostic.CheckTime;
	}

	internal class Map : IEntityTypeConfiguration<DiagnosticDbModel>
	{
		public void Configure(EntityTypeBuilder<DiagnosticDbModel> builder)
		{
			builder.ToTable("diagnostics");

			builder.HasKey(it => it.Id).HasName("pk_diagnostic_id");
		}
	}
}
