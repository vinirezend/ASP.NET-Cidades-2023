<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListagemCidades.aspx.cs" Inherits="ProjetoCidade.ListagemCidades"  MasterPageFile="~/MasterPaises.Master" %>

<asp:Content ID="headCadastro" ContentPlaceHolderID="head" runat="server">
<title>Lista de Cidades</title>
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
                                <h4>Cidade</h4>
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
                <asp:Literal ID="ltrTodasCidades" runat="server"></asp:Literal>
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
            <label for="pesquisaCidades" class="form-label">Pesquisa:</label>
            <asp:TextBox ID="pesquisaCidades" class="form-control border border-dark" type="text" runat="server"></asp:TextBox>
        </div>
        <div>
            <label for="filtroCidades">Ordenar por:</label>
            <asp:DropDownList ID="filtroCidades" class="form-select border border-dark" aria-label="Default select example" runat="server">
                <asp:ListItem Value="Nome">Nome da Cidade</asp:ListItem>
                <asp:ListItem  Value="CodigoCidade">Ordem de Cadastro</asp:ListItem>
                <asp:ListItem Value="CodigoEstado">Estado</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div>
            <button class='btnAplicar btn btn-secondary m-2' type="submit"><i class="fa-solid fa-check"></i></button>
        </div>
    </div>
    </div>

    <div class="row justify-content-center">
    <span style="width: min-content;">
        <a id="add" class="btn" href="CadastrarCidade.aspx" role="button">
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
                    if (confirm("Deseja remover esse cidade?")) {
                        let button = $(this);
                        let codigo = button.data("codigo");

                        $.ajax({
                            global: true,
                            url: "Ajax.aspx/DeletarCidade",
                            data: `{ codigoCidade: ${codigo} }`,
                            contentType: "application/json",
                            dataType: "json",
                            type: "post",
                            success: function (d){
                                alert('A cidade foi excluida com sucesso!');
                                $(`[data-codigo='${d.d}']`).closest("tr").remove();
                            },
                            error: function (err) {
                                alert(`Erro ao excluir cidade: ${err}`);
                            }
                        })
                    }
                })

                $("#botaoPesquisar").click(function(){
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
                //Ordenacao por JQuery
                //let trs = $("tbody tr");

                //for (var i = 0; i < trs.length; i++) {
                //    for (var j = i + 1; j < trs.length; j++) {
                //        let tr = $(trs[i]);
                //        let tr2 = $(trs[j]);

                //        if (tr.find("td:first").data("nome") < tr2.find("td:first").data("nome")) {
                //            let aux = trs[j];
                //            trs[j] = trs[i];
                //            trs[i] = aux;
                //        }
                //    }
                //}
                //let html = trs.map(function () {
                //    return this.outerHTML;
                //});
                //$("tbody").html(html.toArray().reverse().join());
            })
        </script>
</asp:Content>