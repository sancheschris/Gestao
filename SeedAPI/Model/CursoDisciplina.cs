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
        //public int DisciplinaId { get; set; }
        [ForeignKey("DisciplinaId")]
        public Disciplina Disciplina { get; set; }

        public CursoDisciplina()
        {

        }

        public CursoDisciplina(int cursoDisciplinaId, int cursoId, Curso curso, int disciplinaId, Disciplina disciplina)
        {
            CursoDisciplinaId = cursoDisciplinaId;
            CursoId = cursoId;
            Curso = curso;
            Disciplina = disciplina;
        }
    }

}
