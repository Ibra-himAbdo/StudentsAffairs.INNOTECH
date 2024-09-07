namespace StudentsAffairs.INNOTECH.Repository.Data.Config;

internal class AttendanceConfiguration : IEntityTypeConfiguration<Attendance>
{
    public void Configure(EntityTypeBuilder<Attendance> builder)
    {
        builder.Property(a => a.AttendanceDate)
       .IsRequired();

        builder.Property(a => a.Status)
            .HasMaxLength(10)
            .IsRequired();

        builder.HasOne(a => a.Enrollment)
            .WithMany(E => E.Attendances)
            .HasForeignKey(a => a.EnrollmentId);
    }
}
