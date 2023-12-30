using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos.Cinema
{
    public class UpdateCinemaDto
    {

        [Required(ErrorMessage = "O Campo de nome é obrigatorio")]
        public string Nome { get; set; }

    }
}
