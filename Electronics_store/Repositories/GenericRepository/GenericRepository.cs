using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Electronics_store.Data;
using Electronics_store.Models.Base;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Electronics_store.Repositories.GenericRepository
{
    public class GenericRepository <TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly ElectronicsStoreContext _context;
        protected readonly DbSet<TEntity> _table;

        public GenericRepository(ElectronicsStoreContext context)
        {
            _context = context;
            _table = _context.Set<TEntity>();
        }
        
        
        
        //Get all
        public async Task<List<TEntity>> GetAll()
        {
            //face select in baza de date
            return await _table.AsNoTracking().ToListAsync(); //AsNoTracking este bine sa il folosim cand luam toate datele fara sa le modificam(doar vrem sa le afisam nu si sa le facem update) + e bun pt performanta
            //cand facem ToListAsync() imi face deja selectul in baza de date
        }

        public IQueryable<TEntity> GetAllAsQueryable() //nu e recomandat sa folosim IQueryable
        {
            return _table.AsNoTracking();

            //try not to use toList, Ccount, etc before filtering the data
            //var entityList = _table.ToList();
            //var entityListFiltered = _table.Where(x => x.Id.ToString() != "");


            //better version the data is filtered in the query
            //select * from entity where Id is not null
            //var entitylistFiltered = _table.Where(x => x.Id.ToString() != "").ToList();
        }
        
        
        
        //Create
        public void Create(TEntity entity)
        {
            _table.Add(entity);
        }
        
        public async Task CreateAsync(TEntity entity)
        {
            await _table.AddAsync(entity); //punem mereu await cand avem cv asincron
        }

        public void CreateRange(IEnumerable<TEntity> entities)
        {
            _table.AddRange(entities);
        }
        
        public async Task CreateRangeAsync(IEnumerable<TEntity> entities)
        {
            await _table.AddRangeAsync(entities);
        }
        
        
        
        //Update
        public void Update(TEntity entity)
        {
            _table.Update(entity);
        }
        
        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            _table.UpdateRange(entities);
        }
        
        
        
        //Delete
        public void Delete(TEntity entity)
        {
            _table.Remove(entity);
        }
        
        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            _table.RemoveRange(entities);
        }
        
        
        
        //Find
        public TEntity FindById(object id)
        {
            return _table.Find(id);
            
            //alta optiune
            //return _table.FirstOrDefault(x => x.Id.Equals(id));
        }
        
        public async Task<TEntity> FindByIdAsync(object id)
        {
            return await _table.FindAsync(id);
            
            //alta optiune
            //return await _table.FirstOrDefault(x => x.Id.Equals(id));
        }
        
        
        
        //Save
        public bool Save()
        {
            try
            {
                return _context.SaveChanges() > 0;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
            }
            return false;
        }
        
        public async Task<bool> SaveAsync()
        {
            try
            {
                return await _context.SaveChangesAsync() > 0;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
            }
            return false;
        }

    }
}