using System.Collections.Generic;
using System.Threading.Tasks;
using Vaquinha.Domain.ViewModels;

namespace Vaquinha.Domain.Interfaces.Service
{
    public interface ICausaService
    {
        Task Adicionar(CausaViewModel model);
        Task<IEnumerable<CausaViewModel>> RecuperarCausas();
    }
}