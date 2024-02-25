using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IRepositoryWrapper
    {
        IPersonRepository Person { get; }
        IAddressRepository Address { get; }
        void Save();
    }
}
