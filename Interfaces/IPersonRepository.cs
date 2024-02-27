using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetAllPersons();
        Person GetPersonById(Guid personId);
        void AddPerson(Person person);
    }
}
