using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PropostasApi.Dominio.Proposta.Infra.Mapeamento
{
    public class PropostaCreditoConfiguration : IEntityTypeConfiguration<PropostaCredito>
    {
        public void Configure(EntityTypeBuilder<PropostaCredito> builder)
        {
            builder.ToTable("PropostasCredito");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Cpf)
                .IsRequired()
                .HasColumnType("VARCHAR(11)");

            builder.Property(p => p.Rendimento)
                .IsRequired()
                .HasColumnType("DECIMAL(18,2)");

            builder.Property(p => p.Telefone)
                  .IsRequired()
                  .HasColumnType("VARCHAR(11)");

            builder.Property(p => p.Email)
                  .IsRequired()
                  .HasColumnType("VARCHAR(250)");

            builder.Property(p => p.Agente)
                  .IsRequired()
                  .HasColumnType("VARCHAR(10)");

            builder.Property(p => p.Conveniada)
                  .IsRequired()
                  .HasColumnType("VARCHAR(6)");

            // Configurar o relacionamento com Endereco
            builder.HasOne(p => p.Endereco)
                  .WithMany()
                  .HasForeignKey("EnderecoId")
                  .IsRequired();

            // Configurar o mapeamento da propriedade TipoAssinatura como um enum
            builder.Property(p => p.TipoAssinatura)
                  .HasConversion<int>();

            builder.Property(p => p.Ativa)
                  .IsRequired();

            builder.Property(p => p.NumeroParcelas)
                  .IsRequired();

            builder.Property(p => p.UltimaParcela)
                  .HasColumnType("DATE")
                  .IsRequired ();

            builder.Property(p => p.TipoOperacao)
                  .HasConversion<int>();
        }
    }
}
