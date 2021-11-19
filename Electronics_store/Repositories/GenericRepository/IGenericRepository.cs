using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Electronics_store.Models.Base;

namespace Electronics_store.Repositories.GenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity: BaseEntity
    {   
        //toata chestia cu <TEntity> where TEntity: BaseEntity inseamna ca acest repository o sa fie de forma generic repositorty 
        //si in <TEntity> o sa punem modelele noastre care toate au la baza acest BaseEntity, <TEntity> este o entitate generica
        
        
        //Get all data
        Task<List<TEntity>> GetAll();
        IQueryable<TEntity> GetAllAsQueryable(); //Queryable este ca o cerere in sql, ca un string cu select ...
        
        
        
        //Create 
        void Create(TEntity entity);
        Task CreateAsync(TEntity entity);
        void CreateRange(IEnumerable<TEntity> entities);
        Task CreateRangeAsync(IEnumerable<TEntity> entities);
        
        
        
        //Update
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);
        
        
        
        //Delete
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);
        
        
        
        //Find
        TEntity FindById(object id);
        Task<TEntity> FindByIdAsync(object id);
        
        
        
        //Save 
        bool Save(); 
        Task<bool> SaveAsync();
    }
}