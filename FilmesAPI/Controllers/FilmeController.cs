using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos.Filme;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        #region Limpar porque agora não é lista, e sim banco de dados
        //private static List<Filme> filmes = new List<Filme>();
        //private static int id = 1;
        #endregion

        private AppDbContext _context;
        private IMapper _mapper;

        public FilmeController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
        {

            #region Modo Antigo sem Automapper
            //filme.Id = id++;
            //filmes.Add(filme);

            //Filme filme = new Filme
            //{
            //    Titulo = filmeDto.Titulo,
            //    Diretor = filmeDto.Diretor,
            //    Genero = filmeDto.Genero,
            //    Duracao = filmeDto.Duracao,
            //};
            #endregion

            Filme filme = _mapper.Map<Filme>(filmeDto);
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaFilmesPorId), new { Id = filme.Id }, filme );
        }

        [HttpGet]
        public IEnumerable<Filme> RecuperaFilmes()
        {
            //return Ok(filmes); não faz parte de lista
            return _context.Filmes;
        }

        #region Jeito Antigo de fazer


        //[HttpPost]
        //public void AdicionaFilme([FromBody] Filme filme)
        //{
        //    filme.Id = id++;
        //    filmes.Add(filme);
        //}

        //[HttpGet]
        //public IEnumerable<Filme> RecuperaFilmes()
        //{
        //    return filmes;
        //}


        //[HttpGet("{id}")]
        //public Filme RecuperaFilmesPorId(int id)
        //{
        //    foreach (Filme filme in filmes){
        //        if (filme.Id == id)
        //        {
        //            return filme;
        //        }
        //    }
        //    return null;
        //}
        #endregion

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmesPorId(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme != null)
            {
                #region Modo Antigo sem AutoMapper
                //ReadFilmeDto filmeDto = new ReadFilmeDto
                //{
                //    Titulo = filme.Titulo,
                //    Diretor = filme.Diretor,
                //    Genero = filme.Genero,
                //    Duracao = filme.Duracao,
                //    HoraDaConsulta = DateTime.Now
                //};
                //return Ok(filmeDto);
                #endregion
                ReadFilmeDto filmeDto = _mapper.Map<ReadFilmeDto>(filme);
                return Ok(filmeDto);
            }
            return NotFound();

        }

        [HttpPut("{id}")]
        public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
        {
            #region Modo Antigo sem AutoMapper
            //Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            //if(filme == null)
            //{
            //    return NotFound();
            //}
            //filme.Titulo = filmeDto.Titulo;
            //filme.Diretor = filmeDto.Diretor;
            //filme.Genero = filmeDto.Genero;
            //filme.Duracao = filmeDto.Duracao;
            //_context.SaveChanges();
            //return NoContent();
            #endregion

            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
            {
                return NotFound();
            }
            _mapper.Map(filmeDto, filme);
            _context.SaveChanges();
            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult DeletaFilme(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
            {
                return NotFound();
            }
            _context.Remove(filme);
            _context.SaveChanges();
            return NoContent();


        }


    }
}
