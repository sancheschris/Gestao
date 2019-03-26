using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SeedAPI.Model
{
    public class Turma
    {
        [Key]
        public int TurmaId { get; set; }
        public Usuario Professor { get; set; }
        public int CursoDisciplinaId { get; set; }
        public CursoDisciplina CursoDisciplina { get; set; }
        public PlanoDeAula PlanoDeAula { get; set; }

        public Turma()
        {

        }
        public Turma(int turmaId, Usuario professor, int cursoDisciplinaId, CursoDisciplina cursoDisciplina, PlanoDeAula planoDeAula)
        {
            TurmaId = turmaId;
            Professor = professor;
            CursoDisciplinaId = cursoDisciplinaId;
            CursoDisciplina = cursoDisciplina;
            PlanoDeAula = planoDeAula;
        }
    }
}
