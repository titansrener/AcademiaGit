using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLASSES
{
    public class Aluno
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string nrCPF { get; set; }
        public string nrCelular { get; set; }
        public string endereco { get; set; }
        public string sexo { get; set; }
        public DateTime? dtNascimento { get; set; }
        public int? idFilial { get; set; }

        public virtual Filial FILIAL { get; set; }

        public ICollection<Mensalidade> MENSALIDADES { get; set; }

        public Aluno(string nome, string nrCPF, string nrCelular, string endereco, string sexo, DateTime? dtNascimento, int? idFilial)
        {
            this.nome = nome;
            this.nrCPF = nrCPF;
            this.nrCelular = nrCelular;
            this.endereco = endereco;
            this.sexo = sexo;
            this.dtNascimento = dtNascimento;
            this.idFilial = idFilial;
        }

        public Aluno()
        { 
        }
    }
}
