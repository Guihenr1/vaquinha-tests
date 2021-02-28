using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vaquinha.Domain.Entities;
using Vaquinha.Domain.Interfaces.Repository;
using Vaquinha.Repository.Context;

namespace Vaquinha.Repository.Repositories
{
    public class CausaRepository : ICausaRepository {
        private readonly VaquinhaOnlineDBContext _dbContext;

        public CausaRepository(VaquinhaOnlineDBContext dbContext) {
            _dbContext = dbContext;
        }

        public async Task<Causa> Adicionar(Causa causa) {
            await _dbContext.AddAsync(causa);
            await _dbContext.SaveChangesAsync();

            return causa;
        }

        public async Task<IEnumerable<Causa>> RecuperarCausas() {
            return await _dbContext.Causas.ToListAsync();
        }
    }
}