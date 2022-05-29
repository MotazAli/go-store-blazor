using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoStore.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        public ICategoryRepository CategoryRepository { get; }
        Task<int> SaveAsync(CancellationToken cancellationToken = default);
    }
}
