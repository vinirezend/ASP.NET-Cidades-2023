<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastrarUsuario.aspx.cs" Inherits="ProjetoCidade.CadastrarUsuario" MasterPageFile="~/MasterUsuarios.Master" %>

<asp:Content ID="headCadastro" ContentPlaceHolderID="head" runat="server">
    <title> Cadastro Usuario </title>
</asp:Content>

<asp:Content ID="bodyUsuario" ContentPlaceHolderID="conteudo" runat="server">
    <div class="m-3 col-md-4">
        <div class="principal card border border-dark">
            <div class="card-header text-center text-light">Cadastro</div>
            <div class="card-body border border-dark border-start-0 border-end-0">
                <asp:TextBox ID="txtNome" class="textBoxCadastro form-control border border-dark" type="text" runat="server" required MaxLength="50" placeholder="Nome completo:"></asp:TextBox>
                <br />
                <asp:TextBox ID="txtLogin" class="textBoxCadastro form-control border border-dark" type="text" runat="server" required MaxLength="50" placeholder="Crie um login"></asp:TextBox>
                <asp:Literal ID="ltrLoginRepetido" runat="server"></asp:Literal>
                <br />
                <asp:TextBox ID="txtSenha" class="textBoxCadastro form-control border border-dark" type="text" runat="server" required ClientIDMode="Static" MaxLength="20" placeholder="Crie uma senha"></asp:TextBox>
                <p id="msgSeguranca"></p>
            </div>
            <div class="card-footer d-flex justify-content-between">
                <a href="LoginUsuario.aspx" class="text-light"><i class="fa-solid fa-arrow-left-long fa-2x"></i></a>
                <button id="btnCadastrarUsuario" class="mx-2 btn btn-light" type="button"><i class="fa-solid fa-check"></i></button>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="script" ContentPlaceHolderID="script" runat="server">
    <script type="text/javascript">

        var txtsenha = document.querySelector("#txtSenha");

        txtsenha.addEventListener("keyup", () => {
            var senha = txtsenha.value.length;
            if (senha == 0) {
                document.getElementById("msgSeguranca").innerHTML = null;
            }
            if (senha <= 4) {
                document.getElementById("msgSeguranca").innerHTML = "Senha fraca";
                document.getElementById("msgSeguranca").style.color = "red";
            }
            else if (senha > 4 && senha <= 9) {
                document.getElementById("msgSeguranca").innerHTML = "Senha Media";
                document.getElementById("msgSeguranca").style.color = "#a7a73e";
            }
            else {
                document.getElementById("msgSeguranca").innerHTML = "Senha forte";
                document.getElementById("msgSeguranca").style.color = "green";
            }

        })

    </script>
</asp:Content>