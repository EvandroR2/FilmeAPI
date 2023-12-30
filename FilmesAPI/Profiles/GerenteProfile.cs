using AutoMapper;
using filmesAPI.Data.Dtos.Gerente;
using FilmesAPI.Data.Dtos.Gerente;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles
{
    public class GerenteProfile : Profile
    {
        public GerenteProfile() 
        {
            CreateMap<CreateGerenteDto, Gerente>();
            CreateMap<UpdateGerenteDto,Gerente>();
            CreateMap<Gerente, ReadGerenteDto>();
        }
        
    }
}
