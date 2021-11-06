using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleLogger.api.Model;

namespace SimpleLogger.api.Data.Mappings
{
    public class ClientMapping : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.Property(c => c.CpfCnpj)
                .HasColumnType("varchar(200)");

            builder.Property(c => c.HostName)
                .HasColumnType("varchar(200)");

            builder.Property(c => c.Browser)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.OperationSystem)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.ClientAdress)
                .HasColumnType("varchar(200)");

            builder.Property(c => c.OperatorAddress)
                .HasColumnType("varchar(200)");

            builder.Property(c => c.ExternalAddress)
                .HasColumnType("varchar(200)");


            builder.ToTable("Clientes");
        }
    }
}
