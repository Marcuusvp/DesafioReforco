using PropostasApi.Exceptions;

namespace PropostasApi.Dominio.Proposta.Aplicacao.CriarProposta
{
    public record CriarPropostaRequest(string Cpf, decimal Rendimento, PropostaEnderecoDto Endereco, string Telefone, string Email, string Agente, string Conveniada, int TipoOperacao);
    public record PropostaEnderecoDto(string Logradouro, string Bairro, string Cep, int Numero, string Cidade, string Estado, string? Complemento);
    public record CriarPropostaResponse(Guid Id);
    public class CriarPropostaEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/proposta", async (CriarPropostaRequest request, ISender sender) =>
            {
                var command = request.Adapt<CriarPropostaCommand>();

                var result = await sender.Send(command);

                if (result.IsFailure)
                {
                    throw new PropostaInvalidaException(result.Error);
                }

                var response = result.Adapt<CriarPropostaResponse>();

                return Results.Created($"/proposta/{response.Id}", response);
            }).WithName("Criar nova proposta")
            .Produces<CriarPropostaResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Adiciona uma proposta")
            .WithDescription("Criar proposta");
        }
    }
}
