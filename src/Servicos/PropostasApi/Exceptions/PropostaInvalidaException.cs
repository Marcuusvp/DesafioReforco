using BuildingBlocks.Exceptions;

namespace PropostasApi.Exceptions
{
    public class PropostaInvalidaException : BadRequestException
    {
        public PropostaInvalidaException(string message) : base(message) { }
    }
}
