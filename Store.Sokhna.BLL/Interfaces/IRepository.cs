using Store.Sokhna.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Sokhna.BLL.Interfaces
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> Getall();
        Task<T?> GetById(int? Id);
        Task<int> Add(T entity);
        int Update(T entity);
        int Delete(T entity);
    }
}
