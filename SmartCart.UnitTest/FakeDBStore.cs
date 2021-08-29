using SmartCart.Repo.Stores;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartCart.UnitTest
{
    public class FakeDBStore<T> : IStore<T> where T : class
    {
        public List<T> list = new List<T>();
        public int IdCounter { get; set;} = 0;
        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAll()
        {
            return Task.FromResult(list);
        }

        public Task<T> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> Insert(T data)
        {
            list.Add(data);
            IdCounter++;
            return Task.FromResult(data);
        }

        public Task<T> Update(T data)
        {
            throw new NotImplementedException();
        }
    }
}
