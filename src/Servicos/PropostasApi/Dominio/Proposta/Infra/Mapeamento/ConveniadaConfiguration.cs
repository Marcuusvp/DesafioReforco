using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PropostasApi.Dominio.Proposta.Infra.Mapeamento
{
    public class ConveniadaConfiguration : IEntityTypeConfiguration<Conveniada>
    {
        public void Configure(EntityTypeBuilder<Conveniada> builder)
        {
            builder.ToTable("Conveniadas");

            builder.HasKey(a => a.CodigoConveniada);

            builder.Property(a => a.CodigoConveniada)
                .IsRequired()
                .HasColumnType("VARCHAR(6)");

            builder.Property(a => a.Descricao)
                .IsRequired()
                .HasColumnType("VARCHAR(20)");

            builder.Property(a => a.PermiteRefin)
                .IsRequired();
        }
    }
}
