<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastrarCidade.aspx.cs" Inherits="ProjetoCidade.CadastrarCidade"  MasterPageFile="~/MasterPaises.Master" %>

<asp:Content ID="headCadastro" ContentPlaceHolderID="head" runat="server">
    <title>Cadastrar Cidade</title>
</asp:Content>

<asp:Content ID="conteudo" ContentPlaceHolderID="Content" runat="server">
        <div class="row justify-content-center mx-2 z-1">
            <div class="card border border-dark shadow-lg col-md-4 mb-4">
                <div class="card-body">
                    <div class="form-floating mb-3">
                        <asp:TextBox ID="txtNome" class="form-control border border-dark shadow" type="text" runat="server" placeholder="Nome da cidade" required MaxLength="50" ClientIDMode="Static"></asp:TextBox>
                        <label for="txtNome">Cidade:</label>
                    </div>
                    <div class="form-floating mb-3">
                        <asp:DropDownList ID="cmbEstados" class="form-select border border-dark shadow" aria-label="Default select example" runat="server"></asp:DropDownList>
                        <label for="cmbEstados">Estado:</label>
                    </div>
                    <div>
                        <button class="salvar btn btn-secondary" style="float: right;" type="submit"><span class="d-none d-lg-inline-block">salvar</span> <i class="fa-solid fa-floppy-disk"></i></button>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>

<asp:Content ID="script" ContentPlaceHolderID="script" runat="server">
    <asp:Literal ID="ltrScriptCadastro" runat="server"></asp:Literal>
</asp:Content>