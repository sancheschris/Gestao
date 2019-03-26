using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SeedAPI.Model
{
    public class Disciplina
    {
        public int DisciplinaId { get; set; }
        public string Nome { get; set; }
        public Curso Curso { get; set; }
        public int ProfessorId { get; set; }
        public Usuario Professor { get; set; }
        public PlanoDeEnsino PlanoDeEnsino { get; set; }
    }
}
