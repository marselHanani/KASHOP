using KASHOP.DAL.DTO.Request;
using KASHOP.DAL.DTO.Response;
using KASHOP.DAL.Models;
using KASHOP.DAL.Repositories;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.BLL.Service
{
    public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepo = categoryRepository;

        public int CreateCategory(CategoryRequest request)
        {
            var category = request.Adapt<Category>();
            return _categoryRepo.save(category);
        }

        public int DeleteCategory(int id)
        {
            var category = _categoryRepo.findById(id);
            if (category == null)
            {
                throw new KeyNotFoundException($"Category with ID {id} not found.");
            }
            return _categoryRepo.remove(category);
        }

        public IEnumerable<CategoryResponse> GetAllCategories()
        {
            var categories = _categoryRepo.findAll();
            if (categories == null || !categories.Any())
            {
                return Enumerable.Empty<CategoryResponse>();
            }
            return categories.Adapt<IEnumerable<CategoryResponse>>();
        }

        public CategoryResponse? GetCategory(int id)
        {
            var category = _categoryRepo.findById(id);
            if (category == null)
            {
                throw new KeyNotFoundException($"Category with ID {id} not found.");
            }
            return category.Adapt<CategoryResponse>();
        }

        public int UpdateCategory(int id, CategoryRequest request)
        {
            var existingCategory = _categoryRepo.findById(id);
            if (existingCategory == null)
            {
                throw new KeyNotFoundException($"Category with ID {id} not found.");
            }
            existingCategory.Name = request.Name;
            return _categoryRepo.update(existingCategory);
        }

        public bool ToggleStatus(int id)
        {
            var category = _categoryRepo.findById(id);
            if (category == null) return false;
            category.Status = category.Status == Status.Active ? Status.Inactive : Status.Active;
            _categoryRepo.update(category);
            return true;
        }
    }
}
