using GoStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoStore.Services.Interfaces
{
    public interface ICategoryService
    {
        public Task<IEnumerable<Category>> GetAllAsync(CancellationToken cancellationToken);
        public Task<Category?> GetOneByIdAsync(Guid id, CancellationToken cancellationToken);
        public Task<Category> AddAsync(Category category, CancellationToken cancellationToken);
        public Task<Category> UpdateByIdAsync(Guid id, Category category, CancellationToken cancellationToken);
        public Task<Category> DeleteByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
