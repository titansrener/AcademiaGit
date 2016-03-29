using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using CLASSES;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class FilialDAL
    {
        private string strConexao = ConfigurationManager.ConnectionStrings["AcademiaConnection"].ConnectionString;

        public void Inserir(Filial filial)
        {
            SqlConnection con = new SqlConnection(strConexao);
            try
            {
                con.Open();
                /*Comando SQL para inserir na tabela filial*/
                string comando = @"INSERT INTO FILIAL VALUES(@dsAcademia, @dsEndereco, @nrTelefone, @dsBairro, @dsEmail, @VL_PRECO)";
                SqlCommand cmd = new SqlCommand(comando, con);

                /*Parametros para  inserir na tabela filial*/
                SqlParameter parametroDsAcademia = new SqlParameter(@"dsAcademia", filial.descricao);
                SqlParameter parametroDsEndereco = new SqlParameter(@"dsEndereco", filial.endereco);
                SqlParameter parametroNrTelefone = new SqlParameter(@"nrTelefone", filial.nrTelefone);
                SqlParameter parametroDsBairro = new SqlParameter(@"dsBairro", filial.dsBairro);
                SqlParameter parametroDsEmail = new SqlParameter(@"dsEmail", filial.dsEmail);
                SqlParameter parametroVL_PRECO = new SqlParameter(@"VL_PRECO", filial.VL_PRECO);

                /*Adicionando os parametros através do CMD criado acima*/
                cmd.Parameters.Add(parametroDsAcademia);
                cmd.Parameters.Add(parametroDsEndereco);
                cmd.Parameters.Add(parametroNrTelefone);
                cmd.Parameters.Add(parametroDsBairro);
                cmd.Parameters.Add(parametroDsEmail);
                cmd.Parameters.Add(parametroVL_PRECO);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                throw new Exception("Erro no banco!!!"); ;
            }
            catch (Exception)
            {
                throw new Exception("Outro Erro!!!");
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        //public List<Mensalidade>

        public List<Filial> ConsultarTodos()
        {
            SqlConnection conn = null;
            List<Filial> listaFilial = new List<Filial>();
            try
            {
                conn = new SqlConnection(strConexao);
                conn.Open();
                string sql = "SELECT * FROM FILIAL";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Filial filial = new Filial();
                    filial.id = Convert.ToInt32(reader["ID_ACADEMIA"]);
                    filial.descricao = reader["DS_ACADEMIA"].ToString();
                    filial.dsEmail = reader["DS_EMAIL"].ToString();
                    filial.nrTelefone = reader["NR_TELEFONE"].ToString();
                    filial.dsBairro = reader["DS_BAIRRO"].ToString();
                    filial.endereco = reader["DS_ENDERECO"].ToString();
                    filial.VL_PRECO = Convert.ToDecimal(reader["VL_PRECO"]);

                    listaFilial.Add(filial);
                }
                return listaFilial;
            }
            catch (SqlException)
            {
                throw new Exception("Erro no banco de dados");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        public int Excluir(int idFilial)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(strConexao);
                conn.Open();
                string sql = @"
DELETE FROM FILIAL WHERE ID_ACADEMIA = @Id
";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add(new SqlParameter("@Id", idFilial));

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                throw new Exception("Erro no banco de dados");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }

        }

        public void Atualizar(Filial filial)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(strConexao);
                conn.Open();
                string sql = @"
UPDATE FILIAL 
SET DS_ACADEMIA = @Descricao,
    DS_ENDERECO = @Endereco, 
    NR_TELEFONE = @Telefone,
    DS_BAIRRO = @Bairro,
    DS_EMAIL = @Email,
    VL_PRECO = @Preco
WHERE ID_ACADEMIA = @Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add(new SqlParameter("@Descricao", filial.descricao));
                cmd.Parameters.Add(new SqlParameter("@Endereco", filial.endereco));
                cmd.Parameters.Add(new SqlParameter("@Telefone", filial.nrTelefone));
                cmd.Parameters.Add(new SqlParameter("@Bairro", filial.dsBairro));
                cmd.Parameters.Add(new SqlParameter("@Email", filial.dsEmail));
                cmd.Parameters.Add(new SqlParameter("@Preco", filial.VL_PRECO));
                cmd.Parameters.Add(new SqlParameter("@Id", filial.id));

                cmd.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                throw new Exception("Erro no banco de dados");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }

        }

        public Filial ObterFilial(int? idFilial)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(strConexao);
                conn.Open();
                string sql = "SELECT * FROM FILIAL WHERE ID_ACADEMIA = @Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add(new SqlParameter("@Id", idFilial));
                SqlDataReader reader = cmd.ExecuteReader();
                Filial filial = null;
                while (reader.Read())
                {
                    filial = new Filial();
                    filial.id = Convert.ToInt32(reader["ID_ACADEMIA"]);
                    filial.descricao = reader["DS_ACADEMIA"].ToString();
                    filial.dsEmail = reader["DS_EMAIL"].ToString();
                    filial.nrTelefone = reader["NR_TELEFONE"].ToString();
                    filial.dsBairro = reader["DS_BAIRRO"].ToString();
                    filial.endereco = reader["DS_ENDERECO"].ToString();
                    filial.VL_PRECO = Convert.ToDecimal(reader["VL_PRECO"]);
                    //if (reader["NR_ENDERECO"] != null)
                    //    filial.numero = Convert.ToInt32(reader["NR_ENDERECO"]);
                }
                return filial;
            }
            catch (SqlException)
            {
                throw new Exception("Erro no banco de dados");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }
    }
}
