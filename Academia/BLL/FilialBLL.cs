using CLASSES;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class FilialBLL
    {
        public void Inserir(Filial filial)
        {
            try
            {
                FilialDAL fd = new FilialDAL();
                fd.Inserir(filial);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Filial> ConsultarTodos()
        {
            try
            {
                FilialDAL fd = new FilialDAL();
                return fd.ConsultarTodos();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public int Excluir(int Id)
        {
            try
            {
                AlunoDAL alunosDAL = new AlunoDAL();
                if (alunosDAL.QuantidadeAlunosFilial(Id) > 0)
                {
                    return -1;
                }
                else
                {
                    FilialDAL filialDAL = new FilialDAL();
                    return filialDAL.Excluir(Id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Atualizar(Filial filial)
        {
            try
            {
                FilialDAL filialDAL = new FilialDAL();
                filialDAL.Atualizar(filial);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Filial ObterFilial(int? Id)
        {
            try
            {
                FilialDAL filialDAL = new FilialDAL();
                return filialDAL.ObterFilial(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Filial> ConsultarTodasFiliais()
        {
            using (var ctx = new Contexto())
            {
                return ctx.filiais.ToList();
            }
        }
    }
}
