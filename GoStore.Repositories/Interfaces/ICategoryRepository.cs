using GoStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoStore.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        public Task<IEnumerable<Category>> SelectAllAsync(CancellationToken cancellationToken);
        public Task<Category?> SelectOneByIdAsync(Guid id ,CancellationToken cancellationToken);
        public Task<Category> InsertAsync(Category category,CancellationToken cancellationToken);
        public Task<Category> UpdateByIdAsync(Guid id , Category category , CancellationToken cancellationToken);
        public Task<Category> DeleteByIdAsync(Guid id, CancellationToken cancellationToken);

    }
}
