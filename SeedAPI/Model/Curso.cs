using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SeedAPI.Model
{
    public class Curso
    {
        [Key]
        public int CursoId { get; set; }
        public string nome { get; set; }
        public int CoordenadorId { get; set; }
        public Usuario Coordenador { get; set; }
    }
}
