using HelpApp.Domain.Entities;
using HelpApp.Domain.Interfaces;
using HelpApp.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace HelpApp.Infra.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _dbContext.Categories
                .AsNoTracking()
                .OrderBy(category => category.Name)
                .ToListAsync();


        }

        public async Task<Category> GetById(int? id)
        {
            ValidateId(id);

            var category = await _dbContext.Categories.FindAsync(id.Value);

            return category!;
        }

        public async Task<Category> Create(Category category)
        {
            ValidateCategory(category);

            _dbContext.Categories.Add(category);

            await _dbContext.SaveChangesAsync();

            return category;
        }
        public async Task<Category> Update(Category category)
        {
            ValidateCategory(category);

            _dbContext.Categories.Update(category);

            await _dbContext.SaveChangesAsync();

            return category;
        }
        public async Task<Category> Remove(Category category)
        {
            ValidateCategory(category);

            _dbContext.Categories.Remove(category);

            await _dbContext.SaveChangesAsync();

            return category;
        }

        private void ValidateCategory(Category? category)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category), "Category must be provided");
        }
        private void ValidateId(int? id)
        {
            if (!id.HasValue || id <= 0)
                throw new ArgumentException("Category Id must be a positive number", nameof(id));
        }

    }
}
