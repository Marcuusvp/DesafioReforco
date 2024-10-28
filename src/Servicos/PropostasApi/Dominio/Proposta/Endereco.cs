using System.ComponentModel.DataAnnotations;

namespace PropostasApi.Dominio.Proposta
{
    public sealed class Endereco
    {
        public Guid Id { get; }
        [Required(ErrorMessage = "Endereço deve ser vinculado a um cpf")]
        public string CpfCliente { get; }
        public string Logradouro { get; } = default!;
        public string Bairro { get; } = default!;
        public string Cep { get; } = default!;
        public int Numero { get; }
        public string Cidade { get; } = default!;
        public string Estado { get; } = default!;
        public string? Complemento { get; }

        private Endereco() { }
        private Endereco(string cpfCliente, string logradouro, string bairro, string cep, int numero, string cidade, string estado, string? complemento)
        {
            Id = Guid.NewGuid();
            CpfCliente = cpfCliente;
            Logradouro = logradouro;
            Bairro = bairro;
            Cep = cep;
            Numero = numero;
            Cidade = cidade;
            Estado = estado;
            Complemento = complemento;
        }
        public static Result<Endereco> CriarEndereco(string cpfCliente, string logradouro, string bairro, string cep, int numero, string cidade, string estado, string? complemento)
        {
            var endereco = new Endereco(cpfCliente: cpfCliente, logradouro: logradouro, bairro: bairro, cep: cep, numero: numero, cidade: cidade, estado: estado, complemento: complemento);
            return Result.Success(endereco);
        }
    }
}
