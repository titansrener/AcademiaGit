﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbResetarSenha_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AlterarSenha.aspx");
        }

        protected void lbCriarUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/CriarUsuario.aspx");
        }
    }
}