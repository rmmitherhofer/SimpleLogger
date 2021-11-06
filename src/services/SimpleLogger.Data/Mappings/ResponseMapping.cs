using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleLogger.Business.Model;

namespace SimpleLogger.Data.Mappings
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

            builder.ToTable("Respostas");
        }
    }
}
