using System.Collections.Generic;
using System.Threading.Tasks;
using Vaquinha.Domain.Entities;

namespace Vaquinha.Domain.Interfaces.Repository
{
    public interface IDoacaoRepository {
        Task AdicionarAsync(Doacao model);
        Task<IEnumerable<Doacao>> RecuperarDoadoesAsync(int pageIndex = 0);
    }
}