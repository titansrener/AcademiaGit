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
    public partial class pagPagamentoMensalidades : System.Web.UI.Page
    {
        private static decimal total;
        private static Mensalidade mens;

        //protected override void OnInit(EventArgs e)
        //{
        //    if (!Roles.IsUserInRole("ADMINISTRADOR") !! !Roles.IsUserRole("FINANCEIRO"))
        //    {
        //        Response.Redirect("~/pagSemPermissao.aspx");
        //    }
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            MensalidadeBLL bll = new MensalidadeBLL();
            AlunoBLL bllAlu = new AlunoBLL();
            string id = Request.QueryString["idTitulo"];
            if (!String.IsNullOrEmpty(id))
            {
                int idMensalidade = Convert.ToInt32(id);
                Mensalidade mensalidade = bll.ObterMensalidade(idMensalidade);
                if (mensalidade != null)
                {
                    Aluno aluno = bllAlu.obterAluno(mensalidade.ID_ALUNO);
                    txtAluno.Text = aluno.nome;
                    txtParcela.Text = mensalidade.NU_PARCELA.ToString();
                    txtValor.Text = mensalidade.VL_TITULO.ToString();
                    txtAno.Text = mensalidade.NU_ANO.ToString();
                    txtVencimento.Text = mensalidade.DT_VENCIMENTO.ToString("dd/MM/yyyy");
                    txtValorMulta.Text = bll.CalcularMulta(mensalidade.ID_TITULO).ToString();
                    txtTotal.Text = bll.CalcularTotal(mensalidade.VL_TITULO, mensalidade.ID_TITULO).ToString();
                    total = Convert.ToDecimal(txtTotal.Text);
                    mens = mensalidade;
                }
            }
        }

        protected void btnPagar_Click(object sender, EventArgs e)
        {
            MensalidadeBLL bll = new MensalidadeBLL();
            if (bll.Pagar(mens, total))
            {
                bll.Atualizar(mens);
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "alert('Pagamento Efetuado Com Sucesso!');", true);
                //Limpar
                Response.Redirect("~/Matriculas/pagConsultarMensalidades.aspx?idAluno=" + mens.ID_ALUNO + "&nu_ano=" + mens.NU_ANO);
            }
        }
    }
}