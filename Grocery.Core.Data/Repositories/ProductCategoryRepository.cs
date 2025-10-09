using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Models;

namespace Grocery.Core.Data.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly List<ProductCategory> productCategories;

        public ProductCategoryRepository()
        {
            productCategories = [
                new ProductCategory(1, "Zuivel_Kaas", 2, 1),
                new ProductCategory(2, "Zuivel_Melk", 1, 1),
                new ProductCategory(3, "Granen_Brood", 3, 2),
                new ProductCategory(4, "Granen_Conflakes", 4, 2)
                ];
        }

        public List<ProductCategory> GetAll()
        {
            return productCategories;
        }

        public List<ProductCategory> GetAllInCategoryId(int id)
        {
            return productCategories.Where(p => p.CategoryId == id).ToList();
        }

        public ProductCategory? Get(int id)
        {
            return productCategories.FirstOrDefault(p => p.Id == id);
        }

        public ProductCategory Add(ProductCategory item)
        {
            int Id = productCategories.Max(p => p.Id);
            item.Id = Id;
            productCategories.Add(item);
            return Get(item.Id);
        }

        public ProductCategory? Delete(ProductCategory item)
        {
            throw new NotImplementedException();
        }

        public ProductCategory? Update(ProductCategory item)
        {
            ProductCategory productCategory = productCategories.FirstOrDefault(p => p.Id == item.Id);
            productCategory = item;
            return productCategory;
        }
    }
}
