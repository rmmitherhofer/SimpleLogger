using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleLogger.api.Model;

namespace SimpleLogger.api.Data.Mappings
{
    public class ResponseMapping : IEntityTypeConfiguration<Response>
    {
        public void Configure(EntityTypeBuilder<Response> builder)
        {
            builder.Property(r => r.StatusCode)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(r => r.Headers)
                .HasColumnType("varchar(max)"); //TODO

            builder.Property(r => r.Sise)
                .IsRequired()
                .HasColumnType("varchar(10)"); //TODO

            builder.ToTable("Respostas");
        }
    }
}
