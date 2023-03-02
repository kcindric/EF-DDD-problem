using EF.Domain.Departments;
using EF.Domain.Departments.ValueObjects;
using EF.Domain.Municipalities.ValueObjects;
using EF.Domain.Offices.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF.Infrastructure.Persistence.Configurations;

public class DepartmentConfigurations : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        ConfigureDepartmentTable(builder);
        ConfigureMunicipalityIdTable(builder);
    }

    private void ConfigureDepartmentTable(EntityTypeBuilder<Department> builder)
    {
        builder.ToTable(nameof(Department), nameof(Department));

        builder.HasKey(d => d.Id);

        builder.Property(d => d.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => DepartmentId.Create(value));

        builder.Property(d => d.OfficeId)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => OfficeId.Create(value));
    }

    private void ConfigureMunicipalityIdTable(EntityTypeBuilder<Department> builder)
    {
        builder.OwnsMany(d => d.MunicipalityIds, municipalityIdBuilder =>
        {
            municipalityIdBuilder.ToTable(nameof(MunicipalityId), nameof(Department));
        
            municipalityIdBuilder.WithOwner().HasForeignKey(nameof(DepartmentId));
        
            municipalityIdBuilder.HasKey("Id"); // shadow id property
        
            municipalityIdBuilder.Property(mid => mid.Value)
                .HasColumnName(nameof(MunicipalityId))
                .ValueGeneratedNever();
        });

        builder.Metadata.FindNavigation(nameof(Department.MunicipalityIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}