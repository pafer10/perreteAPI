using Microsoft.EntityFrameworkCore;
using PerreteAPI.Appication.Infrastructure.Repositories;
using PerreteAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerreteAPI.Application.Infrastructure.Repositories
{
    //clase que implementa el interface
    public class PerreteRepository : IPerreteRepository
    {

        private readonly DataBaseContext _dbContext;

        public PerreteRepository(DataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Perrete>> GetAllAsync()
        {
            return await _dbContext.Perrete.ToListAsync();
        }

        async Task IPerreteRepository.AddAsync(Perrete entity)
        {
            await _dbContext.Perrete.AddAsync(entity);
        }

        async Task<Perrete?> IPerreteRepository.GetAsync(Guid id)
        {
            return await _dbContext.Perrete.FindAsync(id);
        }

        void IPerreteRepository.Update(Perrete entity)
        {
            _dbContext.Perrete.Update(entity);
        }
    }
}
