using ApplyWhatILearn.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ApplyWhatILearn.EntityConfigruation
{
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Name)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(i => i.ImagUrl)
                .HasMaxLength(200);

            builder.Property(i => i.Salary)
                   .HasMaxLength(200);

            builder.Property(i => i.Address)
                   .HasMaxLength(500);


        }
    }

}
