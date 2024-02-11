using DataLayer.Contexts;
using DataLayer.Entities;

namespace DataLayer.Repositories
{
    public class AddressRepository : Repo<AddressEntity>
    {
        public AddressRepository(DataContext context) : base(context) 
        {
        }
    }
}
