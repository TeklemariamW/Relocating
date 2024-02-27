using Entities.Models;
using Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RelocatingServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IRepositoryWrapper _repo;
        public  AddressController(IRepositoryWrapper repositoryWrapper) 
        { 
            _repo = repositoryWrapper;
        }

        [HttpGet]
        public IActionResult GetAddresses() 
        { 
            try
            {
                var Addresses = _repo.Address.GetAllAddresses();
                return Ok(Addresses);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddAddress([FromBody]Address address)
        {
            if (address == null)
            {
                return BadRequest("Address object is null");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("Address model is not valid");
            }

            _repo.Address.AddAddress(address);
            _repo.Save();

            return Ok();
        }
    }
}
