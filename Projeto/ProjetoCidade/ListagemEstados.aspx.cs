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
    public partial class ListagemEstados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string usuario = (string)Session["Usuario"];
            if (usuario == null)
            {
                Response.Redirect("LoginUsuario.aspx");
            }
            else
            {
                PreencherTabela();
            }
        }

        private void PreencherTabela()
        {
            Dictionary<string, string> filtros = new Dictionary<string, string>();
            if(!string.IsNullOrWhiteSpace(pesquisaEstados.Text))
            {
                filtros.Add("NomeEstado", $"AND NomeEstado LIKE '%{pesquisaEstados.Text}%'");
            }

            if (!string.IsNullOrWhiteSpace(filtroEstados.SelectedValue))
            {
                filtros.Add("Ordenacao", $"ORDER BY {filtroEstados.SelectedValue}");
            }

            List<Estado> estados = new EstadoDAO().GetListEstado(filtros);

            StringBuilder sbCidades = new StringBuilder();
            foreach (var estado in estados)
            {
                sbCidades.Append($@"<tr>
                                        <td>{estado.NomeEstado} (<a class='link-danger' href='CadastrarPais.aspx?codigoPais={estado.Pais.CodigoPais}'>{estado.Pais.Nome}</a>)</td>
                                        <td><a href='CadastrarEstado.aspx?codigoEstado={estado.CodigoEstado}'><i class='fa-solid fa-pen-to-square fa-lg' style='color: black;'></a></td>
                                        <td><button  type='button' class='btnRemover' data-codigo='{estado.CodigoEstado}'><i class='fa-solid fa-trash fa-lg'></i></button></td>
                                    </tr>");
            }

            ltrTodosEstados.Text = sbCidades.ToString();
        }
    }
}