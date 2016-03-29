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
    public partial class pagConsultarMensalidades : System.Web.UI.Page
    {
        //protected override void OnInit(EventArgs e)
        //{
        //    if (!Roles.IsUserInRole("ADMINISTRADOR") !! !Roles.IsUserRole("FINANCEIRO"))
        //    {
        //        Response.Redirect("~/pagSemPermissao.aspx");
        //    }
        //}
        protected void Page_Load(object sender, EventArgs e)
        {
            string idAlunoTemp = Request.QueryString["idAluno"];
            string anoTemp = Request.QueryString["nu_ano"];
            if (!string.IsNullOrEmpty(idAlunoTemp))
            {
                Cadastrar(idAlunoTemp, anoTemp);
            }
        }

        protected void ddlAlunos_DataBinding(object sender, EventArgs e)
        {
            ((DropDownList)sender).Items.Clear();
            ((DropDownList)sender).Items.Add(new ListItem("Selecione", " "));
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void Cadastrar(string id_Aluno, string nu_ano)
        {
            MensalidadeBLL bll = new MensalidadeBLL();
            int idAluno = Convert.ToInt32(id_Aluno);
            int ano = Convert.ToInt32(nu_ano);

            grvMensalidades.DataSource = bll.ConsultarMensalidadePorAluno(idAluno, ano);
            grvMensalidades.DataBind();
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            Cadastrar(ddlAlunos.SelectedValue.ToString(), txtAno.Text);
        }

        protected void grvMensalidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (grvMensalidades.SelectedDataKey.Value != null)
            {
                Response.Redirect("~/Matriculas/pagPagamentoMensalidades.aspx?idTitulo=" + grvMensalidades.SelectedDataKey.Value.ToString() + "&idAluno=" + ddlAlunos.SelectedValue.ToString() + "&nu_ano=" + txtAno.Text);
            }
        }

        protected void grvMensalidades_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Mensalidade mensalidade = e.Row.DataItem as Mensalidade;
            MensalidadeBLL bll = new MensalidadeBLL();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (mensalidade.ST_TITULO == "P")    //e.Row.Cells[5].Text.ToString() == "P"
                {
                    e.Row.Cells[5].Enabled = false;
                }
                Label lbl = e.Row.FindControl("lblMulta") as Label;
                if (bll.CalcularMulta(mensalidade.ID_TITULO) != 0 && mensalidade.ST_TITULO != "P")
                {
                    lbl.Text = bll.CalcularMulta(mensalidade.ID_TITULO).ToString();
                }
                else
                {
                    lbl.Text = String.Empty;
                }
            }
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Matriculas/pagMatricularAlunos.aspx");
        }
    }
}