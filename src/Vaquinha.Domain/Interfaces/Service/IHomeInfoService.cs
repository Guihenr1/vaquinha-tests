using System.Collections.Generic;
using System.Threading.Tasks;
using Vaquinha.Domain.ViewModels;

namespace Vaquinha.Domain.Interfaces.Service
{
    public interface IHomeInfoService
    {
        Task<HomeViewModel> RecuperarDadosIniciaisHomeAsync();
        Task<IEnumerable<CausaViewModel>> RecuperarCausasAsync();
    }
}