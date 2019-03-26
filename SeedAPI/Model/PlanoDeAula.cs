using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SeedAPI.Model
{
    public class PlanoDeAula
    {
        [Key]
        public int PlanoId { get; set; }
        public string Descricao { get; set; }

        public PlanoDeAula()
        {

        }
        public PlanoDeAula(int planoId, string descricao)
        {
            PlanoId = planoId;
            Descricao = descricao;
        }
    }
}
