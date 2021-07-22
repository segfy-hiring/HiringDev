using System.ComponentModel.DataAnnotations;

namespace Joao.HiringDev.Apresentacao.Models.Home
{
    public class FiltroHomeViewModel
    {
        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(254)]
        [MinLength(1, ErrorMessage = "O campo não pode ser vazio!")]
        [Display(Name = "Pesquisar")]
        public string PalavraChave { get; set; }

        public FiltroHomeViewModel()
        {

        }
    }
}
