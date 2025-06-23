using ApplyWhatILearn.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ApplyWhatILearn.EntityConfigruation
{
    public class CrsResultConfiguration : IEntityTypeConfiguration<CrsResult>
    {
        public void Configure(EntityTypeBuilder<CrsResult> builder)
        {
            builder.HasKey(cr => cr.Id);

            builder.Property(cr => cr.Degree)
                   .HasMaxLength(50);

            // Relationships
            builder.HasOne(cr => cr.Course)
                   .WithMany(c => c.CrsResults)
                   .HasForeignKey(cr => cr.CrsId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(cr => cr.Trainee)
                   .WithMany(t => t.CrsResults)
                   .HasForeignKey(cr => cr.TraineeId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Unique index for the many-to-many relationship
            builder.HasIndex(cr => new { cr.CrsId, cr.TraineeId }).IsUnique();
        }
    }

}
