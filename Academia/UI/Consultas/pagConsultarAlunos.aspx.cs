using CLASSES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Consultas
{
    public partial class pagConsultarAlunos : System.Web.UI.Page
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

        }

        protected void gvwAlunos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Manipular TemplateField
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Aluno aluno = e.Row.DataItem as Aluno;
                Label lbl = e.Row.FindControl("lblSexo") as Label;
                if (lbl.Text == "M")
                {
                    lbl.Text = "Masculino";
                }
                else
                {
                    lbl.Text = "Feminino";
                }
            }
        }

        protected void gvwAlunos_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Atualizar dados do aluno
            if (gvwAlunos.SelectedDataKey.Value != null)
            {
                Response.Redirect("~/Cadastros/pagCadastrarAlunos.aspx?Id=" + gvwAlunos.SelectedDataKey.Value.ToString());
            }
        }

        protected void odsAlunos_Deleted(object sender, ObjectDataSourceStatusEventArgs e)
        {
            if ((int)e.ReturnValue == -1)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "alert('Não foi possível excluir o aluno!');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "alert('Aluno excluído com sucesso!');", true);
            }
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Cadastros/pagCadastrarAlunos.aspx");
        }
    }
}