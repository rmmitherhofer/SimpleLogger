using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleLogger.Business.Model;

namespace SimpleLogger.Data.Mappings
{
    public class LogMapping : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            builder.HasKey(l => l.Id);

            builder.Property(l => l.Path)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(l => l.Level)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(l => l.Type)
                .IsRequired()
                .HasColumnType("varchar(60)");

            builder.Property(l => l.TimeProcess)
                .HasColumnType("varchar(200)"); //TODO

            builder.Property(l => l.RegisterDate)
                .IsRequired()
                .HasColumnType("datetime"); //TODO

            // 1 : 1 => Log : Client
            builder.HasOne(l => l.Client)
                .WithOne(c => c.Log);

            // 1 : 1 => Log : Request
            builder.HasOne(l => l.Request)
                .WithOne(req => req.Log);

            // 1 : 1 => Log : Response
            builder.HasOne(l => l.Response)
                .WithOne(resp => resp.Log);

            // 1 : N => Log : Errors
            builder.HasMany(l => l.Errors)
                .WithOne(e => e.Log);

            builder.ToTable("Logs");
        }
    }
}
