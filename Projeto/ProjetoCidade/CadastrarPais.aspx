<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastrarPais.aspx.cs" Inherits="ProjetoCidade.CadastrarPais" MasterPageFile="~/MasterPaises.Master" %>

<asp:Content ID="headCadastro" ContentPlaceHolderID="head" runat="server">
    <title>Cadastrar País</title>
    <style>
    </style>
</asp:Content>


<asp:Content ID="conteudo" ContentPlaceHolderID="Content" runat="server">
        <div class="row justify-content-center mx-2 z-1">
            <div class="card border border-dark shadow-lg col-md-4 mx-2 mb-4">
                <div class="card-body">
                    <div class="form-floating mb-3">
                        <asp:TextBox id="txtNome" Class="form-control border border-dark shadow" type="text" runat="server" placeholder="Nome do pais" MaxLength="50" ClientIDMode="Static"></asp:TextBox>
                        <label for="txtNome">Pais:</label>
                    </div>
                    <div class="input-group mb-3">
                        <span class="input-group-text border border-dark border-end-0">+</span>
                        <div class="form-floating">
                        <asp:TextBox id="txtDDD" class="form-control border border-dark shadow" type="text" runat="server" placeholder="DDD do pais" MaxLength="3" ClientIDMode="Static"></asp:TextBox>
                        <label for="txtDDD">DDD:</label>
                        </div>
                    </div>
                    <div>
                        <button class="btnAdicionar btn btn-secondary" style="float: right;" id="btnAdd" type="submit" onclick="LinkButtonAdd_Click"><span class="d-none d-lg-inline-block">salvar</span> <i class="fa-solid fa-floppy-disk"></i></button>
                    </div>
                </div>
            </div>
        </div>
        
        <div id="divAccordion" class="row justify-content-center z-1">
            <div class="accordion col-md-4" id="accordionExample">
                <div class="accordion-item">
                    <h2 class="accordion-header">
                        <button class="accordion-button border border-dark border-bottom-0 text-light" type="button" data-bs-toggle="collapse" data-bs-target="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
                            Estados desse Pais
                        </button>
                    </h2>
                    <div id="collapseOne" class="accordion-collapse collapse show" data-bs-parent="#accordionExample">
                        <div class="accordion-body border border-dark border-top-0">
                            <asp:Literal ID="ltrEstados" runat="server"></asp:Literal>
                        </div>
                    </div>
                </div>
            </div>
        </div>

</asp:Content>

<asp:Content ID="script" ContentPlaceHolderID="script" runat="server">
    <asp:Literal ID="ltrScriptCadastro" runat="server"></asp:Literal>
</asp:Content>
