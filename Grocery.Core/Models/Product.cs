using CommunityToolkit.Mvvm.ComponentModel;

namespace Grocery.Core.Models
{
    public partial class Product : Model
    {
        [ObservableProperty]
        public int stock;

        public DateOnly ShelfLife { get; set; }

        [ObservableProperty]
        public double price;

        public Product(int id, string name, int stock) : this(id, name, stock, default, default) { }

        public Product(int id, string name, int stock, DateOnly shelfLife, double price = 2.00) : base(id, name)
        {
            Stock = stock;
            ShelfLife = shelfLife;
            Price = price;
        }

        public override string? ToString()
        {
            return $"{Name} - {Stock} op voorraad";
        }
    }
}
