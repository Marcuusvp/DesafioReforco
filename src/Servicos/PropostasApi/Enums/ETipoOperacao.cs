using System.ComponentModel;

namespace PropostasApi.Enums
{
    public enum ETipoOperacao
    {
        [Description("Refin")]
        Refin = 1,

        [Description("Novo")]
        Novo = 2,

        [Description("Portabilidade")]
        Portabilidade = 3
    }
}
