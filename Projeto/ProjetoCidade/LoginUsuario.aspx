<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginUsuario.aspx.cs" Inherits="ProjetoCidade.LoginUsuario" MasterPageFile="~/MasterUsuarios.Master" %>

<asp:Content ID="headCadastro" ContentPlaceHolderID="head" runat="server">
    <title> Login Usuario </title>
    <style>
        #btnLogar{
            float: right;
        }
        #btnLogar{
            background-image: url("imagens/madeira_escura.jpg");
        }
    </style>
</asp:Content>

<asp:Content ID="bodyUsuario" ContentPlaceHolderID="conteudo" runat="server">
        <div class="m-3 col-md-4">
            <div class="principal card border border-dark">
            <div class="card-header text-center text-light">Login</div>
            <div class="card-body justify-content-center border border-dark border-start-0 border-end-0">
                <asp:TextBox ID="txtLogin" type="text" class="textBoxLogin form-control border border-dark" runat="server" AutoCompleteType="None" placeholder="Nome:" value="vini_rezende"></asp:TextBox>
                <br />
                <asp:TextBox type="password" ID="txtSenha" class="textBoxLogin form-control border border-dark" runat="server" placeholder="Senha:" value="123"></asp:TextBox>
                <br />
                <button class="btn btn-light btn-lg text-light" id="btnLogar"><b>Logar</b></button>
                <br />
                <br />
            </div>
            <div class="card-footer text-center text-light">
                    <a href='CadastrarUsuario.aspx' class="link-light" style="text-decoration: none;">Ainda não possui cadastro?  <i class="fa-solid fa-user-plus fa-1x"></i></a>
                <div class="mensagemLogin">
                    <asp:Literal ID="ltrLogin" runat="server"></asp:Literal>
                </div>
            </div>
            </div>
        </div>
</asp:Content>

<asp:Content ID="script" ContentPlaceHolderID="script" runat="server">
    <asp:Literal ID="ltrScript" runat="server"></asp:Literal>
</asp:Content>