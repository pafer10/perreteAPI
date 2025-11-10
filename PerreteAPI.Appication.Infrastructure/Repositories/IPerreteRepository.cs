using PerreteAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerreteAPI.Appication.Infrastructure.Repositories
{
    public interface IPerreteRepository
    {
        Task<Perrete> GetAsync(Guid id);
        Task<IEnumerable<Perrete>> GetAllAsync();
        Task AddAsync(Perrete entity);
        void Update(Perrete entity);

        //Task<IEnumerable<Perrete>> GetAllAsync();
    }
}
