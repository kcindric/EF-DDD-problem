using EF.Domain.Departments.ValueObjects;
using EF.Domain.Municipalities;
using EF.Domain.Municipalities.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF.Infrastructure.Persistence.Configurations;

public class MunicipalityConfigurations : IEntityTypeConfiguration<Municipality>
{
    public void Configure(EntityTypeBuilder<Municipality> builder)
    {
        ConfigureMunicipalityTable(builder);
    }

    private void ConfigureMunicipalityTable(EntityTypeBuilder<Municipality> builder)
    {
        builder.ToTable(nameof(Municipality), nameof(Municipality));

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => MunicipalityId.Create(value));

        builder.Property(m => m.DepartmentId)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => DepartmentId.Create(value));
    }
}