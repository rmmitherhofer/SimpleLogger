using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleLogger.Business.Model;

namespace SimpleLogger.Data.Mappings
{
    public class ClientMapping : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.Property(c => c.HostName)
                .HasColumnType("varchar(200)");

            builder.Property(c => c.Browser)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.OperationSystem)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.ClientAddress)
                .HasColumnType("varchar(200)");

            builder.Property(c => c.OperatorAddress)
                .HasColumnType("varchar(200)");

            builder.Property(c => c.ExternalAddress)
                .HasColumnType("varchar(200)");


            builder.ToTable("Clientes");
        }
    }
}
