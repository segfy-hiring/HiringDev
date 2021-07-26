using Joao.HiringDev.Dominio.Responses;
using System.ComponentModel.DataAnnotations;

namespace Joao.HiringDev.Apresentacao.Models.Home
{
    public class FiltroHomeViewModel
    {        
        [MaxLength(254)]
        [MinLength(1, ErrorMessage = "O campo não pode ser vazio!")]
        [Display(Name = "Pesquisar")]
        public string PalavraChave { get; set; }

        public YoutubeApiServicoResponse YoutubeApiServico { get; set;} 

        public FiltroHomeViewModel()
        {
            
        }


    }
}
