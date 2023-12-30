using FilmesAPI.Models;
using System;
using System.ComponentModel.DataAnnotations;


namespace fimesAPI.Data.Dtos
{
    public class ReadCinemaDto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O Campo de nome é obrigatorio")]
        public string Nome { get; set; }

        public Endereco Endereco { get; set; }

        public Gerente Gerente { get; set; }
    }
}
