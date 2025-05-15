using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjetoCidadeDAO
{
    public class CidadeDAO
    {
        //--------------------------Criar uma conexao--------------------------------------------
        public string GetConnectionString()
        {
            string conn = string.Format("server = {0}; uid = {1}; pwd = {2}; database = {3}; connect timeout = 10",
                @"MA294\SQLEXPRESS", "sa", "Micro!7958", "Banco Teste");
            return conn;
        }

        //--------------------------Select 1 objeto da tabela--------------------------------------------
        public Cidade GetCidade(int codigo)
        {
            Cidade cidade = new Cidade();
            string sql = "select * from tbCidade where CodigoCidade = @CodigoCidade";

            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = conn;
                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@CodigoCidade", codigo);

                    conn.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        cidade = Db2Cidade(reader);
                    }
                }
            }
            return cidade;
        }

        //--------------------------Select Tabela *Toda com Filtros*--------------------------------------------
        public List<Cidade> GetListCidade(Dictionary<string, string> filtros)
        {
            List<Cidade> cidades = new List<Cidade>();
            string sql = "select * from tbCidade WHERE 1 = 1 ";
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
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cidades.Add(Db2Cidade(reader));
                        }
                    }
                }
            }
            return cidades;
        }
        //--------------------------Lista de cidades conforme codigo do estado----------------------------
        public List<Cidade> GetListCidadeEmEstado(int codigoEstado)
        {
            List<Cidade> cidades = new List<Cidade>();
            string sql = "select * from tbCidade WHERE CodigoEstado = @CodigoEstado";

            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = conn;
                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@CodigoEstado", codigoEstado);

                    conn.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cidades.Add(Db2Cidade(reader));
                        }
                    }
                }
            }
            return cidades;
        }
            //--------------------------Insert--------------------------------------------
        public int InsertCidade(Cidade cidade)
        {
            int codigo = 0;
            string sql = "insert into tbCidade (Nome, CodigoEstado) OUTPUT Inserted.CodigoCidade VALUES (@Nome, @CodigoEstado)";

            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = conn;
                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@Nome", cidade.Nome);
                    command.Parameters.AddWithValue("@CodigoEstado", cidade.CodigoEstado);

                    conn.Open();
                    codigo = (int)command.ExecuteScalar();
                    cidade.CodigoCidade = codigo;
                }
            }

            return codigo;
        }

        //--------------------------Delete--------------------------------------------
        public int DeleteCidade(int codigo)
        {
            string sql = "delete from tbCidade WHERE CodigoCidade = @CodigoCidade";

            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = conn;
                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@CodigoCidade", codigo);

                    conn.Open();
                    codigo = (int)command.ExecuteNonQuery();
                }
            }
            return codigo;
        }

        //--------------------------Update--------------------------------------------
        public void UpdateCidade(Cidade cidade)
        {
            string sql = "update tbCidade SET Nome = @Nome, CodigoEstado = @CodigoEstado WHERE CodigoCidade = @CodigoCidade";

            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = conn;
                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@Nome", cidade.Nome);
                    command.Parameters.AddWithValue("@CodigoEstado", cidade.CodigoEstado);
                    command.Parameters.AddWithValue("@CodigoCidade", cidade.CodigoCidade);

                    conn.Open();
                    command.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }


        private Cidade Db2Cidade(SqlDataReader reader)
        {
            return new Cidade()
            {
                CodigoCidade = (int)reader["CodigoCidade"],
                Nome = reader["Nome"].ToString(),
                CodigoEstado = (int)reader["CodigoEstado"]
            };
        }
    }
}
