using PropostasApi.Dominio.Proposta;
using PropostasApi.Dominio.Proposta.Infra.Mapeamento;

namespace PropostasApi.Dominio
{
    public class PropostasDbContext : DbContext
    {
        public PropostasDbContext(DbContextOptions<PropostasDbContext> options): base(options) { }

        public DbSet<PropostaCredito> PropostasCredito { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Agente> Agentes { get; set; }
        public DbSet<Conveniada> Conveniadas { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            try
            {
                foreach (var item in ChangeTracker.Entries())
                {
                    if ((item.State == EntityState.Modified || item.State == EntityState.Added)
                        && item.Properties.Any(c => c.Metadata.Name == "DataUltimaAlteracao"))
                        item.Property("DataUltimaAlteracao").CurrentValue = DateTime.UtcNow;

                    if (item.State == EntityState.Added)
                        if (item.Properties.Any(c => c.Metadata.Name == "DataCadastro") && item.Property("DataCadastro").CurrentValue.GetType() != typeof(DateTime))
                            item.Property("DataCadastro").CurrentValue = DateTime.UtcNow;
                }
                var result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                return result;
            }
            catch (DbUpdateException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EnderecoConfiguration());
            modelBuilder.ApplyConfiguration(new PropostaCreditoConfiguration());
            modelBuilder.ApplyConfiguration(new PessoaConfiguration());
            modelBuilder.ApplyConfiguration(new AgenteConfiguration());
            modelBuilder.ApplyConfiguration(new ConveniadaConfiguration());
        }
    }
}
