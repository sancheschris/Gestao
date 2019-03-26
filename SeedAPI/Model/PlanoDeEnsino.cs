using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SeedAPI.Model
{
    public class PlanoDeEnsino
    {
        [Key]
        public int PlanoDeEnsinoId { get; set; }
        public string Descricao { get; set; }
        public Disciplina Disciplina { get; set; }

        public PlanoDeEnsino()
        {

        }
        public PlanoDeEnsino(int planoDeEnsinoId, string descricao, Disciplina disciplina)
        {
            PlanoDeEnsinoId = planoDeEnsinoId;
            Descricao = descricao;
            Disciplina = disciplina;
        }
    }
}
