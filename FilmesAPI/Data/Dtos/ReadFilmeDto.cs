using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Data.Dtos
{
    public class ReadFilmeDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O título é obrigatório!")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O diretor é obrigatório!")]
        public string Diretor { get; set; }

        [StringLength(35, ErrorMessage = "O genero não pode contar mais de 35 caracteres")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "A duração é obrigatória!")]
        [Range(1, 300, ErrorMessage = "A duração deve estar entre 1 e 300 minutos")]
        public int Duracao { get; set; }

        public DateTime HoraDaConsulta { get; set; }
    }
}
