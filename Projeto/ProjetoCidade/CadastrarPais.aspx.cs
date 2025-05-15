using ProjetoCidadeDAO;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoCidade
{
    public partial class CadastrarPais : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int codigoPais = Request.QueryString["codigoPais"] != null ? int.Parse(Request.QueryString["codigoPais"]) : 0;
            string usuario = (string)Session["Usuario"];

            /*if (usuario == null)
            {
                Response.Redirect("LoginUsuario.aspx");
            }*/

            if (!Page.IsPostBack) 
            {

                if (codigoPais != 0)
                {
                    PreencherCampos(codigoPais);
                }
            }
            else
            {
                if (codigoPais != 0)
                {
                    AtualizarPais(codigoPais);
                }
                else
                {
                    InserirPais();
                }
            }
        }



        private void InserirPais()
        {
            Pais pais = new Pais();
            PreencherDados(pais);

            new PaisDAO().InsertPais(pais);
            Response.Redirect("CadastrarPais.aspx");
        }

        private void PreencherDados(Pais pais)
        {
            pais.Nome = txtNome.Text;
            pais.DDD = txtDDD.Text;
        }

        private void AtualizarPais(int codigoPais)
        {
            Pais pais = new PaisDAO().GetPais(codigoPais);
            PreencherDados(pais);

            new PaisDAO().UpdatePais(pais);

            ltrScriptCadastro.Text = $@"<script>
                                          alert('{pais.Nome} foi atualizado com sucesso');
                                    </script>";
        }

        private void PreencherCampos(int codigoPais)
        {
            Pais pais = new PaisDAO().GetPais(codigoPais);
            txtNome.Text = pais.Nome;
            txtDDD.Text = pais.DDD;

            StringBuilder sbEstados = new StringBuilder();
            if (pais.Estados.Count() > 0)
            {
                sbEstados.Append($@" <table class='pertencentes table table-warning table-striped border border-dark'>
                                        <thead>
                                            <tr>
                                                <th>Estados deste país</th>
                                            </tr>
                                        </thead>
                                        <tbody>");


                foreach (var estado in pais.Estados)
                {
                    sbEstados.Append($@"<tr>
                                        <td>{estado.NomeEstado} - {estado.SiglaEstado}</td>
                                    </tr>");
                }
                sbEstados.Append($@"</tbody>
                                </table>");
            }
            else
            {
                sbEstados.Append("<h4>Esse pais não possui estado cadastrado</h4>");
            }

            ltrEstados.Text = sbEstados.ToString();
        }
    }
}