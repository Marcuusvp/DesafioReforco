using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PropostasApi.Dominio.Proposta.Infra.Mapeamento
{
    public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Enderecos");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.CpfCliente)
                .IsRequired()
                .HasMaxLength(11)
                .HasColumnType("VARCHAR(11)");

            builder.Property(e => e.Bairro)
                .IsRequired()
                .HasColumnType("VARCHAR(200)");

            builder.Property(e => e.Numero)
                .IsRequired();

            builder.Property(e => e.Cep)
                .IsRequired()
                .HasColumnType("VARCHAR(8)");

            builder.Property(e => e.Cidade)
                .IsRequired()
                .HasColumnType("VARCHAR(200)");

            builder.Property(e => e.Estado)
                .IsRequired()
                .HasColumnType("VARCHAR(2)");

            builder.Property(e => e.Logradouro)
                .IsRequired()
                .HasColumnType("VARCHAR(200)");

            builder.Property(e => e.Complemento)
                .HasColumnType("VARCHAR(200)");
        }
    }
}
