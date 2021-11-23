using System;
using Electronics_store.Models;
using Electronics_store.Repositories.GenericRepository;

namespace Electronics_store.Repositories.CategoryRepository
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Category GetById(Guid id);
    }
}