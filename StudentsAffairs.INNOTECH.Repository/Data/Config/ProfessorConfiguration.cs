namespace StudentsAffairs.INNOTECH.Repository.Data.Config;

internal class ProfessorConfiguration : IEntityTypeConfiguration<Professor>
{
    public void Configure(EntityTypeBuilder<Professor> builder)
    {
        builder.Property(P => P.FullName)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(P => P.NormalizedFullName)
           .HasMaxLength(150)
           .IsRequired();

        builder.HasOne(p => p.Department)
           .WithMany()
           .HasForeignKey(p => p.DepartmentId);
    }
}
