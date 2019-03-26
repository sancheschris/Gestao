using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SeedAPI.Model
{
    public class CursoDisciplina
    {
        [Key]
        public int CursoDisciplinaId { get; set; }
        public int CursoId { get; set; }
        public Curso Curso { get; set; }
        public int DisciplinaId { get; set; }
        public Disciplina Disciplina { get; set; }
    }

}
