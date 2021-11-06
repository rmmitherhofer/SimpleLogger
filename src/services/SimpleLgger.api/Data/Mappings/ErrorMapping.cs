using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleLogger.api.Model;

namespace SimpleLogger.api.Data.Mappings
{
    public class ErrorMapping : IEntityTypeConfiguration<Error>
    {
        public void Configure(EntityTypeBuilder<Error> builder)
        {

            builder.Property(e => e.Type)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(e => e.Message)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(e => e.Tracer)
                .IsRequired()
                .HasColumnType("varchar(max)");

            builder.ToTable("Erros");
        }
    }
}
