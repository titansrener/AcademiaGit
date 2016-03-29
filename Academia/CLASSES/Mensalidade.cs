using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLASSES
{
    public class Mensalidade
    {
        public int ID_TITULO { get; set; }
        public int ID_ALUNO { get; set; }
        public int NU_ANO { get; set; }
        public int NU_PARCELA { get; set; }
        public DateTime DT_VENCIMENTO { get; set; }
        public string ST_TITULO { get; set; }
        public DateTime? DT_PAGAMENTO { get; set; }
        public decimal VL_TITULO { get; set; }

        public virtual Aluno ALUNO { get; set; }

        public Mensalidade()
        { 
        }


        public Mensalidade(int ID_ALUNO, int NU_ANO, int NU_PARCELA, DateTime DT_VENCIMENTO, string ST_TITULO,
            DateTime? DT_PAGAMENTO, decimal VL_TITULO)
        {
            this.ID_ALUNO = ID_ALUNO;
            this.NU_ANO = NU_ANO;
            this.NU_PARCELA = NU_PARCELA;
            this.DT_VENCIMENTO = DT_VENCIMENTO;
            this.ST_TITULO = ST_TITULO;
            this.DT_PAGAMENTO = DT_PAGAMENTO;
            this.VL_TITULO = VL_TITULO;
        }
    }
}
