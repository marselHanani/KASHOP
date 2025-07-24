using KASHOP.DAL.Models;

namespace KASHOP.DAL.Repositories
{
    public interface ICategoryRepository
    {
        int save(Category category);
        IEnumerable<Category> findAll(bool withTracking = false);
        Category findById(int id);
        int remove(Category category);
        int update(Category category);
    }
}
