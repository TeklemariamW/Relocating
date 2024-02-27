using Entities;
using Entities.Models;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
        public PersonRepository(RepositoryContext repositoryContext)
            :base(repositoryContext) 
        { 
        }

        public IEnumerable<Person> GetAllPersons()
        {
            return FindAll()
                .OrderBy(pe => pe.DateOfMoving)
                .ToList();
        }

        public Person GetPersonById(Guid id)
        {
            return FindByCondition(per => per.PersonId.Equals(id))
                .FirstOrDefault();
        }
        public void AddPerson(Person person)
        {
            Create(person);
        }
    }
}
