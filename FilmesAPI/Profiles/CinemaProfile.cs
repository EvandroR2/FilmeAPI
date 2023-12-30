using AutoMapper;
using filmesAPI.Data.Dtos;
using FilmesAPI.Data.Dtos.Cinema;
using FilmesAPI.Models;
using fimesAPI.Data.Dtos;

namespace FilmesAPI.Profiles
{
    public class CinemaProfile : Profile
    {
        public CinemaProfile()
        {
            CreateMap<CreateCinemaDto, Cinema>();
            CreateMap<UpdateCinemaDto, Cinema>();
            CreateMap<Cinema, ReadCinemaDto>();

        }

    }
}
