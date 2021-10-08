using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IAsyncRepository<T> where T : BaseEntity
    {
        Task<T> GetById(int id);
        Task<List<T>> ListAll();
        Task<T> Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);

    }
}
