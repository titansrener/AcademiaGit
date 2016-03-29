using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI
{
    public partial class Master1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCadastrarFilial_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Consultas/pagConsultarFiliais.aspx");
        }

        protected void btnCadastrarAluno_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Consultas/pagConsultarAlunos.aspx");
        }

        protected void btnMatricularAluno_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Matriculas/pagConsultarMensalidades.aspx");
        }

        protected void btnConsultarMensalidadesAbertas_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Matriculas/pagConsultarMensalidadesAbertas.aspx");
        }
    }
}