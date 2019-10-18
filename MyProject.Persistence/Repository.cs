using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyProject.Domain.Entities;
using MyProject.Domain.Interfaces;

namespace MyProject.Persistence
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly MyProjectDbContext _dbContext;

        public Repository(MyProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> GetById(Guid id)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IList<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task Add(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
