using Entities;
using Entities.Models;
using Interfaces;

namespace Repository
{
    public class AddressRepository : RepositoryBase<Address>, IAddressRepository
    {
        public AddressRepository(RepositoryContext repositoryContext)
        :base(repositoryContext)
        { }

        public IEnumerable<Address> GetAllAddresses()
        {
            return FindAll()
                .OrderBy(ad => ad.AddressId)
                .ToList();
        }

        public void AddAddress(Address address)
        {
            Create(address);
        }
    }
}
