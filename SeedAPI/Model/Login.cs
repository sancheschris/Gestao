using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SeedAPI.Model
{
    public class Login
    {
        [Key]
        public int LoginId { get; set; }
        public string Nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public string confirmsenha { get; set; }


        public static bool ValidarUsuario(string login, string senha)
        {
            var ret = false;

            using (var conexao = new SqlConnection())
            {
                conexao.ConnectionString = "";
                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = string.Format(
                        "select count(*) from usuario where login='{0}' and senha '{1}'", login, senha);
                    ret = ((int)comando.ExecuteScalar() > 0);
                }
            }

            return ret;
        }
        
    }
}
