using GoStore.Data.Models;
using GoStore.Repositories.Interfaces;
using GoStore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoStore.Services.Implementations
{
    public class CategoryService :ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Category> AddAsync(Category category, CancellationToken cancellationToken)
        {
            var insertResult = await _unitOfWork.CategoryRepository.InsertAsync(category, cancellationToken);
            var saveResult = await _unitOfWork.SaveAsync(cancellationToken);
            if (saveResult <= 0) throw new Exception("Server Unavailable");

            return insertResult;
        }

        public async Task<Category> DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var deletedResult = await _unitOfWork.CategoryRepository.DeleteByIdAsync(id, cancellationToken);
            var saveResult = await _unitOfWork.SaveAsync(cancellationToken);
            if (saveResult <= 0) throw new Exception("Server Unavailable");

            return deletedResult;
        }

        public async Task<IEnumerable<Category>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _unitOfWork.CategoryRepository.SelectAllAsync(cancellationToken);
        }

        public async Task<Category?> GetOneByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _unitOfWork.CategoryRepository.SelectOneByIdAsync(id, cancellationToken);
        }

        public async Task<Category> UpdateByIdAsync(Guid id, Category category, CancellationToken cancellationToken)
        {
            var updatedResult = await _unitOfWork.CategoryRepository.UpdateByIdAsync(id,category, cancellationToken);
            var saveResult = await _unitOfWork.SaveAsync(cancellationToken);
            if (saveResult <= 0) throw new Exception("Server Unavailable");

            return updatedResult;
        }
    }
}
