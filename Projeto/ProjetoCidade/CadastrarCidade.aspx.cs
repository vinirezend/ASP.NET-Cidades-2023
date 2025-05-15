using ProjetoCidadeDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoCidade
{
    public partial class CadastrarCidade : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int codigoCidade = Request.QueryString["codigoCidade"] != null ? int.Parse(Request.QueryString["codigoCidade"]) : 0;
            string usuario = (string)Session["Usuario"];

            if (usuario == null)
            {
                Response.Redirect("LoginUsuario.aspx");
            }
            if (!Page.IsPostBack)
            {
                List<Estado> estados = new EstadoDAO().GetListEstado(null);
                foreach (Estado estado in estados)
                {
                    cmbEstados.Items.Add(new ListItem(estado.NomeEstado, estado.CodigoEstado.ToString()));
                }

                if (codigoCidade != 0)
                {
                    PreencherCampos(codigoCidade);
                }
            }
            else
            {
                if (codigoCidade != 0)
                {
                    AtualizarCidade(codigoCidade);
                }
                else
                {
                    InserirCidade();
                }
            }
        }


        private void InserirCidade()
        {
            Cidade cidade = new Cidade();
            PreencherDados(cidade);

            new CidadeDAO().InsertCidade(cidade);
            ltrScriptCadastro.Text = $@"<script>
                                          alert('{cidade.Nome} foi atualizado com sucesso');
                                    </script>";
        }

        private void PreencherDados(Cidade cidade)
        {
            cidade.Nome = txtNome.Text;
            cidade.CodigoEstado = int.Parse(cmbEstados.SelectedValue);
        }

        private void AtualizarCidade(int codigoCidade)
        {
            Cidade cidade = new CidadeDAO().GetCidade(codigoCidade);
            PreencherDados(cidade);

            new CidadeDAO().UpdateCidade(cidade);
            Response.Redirect("CadastrarCidade.aspx" + cidade.CodigoEstado.ToString());
        }

        private void PreencherCampos(int codigoCidade)
        {
            Cidade cidade = new CidadeDAO().GetCidade(codigoCidade);
            txtNome.Text = cidade.Nome;

            cmbEstados.SelectedValue = cidade.CodigoEstado.ToString();
        }
    }
}