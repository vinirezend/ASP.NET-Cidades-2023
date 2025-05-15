<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastrarEstado.aspx.cs" Inherits="ProjetoCidade.CadastrarEstado"  MasterPageFile="~/MasterPaises.Master" %>

<asp:Content ID="headCadastro" ContentPlaceHolderID="head" runat="server">
    <title>Cadastrar Estado</title>
</asp:Content>

<asp:Content ID="conteudo" ContentPlaceHolderID="Content" runat="server">
        <div class="row justify-content-center mx-2 z-1">
            <div class="card border border-dark shadow-lg col-md-4 mb-4">
                <div class="card-body">
                    <div class="form-floating mb-3">
                        <asp:TextBox ID="txtNome" class="form-control border border-dark shadow" type="text" runat="server" placeholder="Nome do estado" required MaxLength="50" ClientIDMode="Static"></asp:TextBox>
                        <label for="txtNome">Estado:</label>
                    </div>
                    <div class="form-floating mb-3">
                        <asp:TextBox ID="txtSiglaEstado" class="form-control border border-dark shadow" type="text" runat="server"  placeholder="Sigla do estado" MaxLength="2" ClientIDMode="Static"></asp:TextBox>
                        <label for="txtSiglaEstado">Sigla:</label>
                    </div>
                    <div class="form-floating  mb-3">
                        <asp:DropDownList ID="cmbPaises" class="form-select border border-dark shadow" aria-label="Default select example" runat="server"></asp:DropDownList>
                        <label for="cmbPaises">Pais:</label>
                    </div>
                    <div>
                        <button class="salvar btn btn-secondary" style="float: right;" type="submit">S<span class="d-none d-lg-inline-block">salvar</span> <i class="fa-solid fa-floppy-disk"></i></button>
                    </div>
                </div>
            </div>
        </div>

        <div id="divAccordion" class="row justify-content-center z-1">
            <div class="accordion col-md-4" id="accordionExample">
                <div class="accordion-item">
                    <h2 class="accordion-header">
                        <button class="accordion-button border border-dark border-bottom-0 text-light" type="button" data-bs-toggle="collapse" data-bs-target="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
                            Cidades desse estado
                        </button>
                    </h2>
                    <div id="collapseOne" class="accordion-collapse collapse show" data-bs-parent="#accordionExample">
                        <div class="accordion-body border border-dark border-top-0">
                            <asp:Literal ID="ltrCidades" runat="server"></asp:Literal>
                        </div>
                    </div>
                </div>
            </div>
        </div>

         

</asp:Content>

<asp:Content ID="script" ContentPlaceHolderID="script" runat="server">
    <asp:Literal ID="ltrScriptCadastro" runat="server"></asp:Literal>
</asp:Content>