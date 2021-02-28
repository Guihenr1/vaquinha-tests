using System.Threading.Tasks;
using Vaquinha.Domain.ViewModels;

namespace Vaquinha.Domain.Interfaces.Repository
{
    public interface IHomeInfoRepository {
        Task<HomeViewModel> RecuperarDadosIniciaisHomeAsync();
    }
}