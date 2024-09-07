namespace StudentsAffairs.INNOTECH.Repository.Data.Config;

internal class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.Property(d => d.Name)
       .HasMaxLength(100)
       .IsRequired();

        builder.Property(d => d.NormalizedName)
       .HasMaxLength(100)
       .IsRequired();
    }
}
