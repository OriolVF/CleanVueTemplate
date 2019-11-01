using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MyProject.Domain.Entities;

namespace MyProject.Domain.Interfaces
{
    public interface IRepository<T> where T : IEntity
    {
        Task<T> GetById(Guid id);
        Task<IList<T>> GetAll();
        Task Add(T entity);
    }
}
