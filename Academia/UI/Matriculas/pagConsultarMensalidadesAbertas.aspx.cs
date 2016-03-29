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
    public partial class pagConsultarMensalidadesAbertas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //FilialBLL fBLL = new FilialBLL();
            //ddlFilial.Items.Insert(0, new ListItem("Selecione", " "));
            //ddlFilial.DataBind();
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            MensalidadeBLL mBLL = new MensalidadeBLL();
            int id = Convert.ToInt32(ddlFilial.SelectedValue);
            grvMensalidadesAbertas.DataSource = mBLL.ConsultarMensalidadesEmAberto(id);
            grvMensalidadesAbertas.DataBind();
        }

        protected void ddlFilial_DataBinding(object sender, EventArgs e)
        {
            ((DropDownList)sender).Items.Clear();
            ((DropDownList)sender).Items.Add(new ListItem("Selecione", " "));
        }

        protected void ddlFilial_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}