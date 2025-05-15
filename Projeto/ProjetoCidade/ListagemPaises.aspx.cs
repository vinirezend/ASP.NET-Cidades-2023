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
    public partial class ListagemPaises : System.Web.UI.Page
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
            if(!string.IsNullOrWhiteSpace(pesquisaPaises.Text))
            {
                filtros.Add("Nome", $"AND Nome LIKE '%{pesquisaPaises.Text}%'");
            }

            if (!string.IsNullOrWhiteSpace(filtroPaises.SelectedValue))
            {
                filtros.Add("Ordenacao", $"ORDER BY {filtroPaises.SelectedValue}");
            }

            List<Pais> paises = new PaisDAO().GetListPais(filtros);

            StringBuilder sbCidades = new StringBuilder();
            foreach (var pais in paises)
            {
                /*sbCidades.Append($@"<tr>
                                        <td>(+{pais.DDD}) {pais.Nome}</td>
                                        <td><a href='CadastrarPais.aspx?codigoPais={pais.CodigoPais}'><img class='editar' src='imagens/editar_imagem.png' width='20px' height='20px'/></a></td>
                                        <td><button  type='button' class='btnRemover' data-codigo='{pais.CodigoPais}'><img src='imagens/delete_imagem4.png' width='20px' height='20px'/></button></td>
                                    </tr>");*/
                sbCidades.Append($@"<tr>
                                        <td>(+{pais.DDD}) {pais.Nome}</td>
                                        <td><a href='CadastrarPais.aspx?codigoPais={pais.CodigoPais}'><i class='fa-solid fa-pen-to-square fa-lg' style='color: black;'></i></a></td>
                                        <td><button  type='button' class='btnRemover' data-codigo='{pais.CodigoPais}'><i class='fa-solid fa-trash fa-lg'></i></button></td>
                                    </tr>");
            }

            ltrTodosPaises.Text = sbCidades.ToString();
        }
    }
}