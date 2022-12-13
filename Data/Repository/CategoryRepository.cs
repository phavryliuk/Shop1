using System.Collections.Generic;
using Shop1.Data.interfaces;
using Shop1.Data.Models;

namespace Shop1.Data.Repository
{
    public class CategoryRepository : ICarsCategory
    {
        private readonly AppDbContent appDbContent;

        public  CategoryRepository(AppDbContent appDbContent)
        {
            this.appDbContent = appDbContent;
        }

        public IEnumerable<Category> AllCategories => appDbContent.Category;
    }
}
