using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCidadeDAO
{
    public class EstadoDAO
    {
        //--------------------------Criar uma conexao--------------------------------------------
        public string GetConnectionString()
        {
            string conn = string.Format("server = {0}; uid = {1}; pwd = {2}; database = {3}; connect timeout = 10",
                @"MA294\SQLEXPRESS", "sa", "Micro!7958", "Banco Teste");
            return conn;
        }
        //--------------------------Selecionar 1 objeto da tabela--------------------------------------------
        public Estado GetEstado(int codigo)
        {
            Estado estado = new Estado();
            string sql = "select * from tbEstado where CodigoEstado = @CodigoEstado";

            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = conn;
                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@CodigoEstado", codigo);

                    conn.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        estado = Db2Estado(reader);
                    }
                }
            }
            return estado;
        }

        //--------------------------Select Tabela toda--------------------------------------------
        public List<Estado> GetListEstado(Dictionary<string, string> filtros)
        {
            List<Estado> estados = new List<Estado>();
            string sql = "select * from tbEstado WHERE 1 = 1 ";
            if (filtros != null)
            {
                foreach (var filtro in filtros)
                {
                    sql += $@" {filtro.Value}";
                }
            }

            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = conn;
                    command.CommandText = sql;

                    conn.Open();
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            estados.Add(Db2Estado(reader));
                        }
                    }
                }
            }
            return estados;
        }

        //--------------------------Lista de estados conforme codigo do pais----------------------------
        public List<Estado> GetListEstadoEmPais(int codigoPais)
        {
            List<Estado> estados = new List<Estado>();
            string sql = "select * from tbEstado WHERE CodigoPais = @CodigoPais";

            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = conn;
                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@CodigoPais", codigoPais);

                    conn.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            estados.Add(Db2Estado(reader));
                        }
                    }
                }
            }
            return estados;
        }

        //--------------------------Insert--------------------------------------------
        public int InsertEstado(Estado estado)
        {
            int codigo = 0;
            string sql = "insert into tbEstado (NomeEstado, SiglaEstado, CodigoPais) OUTPUT Inserted.CodigoEstado VALUES (@NomeEstado, @SiglaEstado, @CodigoPais)";

            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = conn;
                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@NomeEstado", estado.NomeEstado);
                    command.Parameters.AddWithValue("@SiglaEstado", estado.SiglaEstado);
                    command.Parameters.AddWithValue("@CodigoPais", estado.CodigoPais);

                    conn.Open();
                    codigo = (int)command.ExecuteScalar();
                    estado.CodigoEstado = codigo;
                }
            }
            return codigo;
        }

        //--------------------------Delete--------------------------------------------
        public int DeleteEstado(int codigo)
        {
            string sql = "delete from tbEstado WHERE CodigoEstado = @CodigoEstado";

            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = conn;
                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@CodigoEstado", codigo);

                    conn.Open();
                    codigo = (int)command.ExecuteNonQuery();
                }
            }

            return codigo;
        }

        //--------------------------Update--------------------------------------------
        public void UpdateEstado(Estado estado)
        {
            string sql = "update tbEstado SET NomeEstado = @NomeEstado, SiglaEstado = @SiglaEstado, CodigoPais = @CodigoPais WHERE CodigoEstado = @CodigoEstado";

            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = conn;
                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@NomeEstado", estado.NomeEstado);
                    command.Parameters.AddWithValue("@SiglaEstado", estado.SiglaEstado);
                    command.Parameters.AddWithValue("@CodigoPais", estado.CodigoPais);
                    command.Parameters.AddWithValue("@CodigoEstado", estado.CodigoEstado);

                    conn.Open();
                    command.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        private Estado Db2Estado(SqlDataReader reader)
        {
            return new Estado()
            {
                CodigoEstado = (int)reader["CodigoEstado"],
                NomeEstado = reader["NomeEstado"].ToString(),
                CodigoPais = (int)reader["CodigoPais"],
                SiglaEstado = reader["SiglaEstado"].ToString()
            };
        }
    }
}
