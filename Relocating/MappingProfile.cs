using AutoMapper;
using Entities.DTO;
using Entities.Models;

namespace RelocatingServer
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            //Mapping From -----> To
            CreateMap<Person, PersonDto>();
        }
    }
}
