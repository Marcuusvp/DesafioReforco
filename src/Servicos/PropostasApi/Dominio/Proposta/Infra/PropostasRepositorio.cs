namespace PropostasApi.Dominio.Proposta.Infra
{
    public sealed class PropostasRepositorio(PropostasDbContext dbContext) : IService<PropostasRepositorio>
    {
        public async Task<bool> CpfBloqueado (string cpf)
        {
            var result = await dbContext.Database.GetDbConnection()
                .QueryFirstOrDefaultAsync<string>("SELECT cpf FROM Pessoas WHERE cpf = @cpf and Bloqueado = 1", new { cpf });

            return result == cpf;
        }

        public async Task<bool> AgenteAtivo (string codigoAgente)
        {
            var result = await dbContext.Database.GetDbConnection()
                .QueryFirstOrDefaultAsync<string>("SELECT CodigoAgente FROM Agentes WHERE CodigoAgente = @codigoAgente and Ativo = 1", new { codigoAgente });

            return result == codigoAgente;
        }

        public async Task<bool> ClientePossuiPropostaAtiva(string cpf)
        {
            var result = await dbContext.Database.GetDbConnection()
                .QueryFirstOrDefaultAsync<string>("SELECT Cpf FROM PropostasCredito WHERE Cpf = @cpf and Ativa = 1", new { cpf });

            return result == cpf;
        }

        public async Task<Maybe<Conveniada>> BuscarConveniada (string codigo, CancellationToken cancellationToken)
        {
            var conveniada = await dbContext.Conveniadas.FirstOrDefaultAsync(c => c.CodigoConveniada == codigo, cancellationToken);
            return conveniada ?? Maybe<Conveniada>.None;
        }
        public async Task GravarProposta(PropostaCredito propostaCredito, CancellationToken cancellationToken)
        {
            await dbContext.PropostasCredito.AddAsync(propostaCredito, cancellationToken);
        }

        public Task Save()
        {
            return dbContext.SaveChangesAsync();
        }
    }
}
