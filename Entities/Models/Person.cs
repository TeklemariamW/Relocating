using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models;

public class Person
{
    public Guid PersonId { get; set; }
    [Required(ErrorMessage = "First Name if required")]
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    [Required(ErrorMessage = "Email is required")]
    public string? Email { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime DateOfMoving { get; set; }
    public int TelefonNumber { get; set; }


    [ForeignKey(nameof(Address))]
    public Guid AddressId { get; set; }
    //public Address? Address { get; set; }
}
