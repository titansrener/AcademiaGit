using CLASSES;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class AlunoDAL
    {
        private string strConexao = ConfigurationManager.ConnectionStrings["AcademiaConnection"].ConnectionString;

        public void Inserir(Aluno aluno)
        {
            SqlConnection con = new SqlConnection(strConexao);
            try
            {
                con.Open();
                /*Comando SQL para inserir na tabela aluno*/
                string comando = @"INSERT INTO ALUNO VALUES(@nome, @nrCPF, @nrCelular, @endereco, @sexo, @dtNascimento, @idFilial)";

                SqlCommand cmd = new SqlCommand(comando, con);

                /*Parametros para  inserir na tabela aluno*/
                SqlParameter parametroNome = new SqlParameter(@"nome", aluno.nome);
                SqlParameter parametroNrCPF = new SqlParameter(@"nrCPF", aluno.nrCPF);
                SqlParameter parametroNrCelular = new SqlParameter(@"nrCelular", aluno.nrCelular);
                SqlParameter parametroEndereco = new SqlParameter(@"endereco", aluno.endereco);
                SqlParameter parametroSexo = new SqlParameter(@"sexo", aluno.sexo);
                SqlParameter parametroDtNascimento = new SqlParameter(@"dtNascimento", aluno.dtNascimento);
                SqlParameter parametroIdFilial = new SqlParameter(@"idFilial", aluno.idFilial);

                /*Adicionando os parametros através do CMD criado acima*/
                cmd.Parameters.Add(parametroNome);
                cmd.Parameters.Add(parametroNrCPF);
                cmd.Parameters.Add(parametroNrCelular);
                cmd.Parameters.Add(parametroEndereco);
                cmd.Parameters.Add(parametroSexo);
                cmd.Parameters.Add(parametroDtNascimento);
                cmd.Parameters.Add(parametroIdFilial);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception)
            {
                new Exception("Outro Erro!!!");
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        public List<Aluno> ConsultarTodos()
        {
            List<Aluno> listaAlunos = new List<Aluno>();
            SqlConnection con = new SqlConnection(strConexao);
            try
            {
                con.Open();
                /*Comando SQL para listar todos os alunos*/
                string comando = @"SELECT * FROM ALUNO";

                SqlCommand cmd = new SqlCommand(comando, con);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id_aluno"]);
                    string nome = reader["ds_nome"].ToString();

                    //Aluno aluno = new Aluno(id, nome);
                    //listaAlunos.Add(aluno);
                }
                reader.Close();

                return listaAlunos;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception)
            {
                throw new Exception("Outro Problema");
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        public int QuantidadeAlunosFilial(int idFilial)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(strConexao);
                conn.Open();
                string sql = "SELECT Count(*) FROM ALUNO WHERE ID_ACADEMIA = @Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add(new SqlParameter("@Id", idFilial));
                //SqlDataAdapter da = new SqlDataAdapter(cmd);
                //DataTable dtt = new DataTable();
                //da.Fill(dtt);

                return (int)cmd.ExecuteScalar();
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
