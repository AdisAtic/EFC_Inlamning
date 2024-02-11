using DataLayer.Contexts;
using DataLayer.Entities;

namespace DataLayer.Repositories
{
    public class CategoryRepository : Repo<CategoryEntity>
    {
        public CategoryRepository(DataContext context) : base(context)
        {
        }
    }
}
