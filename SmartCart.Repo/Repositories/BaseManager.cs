using SmartCart.Repo.Repositories.Interfaces;
using SmartCart.Repo.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCart.Repo.Repositories
{
    public class BaseManager<T> : IBaseManager<T> where T : class
    {
        protected IStore<T> store;
        public BaseManager(IStore<T> store)
        {
            this.store = store;
        }
        public async Task<bool> Delete(int id)
        {
            var result = await this.store.Delete(id);
            return result > 0;
        }

        public async Task<List<T>> GetAll()
        {
            var items = await this.store.GetAll();
            return items.ToList();
        }

        public Task<T> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<T> Insert(T data)
        {
            var item = await this.store.Insert(data);

            return item;
        }

        public Task<T> Update(T data)
        {
            throw new NotImplementedException();
        }
    }
}
