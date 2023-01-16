using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PCDiagnostics.Data.DbModels.Users;

public class UserDbModel
{
	public string Login { get; set; }
	public string Key { get; set; }

	internal class Map : IEntityTypeConfiguration<UserDbModel>
	{
		public void Configure(EntityTypeBuilder<UserDbModel> builder)
		{
			builder.ToTable("users");

			builder.HasKey(it => it.Login).HasName("pk_login");
		}
	}
}
