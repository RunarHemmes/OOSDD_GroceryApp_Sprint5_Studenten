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
    [QueryProperty(nameof(Category), nameof(Category))]
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

        [ObservableProperty]
        Category currentCategory = new Category(0, "None");

        [ObservableProperty]
        string myMessage;

        public ProductCategoriesViewModel(IProductCategoryService productCategoryService, IProductService productService, ICategoryService categoryService)
        {
            _productCategoryService = productCategoryService;
            _productService = productService;
            _categoryService = categoryService;
            //_fileSaverService = fileSaverService;
            Load(currentCategory.Id);
        }

        private void Load(int id)
        {
            MyCategoryItems.Clear();
            foreach (var item in _productCategoryService.GetAllInCategoryId(id)) MyCategoryItems.Add(item);
            GetAvailableProducts();
        }

        private void GetAvailableProducts()
        {
            AvailableCategoryProducts.Clear();
            foreach (Product p in _productService.GetAll())
                if (MyCategoryItems.FirstOrDefault(c => c.ProductId == p.Id) == null && p.Stock > 0 && (searchText == "" || p.Name.ToLower().Contains(searchText.ToLower())))
                    AvailableCategoryProducts.Add(p);
        }

        private void OnCategoryChanged(Category value)
        {
            Load(value.Id);
        }

        //[RelayCommand]
        //public async Task ChangeColor()
        //{
        //    Dictionary<string, object> paramater = new() { { nameof(GroceryList), GroceryList } };
        //    await Shell.Current.GoToAsync($"{nameof(ChangeColorView)}?Name={GroceryList.Name}", true, paramater);
        //}

        [RelayCommand]
        public void AddProduct(Product product)
        {
            //if (product == null) return;
            //GroceryListItem item = new(0, GroceryList.Id, product.Id, 1);
            //_groceryListItemsService.Add(item);
            //product.Stock--;
            //_productService.Update(product);
            //AvailableProducts.Remove(product);
            //OnGroceryListChanged(GroceryList);

            if (product == null) return;
            ProductCategory item = new ProductCategory(0, $"{currentCategory.Name}-{product.Name}", product.Id, currentCategory.Id);
            _productCategoryService.Add(item);
            AvailableCategoryProducts.Remove(product);
            OnCategoryChanged(CurrentCategory);
        }

        //[RelayCommand]
        //public async Task ShareGroceryList(CancellationToken cancellationToken)
        //{
        //    if (GroceryList == null || MyGroceryListItems == null) return;
        //    string jsonString = JsonSerializer.Serialize(MyGroceryListItems);
        //    try
        //    {
        //        await _fileSaverService.SaveFileAsync("Boodschappen.json", jsonString, cancellationToken);
        //        await Toast.Make("Boodschappenlijst is opgeslagen.").Show(cancellationToken);
        //    }
        //    catch (Exception ex)
        //    {
        //        await Toast.Make($"Opslaan mislukt: {ex.Message}").Show(cancellationToken);
        //    }
        //}

        [RelayCommand]
        public void PerformSearch(string searchText)
        {
            this.searchText = searchText;
            GetAvailableProducts();
        }

        //[RelayCommand]
        //public void IncreaseAmount(int productId)
        //{
        //    GroceryListItem? item = MyGroceryListItems.FirstOrDefault(x => x.ProductId == productId);
        //    if (item == null) return;
        //    if (item.Amount >= item.Product.Stock) return;
        //    item.Amount++;
        //    _groceryListItemsService.Update(item);
        //    item.Product.Stock--;
        //    _productService.Update(item.Product);
        //    OnGroceryListChanged(GroceryList);
        //}

        //[RelayCommand]
        //public void DecreaseAmount(int productId)
        //{
        //    GroceryListItem? item = MyGroceryListItems.FirstOrDefault(x => x.ProductId == productId);
        //    if (item == null) return;
        //    if (item.Amount <= 0) return;
        //    item.Amount--;
        //    _groceryListItemsService.Update(item);
        //    item.Product.Stock++;
        //    _productService.Update(item.Product);
        //    OnGroceryListChanged(GroceryList);
        //}
    }
}
