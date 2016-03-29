using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLASSES
{
    public class Filial
    {
        public int id { get; set; }
        public string descricao { get; set; }
        public string endereco { get; set; }
        public string nrTelefone { get; set; }
        public string dsBairro { get; set; }
        public string dsEmail { get; set; }

        public decimal VL_PRECO { get; set; }

        public ICollection<Aluno> ALUNOS { get; set; }

        public Filial(string descricao, string endereco, string nrTelefone, string dsBairro, string dsEmail, decimal preco)
        {
            this.descricao = descricao;
            this.endereco = endereco;
            this.nrTelefone = nrTelefone;
            this.dsBairro = dsBairro;
            this.dsEmail = dsEmail;
            this.VL_PRECO = preco;
        }

        public Filial()
        {
        }
    }
}
