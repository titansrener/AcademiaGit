using CLASSES;
using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AlunoBLL
    {
        public void Inserir(Aluno aluno)
        {
            using (var ctx = new Contexto())
            {
                ctx.alunos.Add(aluno);
                ctx.SaveChanges();
            }
        }

        public int Excluir(Aluno aluno)
        {
            using (Contexto ctx = new Contexto())
            {
                Aluno alu = ctx.alunos.SingleOrDefault(x => x.id == aluno.id);
                if (alu != null)
                {
                    ctx.alunos.Remove(alu);
                    return ctx.SaveChanges();
                }
                return -1;
            }
        }

        public void Atualizar(Aluno aluno)
        {
            using (Contexto ctx = new Contexto())
            {
                ctx.Entry(aluno).State = EntityState.Modified;
                ctx.SaveChanges();
            }
        }

        public List<Aluno> ConsultarTodosAlunos()
        {
            using (Contexto ctx = new Contexto())
            {
                return ctx.alunos.Include("FILIAL").ToList();
            }
        }

        public List<Aluno> ConsultarAlunosNMatriculados()
        {
            using (Contexto ctx = new Contexto())
            {
                List<Aluno> AlunosN_Mat = new List<Aluno>();
                List<Aluno> listaAlunos = ctx.alunos.Include("MENSALIDADES").ToList();
                int cont = 0;
                int quantMensalidades = 0;

                foreach (Aluno aluno in listaAlunos)
                {
                    cont = 0;
                    quantMensalidades = 0;
                    if (aluno.MENSALIDADES.ToList() != null)
                    {
                        List<Mensalidade> listaMensalidades = aluno.MENSALIDADES.ToList(); //nulo
                        quantMensalidades = listaMensalidades.Count;
                        foreach (Mensalidade mensalidade in listaMensalidades)
                        {
                            if (mensalidade.ST_TITULO != null && mensalidade.ST_TITULO == "P")
                            {
                                cont++;
                            }
                        }
                        if (cont == quantMensalidades)
                        {
                            AlunosN_Mat.Add(aluno);
                        }
                    }
                }
                return AlunosN_Mat;
            }
        }

        public Aluno obterAluno(int id)
        {
            using (Contexto ctx = new Contexto())
            {
                return ctx.alunos.SingleOrDefault(x => x.id == id);
            }
        }
    }
}
