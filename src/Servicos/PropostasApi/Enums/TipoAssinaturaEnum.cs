using System.ComponentModel;

namespace PropostasApi.Enums
{
    public enum ETipoAssinatura
    {
        [Description("Assinatura Eletrônica")]
        AssinaturaEletronica = 1,

        [Description("Assinatura Híbrida")]
        AssinaturaHibrida = 2,

        [Description("Assinatura Figital")]
        AssinaturaFigital = 3
    }
}
