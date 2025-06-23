using ApplyWhatILearn.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ApplyWhatILearn.EntityConfigruation
{
    public class TraineeConfiguration : IEntityTypeConfiguration<Trainee>
    {
        public void Configure(EntityTypeBuilder<Trainee> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(t => t.ImagUrl)
                   .HasMaxLength(200);

            builder.Property(t => t.Address)
                   .HasMaxLength(500);

            builder.Property(t => t.Grade)
                   .HasMaxLength(50);
        }
    }
}
