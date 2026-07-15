
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseManager.Domain.Entities;
using WarehouseManager.Domain.Enums;

namespace WarehouseManager.Infrastructure.Persistance.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedNever();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(x => x.Name)
                .IsUnique();

            builder.HasMany(x => x.Users)
                .WithOne(x => x.Role)
                .HasForeignKey(x => x.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(GetSeedRoles());
        }

        private static IEnumerable<Role> GetSeedRoles()
        {
            return Enum.GetValues<RoleName>()
                .Select(name => new Role
                {
                    Id = RoleId(name),
                    Name = name
                });
        }
        private static Guid RoleId(RoleName name) =>
            new((int)name, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
    }
}
