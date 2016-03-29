using BLL;
using CLASSES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Cadastros
{
    public partial class pagCadastrarAlunos : System.Web.UI.Page
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
            if (!Page.IsPostBack)
            {
                ddlFilial.DataTextField = "descricao";
                ddlFilial.DataValueField = "id";
                FilialBLL bll = new FilialBLL();
                ddlFilial.DataSource = bll.ConsultarTodasFiliais();
                ddlFilial.DataBind();

                ddlSexo.DataTextField = "sexo";
                ddlSexo.DataValueField = "sexo";
                ddlSexo.Items.Insert(0, new ListItem("Selecione", String.Empty));

                ddlFilial.DataTextField = "filial";
                ddlFilial.DataValueField = "filial";
                ddlFilial.Items.Insert(0, new ListItem("Selecione", String.Empty));

                AlunoBLL aluBll = new AlunoBLL();

                string id = Request.QueryString["id"];
                if (!String.IsNullOrEmpty(id))
                {
                    int idAluno = Convert.ToInt32(id);
                    Aluno aluno = aluBll.obterAluno(idAluno);
                    if (aluno != null)
                    {
                        txtNome.Text = aluno.nome;
                        txtEndereco.Text = aluno.endereco;
                        txtCPF.Text = aluno.nrCPF;
                        txtCelular.Text = aluno.nrCelular;
                        txtDtNascimento.Text = aluno.dtNascimento.ToString();
                        ddlSexo.SelectedValue = aluno.sexo;
                        ddlFilial.SelectedValue = aluno.idFilial.ToString();
                        ViewState["Aluno"] = aluno.id;
                    }
                }
            }
        }

        protected void ddlSexo_DataBinding(object sender, EventArgs e)
        {
            ((DropDownList)sender).Items.Clear();
            ((DropDownList)sender).Items.Add(new ListItem("Selecione", String.Empty));
        }

        protected void ddlFilial_DataBinding(object sender, EventArgs e)
        {
            ((DropDownList)sender).Items.Clear();
            ((DropDownList)sender).Items.Add(new ListItem("Selecione", String.Empty));
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            DateTime? dtNascimento;
            int? id;
            string nome = txtNome.Text;
            string cpf = new String(txtCPF.Text.Where(c=> char.IsDigit(c)).ToArray());
            string celular = new String(txtCelular.Text.Where(c => char.IsDigit(c)).ToArray());
            string sexo = ddlSexo.SelectedValue.ToString();

            if (String.IsNullOrEmpty(txtDtNascimento.Text))
            {
                dtNascimento = null;
            }
            else 
            {
                dtNascimento = Convert.ToDateTime(txtDtNascimento.Text);
            }
            
            string endereco = txtEndereco.Text;
            if (String.IsNullOrEmpty(ddlFilial.SelectedValue))
            {
                id = null;
            }
            else
            { 
                id = Convert.ToInt32(ddlFilial.SelectedValue);
            }

            Aluno aluno = new Aluno(nome, cpf, celular, endereco, sexo, dtNascimento, id);

            AlunoBLL alu = new AlunoBLL();

            if (ViewState["Aluno"] == null)
            {
                alu.Inserir(aluno);
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "alert('Cadastro Efetuado Com Sucesso!');", true);
            }
            else
            {
                aluno.id = Convert.ToInt32(ViewState["Aluno"]);
                alu.Atualizar(aluno);
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "alert('Cadastro atualizado Com Sucesso!');", true);
            }
            Response.Redirect("~/Consultas/pagConsultarAlunos.aspx");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home.aspx");
        }
    }
}