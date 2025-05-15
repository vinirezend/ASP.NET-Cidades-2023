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
    public partial class ListagemCidades : System.Web.UI.Page
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
            if(!string.IsNullOrWhiteSpace(pesquisaCidades.Text))
            {
                filtros.Add("Nome", $"AND Nome LIKE '%{pesquisaCidades.Text}%'");
            }

            if (!string.IsNullOrWhiteSpace(filtroCidades.SelectedValue))
            {
                filtros.Add("Ordenacao", $"ORDER BY {filtroCidades.SelectedValue}");
            }

            List<Cidade> cidades = new CidadeDAO().GetListCidade(filtros);

            StringBuilder sbCidades = new StringBuilder();
            foreach (var cidade in cidades)
            {
                sbCidades.Append($@"<tr>
                                        <td class='nomecidade' data-nome='{cidade.Nome}'>{cidade.Nome} - <a class='link-danger' href='CadastrarEstado.aspx?codigoEstado={cidade.CodigoEstado}'> {cidade.Estado.SiglaEstado} </a> </td>
                                        <td><a href='CadastrarCidade.aspx?codigoCidade={cidade.CodigoCidade}'><i class='fa-solid fa-pen-to-square fa-lg' style='color: black;'></i></a></td>
                                        <td><button type='button' class='btnRemover' data-codigo='{cidade.CodigoCidade}'><i class='fa-solid fa-trash fa-lg'></i></button></td>
                                    </tr>");
            }

            ltrTodasCidades.Text = sbCidades.ToString();
        }

    }
}