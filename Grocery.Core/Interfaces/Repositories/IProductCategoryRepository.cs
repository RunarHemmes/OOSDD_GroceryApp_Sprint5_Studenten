using Grocery.Core.Models;

namespace Grocery.Core.Interfaces.Repositories
{
    public interface IProductCategoryRepository
    {
        public List<ProductCategory> GetAll();

        public List<ProductCategory> GetAllInCategoryId(int id);

        public ProductCategory? Get(int id);

        public ProductCategory? Delete(ProductCategory item);

        public ProductCategory? Update(ProductCategory item);

        public ProductCategory Add(ProductCategory item);
    }
}
