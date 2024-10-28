using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PropostasApi.Dominio.Proposta.Infra.Mapeamento
{
    public class AgenteConfiguration : IEntityTypeConfiguration<Agente>
    {
        public void Configure(EntityTypeBuilder<Agente> builder)
        {
            builder.ToTable("Agentes");

            builder.HasKey(a => a.CodigoAgente);

            builder.Property(a => a.CodigoAgente)
                .IsRequired()
                .HasColumnType("VARCHAR(10)");

            builder.Property(a => a.Ativo)
                .IsRequired();
        }
    }
}
