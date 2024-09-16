using Microsoft.EntityFrameworkCore;
using Pharmaease.Database;
using Pharmaease.Repository.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pharmaease.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly PharmaDBContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(PharmaDBContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return await _dbSet.FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        // Implementando a versão síncrona de GetById
        public T GetById(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return _dbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        // Removendo métodos não implementados
        //public IEnumerable<T> GetAll()
        //{
        //    throw new NotImplementedException();
        //}

        //public void Add(T entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Delete(T entity)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
