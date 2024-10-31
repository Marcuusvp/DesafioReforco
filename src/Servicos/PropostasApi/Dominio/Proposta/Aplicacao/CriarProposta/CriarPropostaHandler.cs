using FluentValidation;
using PropostasApi.Dominio.Proposta.Infra;
using PropostasApi.Exceptions;

namespace PropostasApi.Dominio.Proposta.Aplicacao.CriarProposta
{
    public record CriarPropostaCommand(string Cpf, decimal Rendimento, PropostaEndereco Endereco, string Telefone, string Email, string Agente, string Conveniada, int TipoOperacao) : ICommand<Result<CriarPropostaResult>>;
    public record PropostaEndereco(string Logradouro, string Bairro, string Cep, int Numero, string Cidade, string Estado, string? Complemento);
    public record CriarPropostaResult(Guid Id);

    public class CreatePropostaCommandValidator : AbstractValidator<CriarPropostaCommand>
    {
        public CreatePropostaCommandValidator()
        {
            RuleFor(p => p.Email).NotEmpty().WithMessage("Um E-mail para contato é obrigatório");
            RuleFor(p => p.Telefone).NotEmpty().WithMessage("Telefone deve conter 11 digitos").Length(11).WithMessage("Telefone deve conter 11 digitos");
            RuleFor(p => p.Rendimento).GreaterThan(0).WithMessage("Cliente deve informar um rendimento");
            RuleFor(p => p.Endereco).NotEmpty().WithMessage("Informe um endereço");
            RuleFor(p => p.Cpf).NotEmpty().WithMessage("Cpf deve ser informado").Length(11).WithMessage("Cpf deve conter 11 digitos");
        }
    }

    internal class CriarPropostaHandler(PropostasRepositorio propostasRepositorio) : ICommandHandler<CriarPropostaCommand, Result<CriarPropostaResult>>
    {
        public async Task<Result<CriarPropostaResult>> Handle(CriarPropostaCommand command, CancellationToken cancellationToken)
        {
            var clienteBloqueado = await propostasRepositorio.CpfBloqueado(command.Cpf);
            if (clienteBloqueado)
                return Result.Failure<CriarPropostaResult>("Cliente bloqueado");

            var clienteComPropostaAberta = await propostasRepositorio.ClientePossuiPropostaAtiva(command.Cpf);
            if (clienteComPropostaAberta)
                return Result.Failure<CriarPropostaResult>("Cliente possui proposta ativa");

            var agenteAtivo = await propostasRepositorio.AgenteAtivo(command.Agente);
            if (!agenteAtivo)
                return Result.Failure<CriarPropostaResult>("Agente inativo");

            var conveniada = await propostasRepositorio.BuscarConveniada(command.Conveniada, cancellationToken);

            var clienteAdress = Endereco.CriarEndereco
                (cpfCliente: command.Cpf,
                logradouro: command.Endereco.Logradouro,
                bairro: command.Endereco.Bairro,
                cep: command.Endereco.Cep,
                numero: command.Endereco.Numero,
                cidade: command.Endereco.Cidade,
                estado: command.Endereco.Estado,
                complemento: command.Endereco.Complemento);

            var propostaCredito = PropostaCredito.CriarProposta
                (cpf: command.Cpf,
                rendimento: command.Rendimento,
                endereco: clienteAdress.Value,
                telefone: command.Telefone,
                email: command.Email,
                agente: command.Agente,
                conveniada: conveniada.Value,
                tipoOperacao: command.TipoOperacao);

            if (propostaCredito.IsFailure)
                return Result.Failure<CriarPropostaResult>(propostaCredito.Error);

            await propostasRepositorio.GravarProposta(propostaCredito.Value, cancellationToken);
            await propostasRepositorio.Save();

            return Result.Success(new CriarPropostaResult(propostaCredito.Value.Id));
        }
    }
}
