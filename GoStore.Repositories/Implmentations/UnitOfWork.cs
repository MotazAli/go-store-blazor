using GoStore.Data.Database;
using GoStore.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoStore.Repositories.Implmentations
{
    public class UnitOfWork : IUnitOfWork
    {
        
        private CategoryRepository _categoryRepository = null!;
        private readonly GoStoreDbContext _dbContext;

        public UnitOfWork(GoStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ICategoryRepository CategoryRepository => _categoryRepository ??= new (_dbContext);

        public async Task<int> SaveAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
