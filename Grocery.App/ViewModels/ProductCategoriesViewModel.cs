using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using Grocery.Core.Services;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace Grocery.App.ViewModels
{
    [QueryProperty(nameof(CategoryId), "categoryId")]
    public partial class ProductCategoriesViewModel : BaseViewModel
    {
        //private readonly IGroceryListItemsService _groceryListItemsService;
        private readonly IProductService _productService;
        private readonly IProductCategoryService _productCategoryService;
        private readonly ICategoryService _categoryService;
        //private readonly IFileSaverService _fileSaverService;
        private string searchText = "";

        public ObservableCollection<ProductCategory> MyCategoryItems { get; set; } = [];

        public ObservableCollection<Product> AvailableCategoryProducts { get; set; } = [];

        public ObservableCollection<Product> MyProducts { get; set; } = [];

        [ObservableProperty]
        Category currentCategory = new(0, "None");

        [ObservableProperty]
        string myMessage;

        public int CategoryId
        {
            set
            {
                CurrentCategory = _categoryService.Get(value);
                Load(CurrentCategory.Id);
            }
        }

        public ProductCategoriesViewModel(IProductCategoryService productCategoryService, IProductService productService, ICategoryService categoryService)
        {
            _productCategoryService = productCategoryService;
            _productService = productService;
            _categoryService = categoryService;
        }

        private void Load(int id)
        {
            MyCategoryItems.Clear();
            MyProducts.Clear();
            foreach (var item in _productCategoryService.GetAllInCategoryId(id)) MyCategoryItems.Add(item);
            foreach (var item in MyCategoryItems) MyProducts.Add(_productService.Get(item.ProductId));
            GetAvailableProducts();
        }

        private void GetAvailableProducts()
        {
            AvailableCategoryProducts.Clear();
            foreach (Product p in _productService.GetAll())
                if (MyCategoryItems.FirstOrDefault(c => c.ProductId == p.Id) == null && (searchText == "" || p.Name.ToLower().Contains(searchText.ToLower())))
                    AvailableCategoryProducts.Add(p);
        }

        private void OnCategoryChanged(Category value)
        {
            Load(value.Id);
        }

        [RelayCommand]
        public void AddProduct(Product product)
        {

            if (product == null) return;
            ProductCategory item = new ProductCategory(0, $"{currentCategory.Name}-{product.Name}", product.Id, currentCategory.Id);
            _productCategoryService.Add(item);
            AvailableCategoryProducts.Remove(product);
            OnCategoryChanged(CurrentCategory);
        }

        [RelayCommand]
        public void PerformSearch(string searchText)
        {
            this.searchText = searchText;
            GetAvailableProducts();
        }
    }
}
