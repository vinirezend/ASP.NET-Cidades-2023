using ProjetoCidadeDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoCidade
{
    public partial class PagTeste : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var estado = new EstadoDAO().GetEstado(5);

            int qntdCidades = estado.Cidades.Count();
            string nomeCidade = estado.Cidades[0].Nome;
            string nomeCidade1 = estado.Cidades[1].Nome;
        }
    }
}