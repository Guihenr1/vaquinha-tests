using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vaquinha.Domain.Interfaces.Repository;
using Vaquinha.Domain.ViewModels;
using Vaquinha.Repository.Context;

namespace Vaquinha.Repository.Repositories
{
    public class HomeInfoRepository : IHomeInfoRepository {
        private readonly VaquinhaOnlineDBContext _dbContext;

        public HomeInfoRepository(VaquinhaOnlineDBContext dbContext) {
            _dbContext = dbContext;
        }

        public async Task<HomeViewModel> RecuperarDadosIniciaisHomeAsync() {
            var totalDoadores = await _dbContext.Doacoes.CountAsync();
            var valorTotal = await _dbContext.Doacoes.SumAsync(a => a.Valor);

            return new HomeViewModel {
                ValorTotalArrecadado = valorTotal,
                QuantidadeDoadores = totalDoadores
            };
        }
    }
}