using SeedAPI.Model.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeedAPI.Model
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public Privilegio Privilegio { get; set; }
        public string Titulacao { get; set; }

        public Usuario()
        {

        }
        public Usuario(int id, string nome, string email, string senha, Privilegio privilegio, string titulacao)
        {
            UsuarioId = id;
            Nome = nome;
            Email = email;
            Senha = senha;
            Privilegio = privilegio;
            Titulacao = titulacao;
        }


        
    }
}
