﻿using System;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos.Endereco
{
    public class ReadEnderecoDto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string Logradouro { get; set; }

        public string Bairro { get; init; }

        public int Numero { get; set; }

        public DateTime HoraDaConsulta { get; set; }
    }
}
