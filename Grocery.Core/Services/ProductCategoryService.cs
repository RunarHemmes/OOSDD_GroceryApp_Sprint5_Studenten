using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;

namespace Grocery.Core.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IProductRepository _productRepository;

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository, IProductRepository productRepository)
        {
            _productCategoryRepository = productCategoryRepository;
            _productRepository = productRepository;
        }

        public List<ProductCategory> GetAll()
        {
            return _productCategoryRepository.GetAll();
        }

        public List<ProductCategory> GetAllInCategoryId(int id)
        {
            List<ProductCategory> productCategories = _productCategoryRepository.GetAll().Where(p => p.CategoryId == id).ToList();
            //FillService(productCategories);
            return productCategories;
        }

        //private void FillService(List<ProductCategory> productCategories)
        //{
        //    foreach (ProductCategory p in productCategories)
        //    {
        //        p.
        //        //g.Product = _productRepository.Get(g.ProductId) ?? new(0, "", 0);
        //    }
        //}

        public ProductCategory? Get(int id)
        {
            return _productCategoryRepository.Get(id);
        }

        public ProductCategory? Delete(ProductCategory item)
        {
            throw new NotImplementedException();
        }

        public ProductCategory? Update(ProductCategory item)
        {
            return _productCategoryRepository.Update(item);
        }

        public ProductCategory Add(ProductCategory item)
        {
            return _productCategoryRepository.Add(item);
        }
    }
}
