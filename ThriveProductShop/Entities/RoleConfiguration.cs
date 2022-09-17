using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProductShop.Entities;

public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
	public void Configure(EntityTypeBuilder<IdentityRole> builder)
	{
		builder.HasData(
			new IdentityRole
			{
				Name = "Fatemeh",
				NormalizedName = "FATEMEH"
			},
			new IdentityRole
			{
				Name = "Administrator",
				NormalizedName = "ADMINISTRATOR"
			}
		);
	}
}