﻿using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos.Endereco
{
    public class CreateEnderecoDto
    {

        public string Logradouro { get; set; }

        public string Bairro { get; init; }

        public int Numero { get; set; }

    }
}
