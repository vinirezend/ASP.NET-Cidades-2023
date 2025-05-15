using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCidadeDAO
{
    public class UsuarioDAO
    {
        //-------------------------- Criar uma conexao --------------------------------------------
        public string GetConnectionString()
        {
            string conn = string.Format("server = {0}; uid = {1}; pwd = {2}; database = {3}; connect timeout = 10",
                @"MA294\SQLEXPRESS", "sa", "Micro!7958", "Banco Teste");
            return conn;
        }

        //-------------------------- Insere um novo usuario --------------------------------------------
        public int InsertUsuario(Usuario usuario)
        {
            int codigo = 0;
            string sql = "insert into tbUsuario (Nome, Login, Senha) OUTPUT Inserted.Codigo VALUES (@Nome, @Login, @Senha)";

            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = conn;
                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@Nome", usuario.Nome);
                    command.Parameters.AddWithValue("@Login", usuario.Login);
                    command.Parameters.AddWithValue("@Senha", usuario.Senha);

                    conn.Open();
                    codigo = (int)command.ExecuteScalar();
                    usuario.Codigo = codigo;
                }
            }

            return codigo;
        }

        //-------------------------- Retorna o usuario referente ao login --------------------------------------------

        public Usuario GetUsuario(string Login)
        {
            Usuario usuario = null;
            string sql = "select * from tbUsuario WHERE Login = @Login";

            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = conn;
                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@login", Login);

                    conn.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        if (reader.Read())
                        {
                            usuario = Db2Usuario(reader);
                        }
                    }
                }
            }
            return usuario;
        }

        private Usuario Db2Usuario(SqlDataReader reader)
        {
                return new Usuario()
                {
                    Codigo = (int)reader["Codigo"],
                    Nome = reader["Nome"].ToString(),
                    Login = reader["Login"].ToString(),
                    Senha = reader["Senha"].ToString()
                };
        }
    }
}
