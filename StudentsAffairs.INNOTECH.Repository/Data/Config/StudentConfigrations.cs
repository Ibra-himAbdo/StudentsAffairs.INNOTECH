namespace StudentsAffairs.INNOTECH.Repository.Data.Config;

internal class StudentConfigrations : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.Property(S => S.FullName)
            .HasMaxLength(150)
            .IsRequired();
        builder.Property(S => S.NormalizedFullName)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(S => S.DateOfBirth)
            .IsRequired();

        builder.Property(S => S.Gender)
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(S => S.NormalizedGender)
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(S => S.Mobile)
            .HasMaxLength(15)
            .IsRequired();

        builder.Property(S => S.GradeLevel)
            .IsRequired();

        builder.HasOne(s => s.Department)
            .WithMany()
            .HasForeignKey(s => s.DepartmentId);
    }
}