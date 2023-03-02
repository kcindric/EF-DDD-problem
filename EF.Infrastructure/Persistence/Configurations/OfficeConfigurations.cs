using EF.Domain.Departments.ValueObjects;
using EF.Domain.Offices;
using EF.Domain.Offices.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF.Infrastructure.Persistence.Configurations;

public class OfficeConfigurations : IEntityTypeConfiguration<Office>
{
    public void Configure(EntityTypeBuilder<Office> builder)
    {
        ConfigureOfficeTable(builder);
        ConfigureDepartmentIdTable(builder);
    }

    private void ConfigureOfficeTable(EntityTypeBuilder<Office> builder)
    {
        builder.ToTable(nameof(Office), nameof(Office));
        
        builder.HasKey(o => o.Id);
        
        builder.Property(o => o.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => OfficeId.Create(value));
    }

    private void ConfigureDepartmentIdTable(EntityTypeBuilder<Office> builder)
    {
        builder.OwnsMany(o => o.DepartmentIds, departmentIdBuilder =>
        {
            departmentIdBuilder.ToTable(nameof(DepartmentId), nameof(Office));
            
            departmentIdBuilder.WithOwner().HasForeignKey(nameof(OfficeId));
            
            departmentIdBuilder.HasKey("Id"); // shadow id property
            
            departmentIdBuilder.Property(did => did.Value)
                .HasColumnName(nameof(DepartmentId))
                .ValueGeneratedNever();
        });

        builder.Metadata.FindNavigation(nameof(Office.DepartmentIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}