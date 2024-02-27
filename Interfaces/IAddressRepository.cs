﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IAddressRepository : IRepositoryBase<Address>
    {
        IEnumerable<Address> GetAllAddresses();
        void AddAddress(Address address);
    }
}
