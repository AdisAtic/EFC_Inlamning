using DataLayer.Contexts;
using DataLayer.Entities;

namespace DataLayer.Repositories
{
    public class RoleRepository : Repo<RoleEntity>
    {
        public RoleRepository(DataContext context) : base(context)
        {
        }
    }
}
