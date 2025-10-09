using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Models;

namespace Grocery.Core.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly List<Category> categories = new List<Category>();

        public CategoryRepository()
        {
            categories = [
                new Category(1, "Zuivel"),
                new Category(2, "Granen")
                ];
        }

        public List<Category> GetAll()
        {
            return categories;
        }

        public void Add(Category item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Category item)
        {
            throw new NotImplementedException();
        }

        public Category? Get(int id)
        {
            Category? category = categories.FirstOrDefault(c => c.Id == id);
            return category;
        }

        public Category? Update(Category item)
        {
            Category? category = categories.FirstOrDefault(c => c.Id == item.Id);
            category = item;
            return category;
        }
    }
}
