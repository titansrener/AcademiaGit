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
    public class MensalidadeBLL
    {
        public void Inserir(Mensalidade mensalidade, DateTime dataEscolhida, int nuParcelas, decimal valor)
        {
            using (var ctx = new Contexto())
            {
                for (int i = 1; i <= nuParcelas; i++)
                {
                    mensalidade.ST_TITULO = "A";
                    DateTime dataAtual = DateTime.Now;
                    if ((dataAtual != dataEscolhida) && (i == 1))
                    {
                        mensalidade.DT_VENCIMENTO = dataAtual;
                        mensalidade.NU_PARCELA = i;
                        mensalidade.VL_TITULO = valor;
                    }
                    else
                    {
                        if (i == 1)
                        {
                            mensalidade.DT_VENCIMENTO = dataEscolhida.AddMonths(i);
                            mensalidade.NU_PARCELA = i;
                            mensalidade.VL_TITULO = valor;
                        }
                        else
                        {
                            mensalidade.VL_TITULO = valor - (valor * (0.05m));
                            mensalidade.DT_VENCIMENTO = dataEscolhida.AddMonths(i);
                            mensalidade.NU_PARCELA = i;
                        }
                    }
                    ctx.mensalidades.Add(mensalidade);
                    ctx.SaveChanges();
                }
            }
        }

        public List<Mensalidade> ConsultarMensalidadePorAluno(int idAluno, int ano)
        {
            using (Contexto ctx = new Contexto())
            {
                List<Mensalidade> c = (from alu in ctx.mensalidades.Include("ALUNO")
                                       where ((alu.ID_ALUNO == idAluno) && (alu.NU_ANO == ano))
                                       select alu).ToList();
                return c;
            }
        }

        public List<Mensalidade> ConsultarMensalidadePorAluno(int idAluno)
        {
            using (Contexto ctx = new Contexto())
            {
                List<Mensalidade> c = (from alu in ctx.mensalidades.Include("ALUNO")
                                       where ((alu.ID_ALUNO == idAluno))
                                       select alu).ToList();
                return c;
            }
        }

        public decimal CalcularMulta(int id)
        {
            using (Contexto ctx = new Contexto())
            {
                Mensalidade m = ctx.mensalidades.SingleOrDefault(x => x.ID_TITULO == id);
                if (m.ST_TITULO != "p")
                {
                    DateTime dtAtual = DateTime.Now;
                    DateTime dtVencimento = m.DT_VENCIMENTO;
                    TimeSpan diferenca = dtAtual.Subtract(dtVencimento);
                    int dias = diferenca.Days;
                    decimal multa = 0;

                    if (dias > 0)
                    {
                        return multa = dias * 0.08m;
                    }
                }
                else
                {
                    return -1;
                }
            }
            return 0;
        }

        public decimal CalcularTotal(decimal valor, int id)
        {
            using (Contexto ctx = new Contexto())
            {
                return CalcularMulta(id) + valor;
            }
        }

        public Mensalidade ObterMensalidade(int id)
        {
            using (Contexto ctx = new Contexto())
            {
                return ctx.mensalidades.SingleOrDefault(x => x.ID_TITULO == id);
            }
        }

        public void Atualizar(Mensalidade mensalidade)
        {
            using (Contexto ctx = new Contexto())
            {
                ctx.Entry(mensalidade).State = EntityState.Modified;
                ctx.SaveChanges();
            }
        }

        public bool Pagar(Mensalidade mensalidade, decimal total)
        {
            mensalidade.ST_TITULO = "P";
            mensalidade.DT_PAGAMENTO = DateTime.Now;
            mensalidade.VL_TITULO = total;
            return true;
        }

        public List<Mensalidade> ConsultarMensalidadesEmAberto(int idAcademia)
        {
            using (Contexto ctx = new Contexto())
            {
                List<Mensalidade> c = (from alu in ctx.mensalidades.Include("ALUNO").OrderByDescending(x => x.DT_VENCIMENTO)
                                       where ((alu.ALUNO.idFilial == idAcademia) && (alu.ST_TITULO == "A"))
                                       select alu).ToList();
                return c;
            }
        }
    }
}
