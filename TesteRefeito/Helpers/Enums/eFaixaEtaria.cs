using System.ComponentModel.DataAnnotations;

namespace TesteRefeito.Helpers.Enums
{
    public enum eFaixaEtaria
    {
        [Display(Name = "Livre")]
        Livre = 0,

        [Display(Name = "Maiores de 10 anos")]
        Maiores10 = 10,

        [Display(Name = "Maiores de 12 anos")]
        Maiores12 = 12,

        [Display(Name = "Maiores de 14 anos")]
        Maiores14 = 14,

        [Display(Name = "Maiores de 16 anos")]
        Maiores16 = 16,

        [Display(Name = "Maiores de 18 anos")]
        Maiores18 = 18
    }
}
