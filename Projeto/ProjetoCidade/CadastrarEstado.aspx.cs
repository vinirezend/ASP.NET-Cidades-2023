using ProjetoCidadeDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoCidade
{
    public partial class CadastrarEstado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int codigoEstado = Request.QueryString["codigoEstado"] != null ? int.Parse(Request.QueryString["codigoEstado"]) : 0;
            string usuario = (string)Session["Usuario"];

            if (usuario == null)
            {
                Response.Redirect("LoginUsuario.aspx");
            }
            
            if (!Page.IsPostBack)
            {
                List<Pais> paises = new PaisDAO().GetListPais(null);
                foreach (Pais pais in paises)
                {
                    cmbPaises.Items.Add(new ListItem(pais.Nome, pais.CodigoPais.ToString()));
                }

                if (codigoEstado != 0)
                {
                    PreencherCampos(codigoEstado);
                }
            }
            else
            {
                if (codigoEstado != 0)
                {
                    AtualizarEstado(codigoEstado);
                }
                else
                {
                    InserirEstado();
                }
            }
        }


        private void InserirEstado()
        {
            Estado estado = new Estado();
            PreencherDados(estado);

            new EstadoDAO().InsertEstado(estado);
            ltrScriptCadastro.Text = $@"<script>
                                          alert('{estado.NomeEstado} foi inserido com sucesso');
                                    </script>";
        }

        private void PreencherDados(Estado estado)
        {
            estado.NomeEstado = txtNome.Text;
            estado.SiglaEstado = txtSiglaEstado.Text;
            estado.CodigoPais = int.Parse(cmbPaises.SelectedValue);
        }

        private void AtualizarEstado(int codigoEstado)
        {
            Estado estado = new EstadoDAO().GetEstado(codigoEstado);
            PreencherDados(estado);

            new EstadoDAO().UpdateEstado(estado);
            Response.Redirect("CadastrarEstado.aspx" + estado.CodigoEstado.ToString());
        }

        private void PreencherCampos(int codigoEstado)
        {
            Estado estado = new EstadoDAO().GetEstado(codigoEstado);
            txtNome.Text = estado.NomeEstado;
            txtSiglaEstado.Text = estado.SiglaEstado;

            cmbPaises.SelectedValue = estado.CodigoPais.ToString();

            StringBuilder sbCidades = new StringBuilder();
            if (estado.Cidades.Count() > 0)
            {
                sbCidades.Append($@" <table class='pertencentes table table-warning table-striped border border-dark'>
                                            <thead>
                                                <tr>
                                                    <th>Cidades desse estado</th>
                                                </tr>
                                            </thead>
                                            <tbody>");

                foreach (var cidade in estado.Cidades)
                {
                    sbCidades.Append($@"<tr>
                                        <td>{cidade.Nome}</td>
                                    </tr>");
                }
                sbCidades.Append($@" </tbody>
                                </table>
                                ");
            }
            else
            {
                sbCidades.Append("<h4 class='semRegistro'>Esse estado não possui cidade cadastrada</h4>");
            }
            ltrCidades.Text = sbCidades.ToString();
        }
    }
}