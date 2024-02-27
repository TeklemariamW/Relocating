using AutoMapper;
using Entities.DTO;
using Entities.Models;
using Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RelocatingServer.Controllers
{
    [Route("api/Person")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IRepositoryWrapper _repository;
        private IMapper _mapper;
        public PersonsController(ILoggerManager loggerManager, IRepositoryWrapper repositoryWrapper, IMapper mapper) 
        { 
            _logger = loggerManager;
            _repository = repositoryWrapper;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllPersons()
        {
            try
            {
                var persons = _repository.Person.GetAllPersons();

               // _logger.LogInfo($"Returned all owners from thek database.");
               var personResult = _mapper.Map<IEnumerable<PersonDto>>(persons);

                return Ok(personResult);
            }
            catch (Exception ex)
            {
               // _logger.LogError($"Something went wrong inside GetAllPersons action: {ex.Message}");

                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("id")]
        public IActionResult GetPersonById(Guid id)
        {
            try
            {
                var person = _repository.Person.GetPersonById(id);

                if (person == null)
                {
                    return NotFound();
                }

                var personResult = _mapper.Map<PersonDto>(person);
                return Ok(personResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddPerson([FromBody]Person person)
        {
            if (person == null)
            {
                return BadRequest("Person object is null");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }

            _repository.Person.AddPerson(person);
            _repository.Save();

            return Ok();
        }
    }
}
