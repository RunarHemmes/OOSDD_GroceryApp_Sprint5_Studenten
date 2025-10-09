using Grocery.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Core.Interfaces.Services
{
    public interface ICategoryService
    {
        public List<Category> GetAll();

        public Category? Get(int id);

        public Category? Update(Category category);

        public void Add(Category category);

        public void Delete(Category category);
    }
}
