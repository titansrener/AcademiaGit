using BLL;
using CLASSES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Matriculas
{
    public partial class pagMatricularAlunos : System.Web.UI.Page
    {
        //protected override void OnInit(EventArgs e)
        //{
        //    if (!Roles.IsUserInRole("ADMINISTRADOR"))
        //    {
        //        Response.Redirect("~/pagSemPermissao.aspx");
        //    }
        //}
        protected void Page_Load(object sender, EventArgs e)
        {
            txtAno.Text = DateTime.Now.Year.ToString();
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            AlunoBLL bll = new AlunoBLL();
            FilialBLL fBLL = new FilialBLL();
            Aluno aluno = bll.obterAluno(Convert.ToInt32(ddlAlunos.SelectedValue));
            int diaPagamento = Convert.ToInt32(rblDiaPagamento.SelectedValue);
            int numeroParcelas = Convert.ToInt32(ddlParcelas.SelectedValue);
            DateTime dt = new DateTime(Convert.ToInt32(txtAno.Text), Convert.ToInt32(DateTime.Now.Month), diaPagamento);

            Mensalidade mensalidade = new Mensalidade();
            mensalidade.ID_ALUNO = aluno.id;
            mensalidade.NU_ANO = Convert.ToInt32(txtAno.Text);
            
            MensalidadeBLL mbll = new MensalidadeBLL();
            if (aluno.idFilial != null)
            {
                Filial filialAluno = fBLL.ObterFilial(aluno.idFilial);
                decimal valorParcelaAcademia = filialAluno.VL_PRECO;
                mbll.Inserir(mensalidade, dt, numeroParcelas, valorParcelaAcademia);
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "alert('Matrícula efetuada com sucesso!');", true);
                Response.Redirect("~/Matriculas/pagConsultarMensalidades.aspx");
            }
            else
            {
                lblStatus.Text = "O aluno não pode ser matriculado porque não está vinculado a nenhuma academia";
            }
        }

        protected void ddlAlunos_DataBinding(object sender, EventArgs e)
        {
            ((DropDownList)sender).Items.Clear();
            ((DropDownList)sender).Items.Add(new ListItem("Selecione", " "));
        }

        protected void ddlParcelas_DataBinding(object sender, EventArgs e)
        {
            ((DropDownList)sender).Items.Clear();
            ((DropDownList)sender).Items.Add(new ListItem("Selecione", " "));
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home.aspx");
        }
    }
}