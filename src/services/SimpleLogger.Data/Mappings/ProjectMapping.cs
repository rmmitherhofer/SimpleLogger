using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleLogger.Business.Model;

namespace SimpleLogger.Data.Mappings
{
    public class ProjectMapping : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Type)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnType("varchar(200)");

            // 1 : N => Project : Logs
            builder.HasMany(p => p.Logs)
                .WithOne(l => l.Project);

            builder.ToTable("Projetos");
        }
    }
}
