<%@ page title="Tabulare CRM" language="C#" masterpagefile="~/MasterPage/supervisor.master" autoeventwireup="true" inherits="relatorio_statusMailing, App_Web_wym5kje3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style10
        {
            width: 872px;
        }
        .style11
        {
            width: 73px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <Triggers>
            <asp:PostBackTrigger ControlID="btnExportar" />
        </Triggers>
        <ContentTemplate>
            <h1>
                Relatório Exportação de Mailing
            </h1>
            <fieldset class="fieldset_l">
                <legend>Filtro do Relatório</legend>
                <div class="div_padrao">
                    <table align="left" class="style10">
                        <tr>
                            <td class="style11">
                                <asp:Label ID="lblCampanha" runat="server" CssClass="label" Text="Campanha:"></asp:Label>
                            </td>
                            <td class="style21">
                                <asp:DropDownList ID="dropCampanha" runat="server" CssClass="dropdown" Width="389px"
                                    OnSelectedIndexChanged="dropCampanha_SelectedIndexChanged" AutoPostBack="True">
                                </asp:DropDownList>
                                &nbsp;&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="style11">
                                <asp:Label ID="lblMailing" runat="server" CssClass="label" Text="Mailing:"></asp:Label>
                            </td>
                            <td class="style21">
                                <asp:DropDownList ID="dropMailing" runat="server" Width="389px" CssClass="dropdown">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" height="15">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="style14" colspan="2">
                                &nbsp;
                                <asp:Button ID="cmdPesquisar" runat="server" CssClass="botao" OnClick="cmdPesquisar_Click"
                                    Text="Pesquisar" Width="120px" />
                                &nbsp;&nbsp;<asp:Button ID="btnExportar" runat="server" CssClass="botao" OnClick="btnExportar_Click"
                                    Text="Exportar" Width="120px" />
                            </td>
                        </tr>
                    </table>
                </div>
            </fieldset>
            <br/>
            <div class="div_padrao">
                    <table class="style30">
                        <tr>
                            <td class="style32" align=left>
                                <asp:Label ID="lblRegistros" runat="server" CssClass="label_descricao" Text="| 0 registro(s) |"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style32">
                                <asp:GridView ID="dgDados" runat="server" AutoGenerateColumns="False" CssClass="grid"
                                    EnableModelValidation="True" Style="text-align: left" OnRowDataBound="dgDados_RowDataBound">
                                    <PagerStyle CssClass="grid_page" />
                                    <RowStyle CssClass="grid" HorizontalAlign="Left" />
                                    <Columns>
                                        <asp:BoundField DataField="Status" HeaderText="Status" />
                                        <asp:BoundField DataField="Quant. Contatos" HeaderText="Quant. Contatos" />
                                    </Columns>
                                    <HeaderStyle CssClass="grid_header" HorizontalAlign="Justify" />
                                    <AlternatingRowStyle CssClass="grid_alternative_row" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="clear"> </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
