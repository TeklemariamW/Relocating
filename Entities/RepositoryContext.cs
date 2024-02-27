using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities;

public class RepositoryContext: DbContext
{
    public RepositoryContext(DbContextOptions options)
        :base(options)
    { 
    }

    public DbSet<Address> addresses { get; set; }
    public DbSet<Person> persons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>()
            .ToContainer("Addresses")
            .HasPartitionKey(a => a.AddressId);

        modelBuilder.Entity<Person>()
            .ToContainer("Persons")
            .HasPartitionKey(p => p.PersonId);
            
    }
}
