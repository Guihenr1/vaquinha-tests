using System.Collections.Generic;
using System.Threading.Tasks;
using Vaquinha.Domain.ViewModels;

namespace Vaquinha.Domain.Interfaces.Service
{
    public interface IDoacaoService
    {
        Task RealizarDoacaoAsync(DoacaoViewModel model);
        Task<IEnumerable<DoadorViewModel>> RecuperarDoadoresAsync(int pageIndex = 0);
    }
}