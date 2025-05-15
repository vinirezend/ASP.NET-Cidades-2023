using ProjetoCidadeDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoCidade
{
    public partial class Ajax : System.Web.UI.Page
    {
        [WebMethod]
        public static int DeletarCidade(int codigoCidade)
        {
            new CidadeDAO().DeleteCidade(codigoCidade);
            return codigoCidade;
        }

        [WebMethod]
        public static int DeletarEstado(int codigoEstado)
        {
            new EstadoDAO().DeleteEstado(codigoEstado);
            return codigoEstado;
        }

        [WebMethod]
        public static int DeletarPais(int codigoPais)
        {
            new PaisDAO().DeletePais(codigoPais);
            return codigoPais;
        }
    }
}