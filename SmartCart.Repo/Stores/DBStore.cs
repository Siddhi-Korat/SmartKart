using Microsoft.EntityFrameworkCore;
using SmartCart.Repo.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartCart.Repo.Stores
{
    public class DBStore<T> : IStore<T> where T : class
    {
        SmartCartDBContext context;
        private DbSet<T> _entities;

        public DBStore(SmartCartDBContext _context)
        {
            this.context = _context;
        }

        protected DbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = this.context.Set<T>();
                return _entities;
            }
        }

        public async Task<int> Delete(int id)
        {
            var entity = await this.Entities.FindAsync(id);
            this.Entities.Remove(entity);

            var result = await this.context.SaveChangesAsync();
            return result;
        }

        public async Task<List<T>> GetAll()
        {
            var allitems = await this.Entities.ToListAsync();
            return allitems;
        }

        public Task<T> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<T> Insert(T data)
        {
            this.Entities.Add(data);
            var result = await this.context.SaveChangesAsync();
            return data;
        }

        public Task<T> Update(T data)
        {
            throw new NotImplementedException();
        }
    }
}
