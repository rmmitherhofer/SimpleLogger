using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleLogger.Business.Model;

namespace SimpleLogger.Data.Mappings
{
    public class RequestMapping : IEntityTypeConfiguration<Request>
    {
        public void Configure(EntityTypeBuilder<Request> builder)
        {

            builder.Property(r => r.Method)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(r => r.Uri)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(r => r.UserAgent)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(r => r.Headers)
                .HasColumnType("varchar(max)");

            builder.Property(r => r.Body)
                .HasColumnType("varchar(max)");

            builder.ToTable("Requisicoes");
        }
    }
}
