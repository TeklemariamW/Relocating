using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IPersonRepository _personRep;
        private IAddressRepository _addressRep;
        public RepositoryWrapper(RepositoryContext repositoryContext) 
        { 
            _repoContext = repositoryContext;
        }
        public IPersonRepository Person
        { 
            get
            {
                if (_personRep== null)
                {
                    _personRep = new PersonRepository(_repoContext);
                }
                return _personRep;
            }
        }

        public IAddressRepository Address
        {
            get
            {
                if (_addressRep== null)
                {
                    _addressRep= new AddressRepository(_repoContext);
                }
                return _addressRep;
            }
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
