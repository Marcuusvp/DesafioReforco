using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PropostasApi.Dominio.Proposta.Infra.Mapeamento
{
    public class PessoaConfiguration : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("Pessoas");

            builder.HasKey(p => p.Cpf);

            builder.Property(p => p.Cpf)
                .IsRequired()
                .HasColumnType("VARCHAR(11)");

            builder.Property(p => p.DataNascimento)
                .IsRequired()
                .HasColumnType("DATE");

            builder.Property(p => p.Bloqueado)
                .IsRequired();
        }
    }
}
