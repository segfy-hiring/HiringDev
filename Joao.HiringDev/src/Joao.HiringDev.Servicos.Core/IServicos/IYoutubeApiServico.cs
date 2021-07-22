using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Joao.HiringDev.Servicos.Core.IServicos
{
    public interface IYoutubeApiServico
    {
        Task Obter(string busca);
    }
}
