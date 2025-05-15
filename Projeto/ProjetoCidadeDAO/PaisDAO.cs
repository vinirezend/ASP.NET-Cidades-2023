using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ProjetoCidadeDAO
{
    public class PaisDAO
    {
        //--------------------------------------------Criar uma conexao--------------------------------------------
        public string GetConnectionString()
        {
            string conn = string.Format("server = {0}; uid = {1}; pwd = {2}; database = {3}; connect timeout = 10",
                @"MA294\SQLEXPRESS", "sa", "Micro!7958", "Banco Teste");
            return conn;
        }

        //--------------------------------------------Select 1 objeto da tabela--------------------------------------------
        public Pais GetPais(int codigo)
        {
            Pais pais = new Pais();
            string sql = "select * from tbPais where CodigoPais = @CodigoPais";

            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = conn;
                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@CodigoPais", codigo);

                    conn.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        pais = Db2Pais(reader);
                    }
                }
            }
            return pais;
        }

        //--------------------------------------------Select Tabela Toda--------------------------------------------
        public List<Pais> GetListPais(Dictionary<string, string> filtros)
        {
            List<Pais> paises = new List<Pais>();
            string sql = "select * from tbPais WHERE 1 = 1 ";

            if (filtros != null)
            {
                foreach (var filtro in filtros)
                {
                    sql += $@" {filtro.Value}";
                }
            }

            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                using(SqlCommand command = new SqlCommand())
                {
                    command.Connection = conn;
                    command.CommandText = sql;

                    conn.Open();
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            paises.Add(Db2Pais(reader));
                        }
                    }
                }
            }
            return paises;
        }
        //--------------------------------------------Insert--------------------------------------------
        public int InsertPais(Pais pais)
        {
            int codigo = 0;
            string sql = "insert into tbPais (Nome, DDD) OUTPUT Inserted.CodigoPais VALUES (@Nome, @DDD)";

            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = conn;
                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@Nome", pais.Nome);
                    command.Parameters.AddWithValue("@DDD", pais.DDD);

                    conn.Open();
                    codigo = (int)command.ExecuteScalar();
                    pais.CodigoPais = codigo;
                }
            }

            return codigo;
        }
        //--------------------------------------------Delete--------------------------------------------
        public int DeletePais(int codigo)
        {
            string sql = "delete from tbPais WHERE CodigoPais = @CodigoPais";

            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = conn;
                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@CodigoPais", codigo);

                    conn.Open();
                    codigo = (int)command.ExecuteNonQuery();
                }
            }

            return codigo;
        }
        //--------------------------------------------Update--------------------------------------------
        public void UpdatePais(Pais pais)
        {
            string sql = "update tbPais SET Nome = @Nome, DDD = @DDD WHERE CodigoPais = @CodigoPais";

            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = conn;
                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@Nome", pais.Nome);
                    command.Parameters.AddWithValue("@DDD", pais.DDD);
                    command.Parameters.AddWithValue("@CodigoPais", pais.CodigoPais);

                    conn.Open();
                    command.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
        private Pais Db2Pais(SqlDataReader reader)
        {
            return new Pais()
            {
                CodigoPais = (int)reader["CodigoPais"],
                Nome = reader["Nome"].ToString(),
                DDD = reader["DDD"].ToString()
            };
        }
    }
}
