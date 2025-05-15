using ProjetoCidadeDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoCidade
{
    public partial class CadastrarUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
                {
                    CadastrarNovoUsuario();
                }
        }
        private void CadastrarNovoUsuario()
        {
            string validar = txtLogin.Text;
            Usuario login = new UsuarioDAO().GetUsuario(validar);

            if(login == null)
            {
                Usuario usuario = new Usuario();
                PreencherDados(usuario);

                new UsuarioDAO().InsertUsuario(usuario);
                Response.Redirect("LoginUsuario.aspx");
            
            }
            else
            {
                ltrLoginRepetido.Text = $@"<p id='msgLoginRepetido'> O usuario {login.Login} ja existe. </p>";
            }

        }

        private void PreencherDados(Usuario usuario)
        {
            usuario.Nome = txtNome.Text;
            usuario.Login = txtLogin.Text;
            usuario.Senha = txtSenha.Text;
        }
    }
}