using KASHOP.DAL.DTO.Request;
using KASHOP.DAL.DTO.Response;
using KASHOP.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.BLL.Service
{
    public interface ICategoryService
    {
        int CreateCategory(CategoryRequest request);
        CategoryResponse? GetCategory(int id);

        IEnumerable<CategoryResponse> GetAllCategories();

        int UpdateCategory(int id, CategoryRequest request);

        int DeleteCategory(int id);
        bool ToggleStatus(int id);
    }
}
