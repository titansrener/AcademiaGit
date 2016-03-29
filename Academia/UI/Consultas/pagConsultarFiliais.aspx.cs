using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Consultas
{
    public partial class pagConsultarFiliais : System.Web.UI.Page
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

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Cadastros/pagCadastrarFiliais.aspx");
        }

        protected void gvwFiliais_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gvwFiliais.SelectedDataKey.Value != null)
            {
                Response.Redirect("~/Cadastros/pagCadastrarFiliais.aspx?Id=" + gvwFiliais.SelectedDataKey.Value.ToString());
            }
        }

        protected void odsConsultar_Deleted(object sender, ObjectDataSourceStatusEventArgs e)
        {
            if ((int)e.ReturnValue == -1)
            {
                Response.Write("<script>alert('Não foi possível excluir a filial!');</script>");
            }
            else
            {
                Response.Write("<script>alert('Filial excluída com sucesso!');</script>");
            }
        }
    }
}