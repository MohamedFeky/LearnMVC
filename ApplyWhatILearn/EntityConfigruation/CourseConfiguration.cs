using ApplyWhatILearn.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ApplyWhatILearn.EntityConfigruation
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(c => c.Degree)
                   .HasMaxLength(50);

            builder.Property(c => c.MinDegree)
                   .HasMaxLength(50);
            builder.Property(c => c.Hours)
                   .HasMaxLength(50);

            // Relationships
            builder.HasMany(c => c.Instructors)
                   .WithOne(i => i.Course)
                   .HasForeignKey(c => c.CrsID)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
