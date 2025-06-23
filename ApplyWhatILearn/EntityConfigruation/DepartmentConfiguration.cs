using ApplyWhatILearn.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ApplyWhatILearn.EntityConfigruation
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(d => d.Name)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(d => d.Manager)
                   .HasMaxLength(150);

            // Relationships
            builder.HasMany(d => d.Instructors)
                   .WithOne(i => i.Department)
                   .HasForeignKey(i => i.DeptId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(d => d.Courses)
                   .WithOne(c => c.Department)
                   .HasForeignKey(c => c.DeptId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(d => d.Trainees)
                   .WithOne(t => t.Department)
                   .HasForeignKey(t => t.DeptId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
