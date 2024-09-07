namespace StudentsAffairs.INNOTECH.Repository.Data.Config;

internal class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.Property(C => C.Name)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(C => C.NormalizedName)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(C => C.Code)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(C => C.Credits)
            .HasMaxLength(10)
            .IsRequired();

        builder.HasOne(c => c.Department)
           .WithMany()
           .HasForeignKey(c => c.DepartmentId);

    }
}
