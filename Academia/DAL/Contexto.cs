using CLASSES;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public sealed class Contexto : DbContext
    {
        public DbSet<Aluno> alunos { get; set; }
        public DbSet<Filial> filiais { get; set; }
        public DbSet<Mensalidade> mensalidades { get; set; }

        public Contexto() : base("name=AcademiaDBEntities")
        {
            this.Configuration.LazyLoadingEnabled = true;
        }
    }
}
