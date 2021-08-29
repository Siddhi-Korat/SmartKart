using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartCart.Repo.Stores
{
    public interface IStore<T> where T : class
    {
        public Task<T> Insert(T data);
        public Task<T> GetById(int id);
        public Task<T> Update(T data);
        public Task<int> Delete(int id);
        public Task<List<T>> GetAll();
    }
}
