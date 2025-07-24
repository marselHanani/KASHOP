using KASHOP.DAL.Data;
using KASHOP.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.DAL.Repositories
{
    public class CategoryRepository(ApplicationDbContext context):ICategoryRepository
    {
        private readonly ApplicationDbContext context = context;

        public int remove(Category category)
        {
            context.Remove(category);
            return context.SaveChanges();
        }

        public int update(Category category)
        {
            context.Update(category);
            return context.SaveChanges();
        }

        IEnumerable<Category> ICategoryRepository.findAll(bool withTracking = false)
        {
            if (withTracking)
            {
                return context.Categories.ToList();
            }
            return context.Categories.AsNoTracking().ToList();
        }

        Category ICategoryRepository.findById(int id) => context.Categories.Find(id);

        int ICategoryRepository.save(Category category)
        {
            context.Categories.Add(category);
            return context.SaveChanges();
        }
    }
}
