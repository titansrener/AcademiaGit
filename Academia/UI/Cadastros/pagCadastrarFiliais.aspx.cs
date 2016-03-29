using BLL;
using CLASSES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Cadastros
{
    public partial class pagCadastrarFiliais : System.Web.UI.Page
    {
        //protected override void OnInit(EventArgs e)
        //{
        //    if (!Roles.IsUserInRole("ADMINISTRADOR") || !Roles.IsUserInRole("ADMINISTRATIVO"))
        //    {
        //        Response.Redirect("~/pagSemPermissao.aspx");
        //    }
        //}
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["Id"];
                FilialBLL bll = new FilialBLL();
                if (!string.IsNullOrEmpty(id))
                {
                    int idFilial = Convert.ToInt32(id);
                    Filial filial = bll.ObterFilial(idFilial);
                    if (filial != null)
                    {
                        txtDescricao.Text = filial.descricao;
                        txtEmail.Text = filial.dsEmail;
                        txtTelefone.Text = filial.nrTelefone;
                        txtBairro.Text = filial.dsBairro;
                        txtEndereco.Text = filial.endereco;
                        txtPreco.Text = filial.VL_PRECO.ToString();
                        ViewState["Filial"] = filial.id;
                    }
                }
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            string descricao = txtDescricao.Text;
            string email = txtEmail.Text;
            string telefone = new String(txtTelefone.Text.Where(c => char.IsDigit(c)).ToArray());
            string bairro = txtBairro.Text;
            string endereco = txtEndereco.Text;
            decimal preco = Convert.ToDecimal(new String(txtPreco.Text.Where(c => char.IsDigit(c)).ToArray()));

            FilialBLL bll = new FilialBLL();
            Filial filial = new Filial(descricao, endereco, telefone, bairro, email, preco);
            if (ViewState["Filial"] == null)
                bll.Inserir(filial);
            else
            {
                filial.id = Convert.ToInt32(ViewState["Filial"]);
                bll.Atualizar(filial);
            }

            txtBairro.Text = String.Empty;
            txtDescricao.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtEndereco.Text = String.Empty;
            txtTelefone.Text = String.Empty;

            Response.Write("<script>alert('Filial cadastrada com sucesso!');</script>");
            Response.Redirect("~/Consultas/pagConsultarFiliais.aspx");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home.aspx");
        }
    }
}