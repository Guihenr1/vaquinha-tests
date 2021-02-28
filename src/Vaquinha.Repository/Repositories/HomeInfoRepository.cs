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
            var totalDoadores = _dbContext.Doacoes.CountAsync();
            var valorTotal = _dbContext.Doacoes.SumAsync(a => a.Valor);

            return new HomeViewModel {
                ValorTotalArrecadado = await valorTotal,
                QuantidadeDoadores = await totalDoadores
            };
        }
    }
}