namespace PropostasApi.Dominio.Proposta
{
    public record Pessoa(string Cpf, DateOnly DataNascimento, bool Bloqueado);
}
