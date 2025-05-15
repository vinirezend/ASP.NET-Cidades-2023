<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListagemPaises.aspx.cs" Inherits="ProjetoCidade.ListagemPaises"  MasterPageFile="~/MasterPaises.Master"%>

<asp:Content ID="headCadastro" ContentPlaceHolderID="head" runat="server">
    <title>Lista de Paises</title>
</asp:Content>

<asp:Content ID="conteudo" ContentPlaceHolderID="Content" runat="server">

<div class="row justify-content-center">
    <div class="table-responsive col-md-6">
        <table class="text-center divLista table table-warning table-striped table-hover border border-dark">
            <thead>
                <tr>
                    <th id="pesquisa">
                        <div class="d-flex justify-content-between">
                            <div style="width: 32px; height: 37px;"></div>
                            <div>
                                <h4>Pais</h4>
                            </div>
                            <div id="divFiltros">
                                <button id="btnFiltros" type="button" data-bs-toggle="offcanvas" data-bs-target="#offcanvasExample" aria-controls="offcanvasExample">
                                    <i class="fa-solid fa-filter fa-lg"></i>
                                </button>
                            </div>
                        </div>
                    </th>
                    <th>
                        <h4>
                            Editar
                        </h4>
                    </th>
                    <th>
                        <h4>
                            Excluir
                        </h4>
                    </th>
                </tr>
            </thead>
            <tbody>
                <asp:Literal ID="ltrTodosPaises" runat="server"></asp:Literal>
            </tbody>
        </table>
    </div>
</div>
    
<div class="offcanvas offcanvas-start" tabindex="-1" id="offcanvasExample" aria-labelledby="offcanvasExampleLabel">
    <div class="offcanvas-header">
    <h5 class="offcanvas-title" id="offcanvasExampleLabel">Pesquisar e ordenar por:</h5>
    <button type="button" class="btn-close" data-bs-dismiss="offcanvas" aria-label="Close"></button>
    </div>
    <div class="offcanvas-body">
        <div class="mb-3">
            <label for="pesquisaPaises" class="form-label">Pesquisa:</label>
            <asp:TextBox ID="pesquisaPaises" class="form-control border border-dark" type="text" runat="server"></asp:TextBox>
        </div>
        <div>
            <label for="filtroPaises">Ordenar por:</label>
            <asp:DropDownList ID="filtroPaises" class="form-select border border-dark" aria-label="Default select example" runat="server">
                <asp:ListItem Value="Nome">Nome do país</asp:ListItem>
                <asp:ListItem Value="CodigoPais">Ordem de Cadastro</asp:ListItem>
                <asp:ListItem  Value="DDD">DDD do país</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div>
            <button class='btnAplicar btn btn-secondary m-2' type="submit"><i class="fa-solid fa-check"></i></button>
        </div>
    </div>
</div>

<div class="row justify-content-center">
    <span style="width: min-content;">
        <a id="add" class="btn" href="CadastrarPais.aspx" role="button">
            <i class="fa-solid fa-plus fa-2xl"></i>
        </a>
    </span>
</div>

</asp:Content>
        
<asp:Content ID="Jquery" ContentPlaceHolderID="script" runat="server">
        <script src="bootstrap/JS/jquery.js"></script>
        <script>
           $(function () {
                $(".btnRemover").click(function () {
                    if (confirm("Deseja remover esse pais?")) {
                        let button = $(this);
                        let codigo = button.data("codigo");

                        $.ajax({
                            global: true,
                            url: "Ajax.aspx/DeletarPais",
                            data: `{ codigoPais: ${codigo} }`,
                            contentType: "application/json",
                            dataType: "json",
                            type: "post",
                            success: function (d) {
                                $(`[data-codigo='${d.d}']`).closest("tr").remove();
                            },
                            error: function (err) {
                                alert(`Erro ao excluir pais: ${err}`);
                            }
                        })
                    }
                })
            })

            $("#botaoPesquisar").click(function () {
                if ($(".divPesquisa").is(":visible")) {
                    $(".divPesquisa").hide();
                } else {
                    $(".divPesquisa").show();
                }
            })

            $(".divPesquisa").hide();

            $("#botaoFiltrar").click(function () {
                if ($(".divFiltro").is(":visible")) {
                    $(".divFiltro").hide();
                } else {
                    $(".divFiltro").show();
                }
            })

            $(".divFiltro").hide();
        </script>
</asp:Content> 