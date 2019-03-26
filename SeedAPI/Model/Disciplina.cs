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
        public int PlanoDeEnsinoId { get; set; }
        public PlanoDeEnsino PlanoDeEnsino { get; set; }

        public Disciplina()
        {
                
        }
        public Disciplina(int disciplinaId, string nome, Curso curso, int professorId, Usuario professor, int planoDeEnsinoId, PlanoDeEnsino planoDeEnsino)
        {
            DisciplinaId = disciplinaId;
            Nome = nome;
            Curso = curso;
            ProfessorId = professorId;
            Professor = professor;
            PlanoDeEnsinoId = planoDeEnsinoId;
            PlanoDeEnsino = planoDeEnsino;
        }
    }
}
