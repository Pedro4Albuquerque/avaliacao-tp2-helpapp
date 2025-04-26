using HelpApp.Domain.Entities;
using HelpApp.Domain.Interfaces;
using HelpApp.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
namespace HelpApp.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _dbContext.Products
                .AsNoTracking()
                .OrderBy(product => product.Name)
                .ToListAsync();


        }

        public async Task<Product> GetById(int? id)
        {
            ValidateId(id);

            var product = await _dbContext.Products.FindAsync(id.Value);

            return product!;
        }

        public async Task<Product> Create(Product product)
        {
            ValidateProduct(product);

            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
            return product;
        }
        public async Task<Product> Update(Product product)
        {
            ValidateProduct(product);

            _dbContext.Products.Update(product);

            await _dbContext.SaveChangesAsync();

            return product;
        }
        public async Task<Product> Remove(Product product)
        {
            ValidateProduct(product);

            _dbContext.Products.Remove(product);

            await _dbContext.SaveChangesAsync();

            return product;
        }

        private void ValidateProduct(Product? product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product), "Product must be provided");
        }
        private void ValidateId(int? id)
        {
            if (!id.HasValue || id <= 0)
                throw new ArgumentException("Product Id must be a positive number", nameof(id));
        }

    }
}
