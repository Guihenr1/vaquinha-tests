using System.Collections.Generic;
using System.Threading.Tasks;
using Vaquinha.Domain.ViewModels;

namespace Vaquinha.Domain.Interfaces.Payment
{
    public interface IPaymentService {
        Task<IEnumerable<CausaViewModel>> RecuperarInstituicoesAsync(int page = 0);
        Task AdicionadDoacaoAsync(DoacaoViewModel doacao);
    }
}