using ProjetoCidadeDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing;
using System.Windows;

namespace ProjetoCidade
{
    public partial class LoginUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string usuario = (string)Session["Usuario"];
            if (usuario != null)
            {
                EncerrarSessao();

            }

            if (Page.IsPostBack)
            {
                MensagemScript();
                PreencherLogin();
            }
        }

        private void EncerrarSessao()
        {
            
            Session.Abandon();
            MensagemScript();
        }

        private void MensagemScript()
        {
            string usuario = (string)Session["Usuario"];
            string mensagemScript;
            if (usuario != null)
            {
                mensagemScript = $@"<script> 
                                        alert('O usuario {usuario} abandonou a sessão'); 
                                    </script >";
            }
            else
            {
                mensagemScript = null;
            }
            ltrScript.Text = mensagemScript;
        }

        private void PreencherLogin()
        {
            string login = txtLogin.Text;
            string senha = txtSenha.Text;
            Usuario usuario = new UsuarioDAO().GetUsuario(login);

            string mensagem;
            if (usuario != null)
            {
                if(senha == usuario.Senha){
                    mensagem = null;
                    Session["Usuario"] = login;
                    Response.Redirect("ListagemPaises.aspx");
                }
                else {
                    mensagem = "Senha Incorreta!";
                }
            }
            else
            {
               mensagem = "Esse usuario não existe.";
            }

            if (!string.IsNullOrWhiteSpace(mensagem))
                ltrLogin.Text = $@"<br /> <p id='mensagemLogin'> {mensagem} </p>";
        }
    }
}