using GoStore.Data.Database;
using GoStore.Data.Models;
using GoStore.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoStore.Repositories.Implmentations
{
    internal class CategoryRepository : ICategoryRepository
    {

        private readonly GoStoreDbContext _dbContext;

        public CategoryRepository(GoStoreDbContext dbContext) 
        {
            _dbContext = dbContext;
        }


        public async Task<Category> InsertAsync(Category category, CancellationToken cancellationToken)
        {
            category.CreatedAt =  category.UpdatedAt = DateTime.UtcNow;
            var insertResult = await _dbContext.Categories.AddAsync(category, cancellationToken);
            return insertResult.Entity;
        }

        public async Task<Category> DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var oldCategory = await SelectOneByIdAsync(id , cancellationToken);
            if (oldCategory is null) throw new Exception($"Category with id {id} not found");

            _dbContext.Categories.Remove(oldCategory);
            return oldCategory;
        }

        public async Task<IEnumerable<Category>> SelectAllAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.Categories.ToListAsync(cancellationToken);
        }

        public async Task<Category?> SelectOneByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _dbContext.Categories.FirstOrDefaultAsync( c => c.Id == id, cancellationToken);
        }

        public async Task<Category> UpdateByIdAsync(Guid id, Category category, CancellationToken cancellationToken)
        {
            var oldCategory = await SelectOneByIdAsync(id, cancellationToken);
            if (oldCategory is null) throw new Exception($"Category with id {id} not found");

            oldCategory.Name = category.Name;
            oldCategory.UpdatedAt = DateTime.UtcNow;
            _dbContext.Entry<Category>(oldCategory).State = EntityState.Modified;
            return oldCategory;
        }
    }
}
