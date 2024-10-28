using PropostasApi.Enums;
using System.ComponentModel.DataAnnotations;

namespace PropostasApi.Dominio.Proposta
{
    public sealed class PropostaCredito
    {
        public Guid Id { get; }
        public string Cpf { get; } = default!;
        public decimal Rendimento { get; }
        public Endereco Endereco { get; }
        public string Telefone { get; } = default!;
        public string Email { get; } = default!;
        public ETipoAssinatura TipoAssinatura { get; private set; }
        public bool Ativa { get; }
        public string Agente { get; } = default!;
        public string Conveniada { get; } = default!;
        public ETipoOperacao TipoOperacao { get; }
        public int NumeroParcelas { get; }
        public DateOnly UltimaParcela {  get; } = default!;

        private PropostaCredito() { }
        private PropostaCredito(string cpf, decimal rendimento, Endereco endereco, string telefone, string email, string agente, string conveniada, ETipoOperacao tipoOperacao)
        {
            Id = Guid.NewGuid();
            Cpf = cpf;
            Rendimento = rendimento;
            Endereco = endereco;
            Telefone = telefone;
            Email = email;
            Agente = agente;
            Conveniada = conveniada;
            TipoOperacao = tipoOperacao;
        }

        public static Result<PropostaCredito> CriarProposta(string cpf, decimal rendimento, Endereco endereco, string telefone, string email, string agente, Conveniada conveniada, int tipoOperacao)
        {
            var novaProposta = new PropostaCredito(cpf: cpf, rendimento: rendimento, endereco: endereco, telefone: telefone, email: email, agente: agente, conveniada: conveniada.CodigoConveniada, tipoOperacao: (ETipoOperacao)tipoOperacao);
            return Result.Success(novaProposta);
        }

        public void SetarAssinatura(ETipoAssinatura tipo)
        {
            TipoAssinatura = tipo;
        }
    }
}
