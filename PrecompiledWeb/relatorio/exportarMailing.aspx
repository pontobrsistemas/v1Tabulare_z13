<%@ page title="Tabulare CRM" language="C#" masterpagefile="~/MasterPage/supervisor.master" autoeventwireup="true" inherits="relatorio_exportarMailing, App_Web_wym5kje3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="cmdExportar" />
        </Triggers>
        <ContentTemplate>
            <h1>
                Relatório Exportação do Mailing
            </h1>
            <fieldset class="fieldset_l">
                <legend>Filtro do Relatório</legend>
                <div class="div_padrao">
                    <table align="left" class="style10">
                        <tr>
                            <td valign="top">
                                <table class="style1">
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblCampanha" runat="server" CssClass="label" Text="Campanha:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="dropCampanha" runat="server" AutoPostBack="True" 
                                                CssClass="dropdown" OnSelectedIndexChanged="dropCampanha_SelectedIndexChanged" 
                                                Width="389px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblMailing" runat="server" CssClass="label" Text="Mailing:"></asp:Label>
                                        </td>
                                        <td>
                                            
                                            <asp:DropDownList ID="dropMailing" runat="server" CssClass="dropdown" 
                                                Width="389px">
                                            </asp:DropDownList>
                                            
                                        </td>
                                    </tr>
                                </table>
                                <br/><br/>
                                <asp:Button ID="cmdExportar" runat="server" CssClass="botao" 
                                                OnClick="cmdExportar_Click" Text="Exportar" Width="120px" />
                            </td>
                            <td rowspan="3">
                                <fieldset class="fieldset_campanha">
                                    <legend>Status da Ligação (tabulação):</legend>
                                    <div class="conteudo_campanha">
                                    <asp:CheckBoxList ID="chkStatus" runat="server" CssClass="chekBoxList_div" 
                                        RepeatColumns="1" Width="380px">
                                    </asp:CheckBoxList>
                                    </div>
                                </fieldset> &nbsp;<br />
                                <asp:Button ID="cmdTodos" runat="server" CssClass="botao" 
                                    OnClick="cmdTodos_Click" Text="Todos" Width="120px" />
                                &nbsp;<asp:Button ID="cmdNenhum" runat="server" CssClass="botao" 
                                    OnClick="cmdNenhum_Click" Text="Nenhum" Width="120px" />
                            </td>
                        </tr>
                        <tr>
                            <td height="15">
                                &nbsp;
                                <asp:Label ID="lblMensagem" runat="server" CssClass="label_observacao"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td height="15">
                                &nbsp;</td>
                        </tr>
                    </table>
                    <div style="width: 380px; float: left;">
                        
                    </div>
                </div>
            </fieldset>
            <br />
            <asp:GridView ID="dgDados" runat="server" AutoGenerateColumns="True" CssClass="grid"
                EnableModelValidation="True" Style="text-align: left" OnRowDataBound="dgDados_RowDataBound">
                <PagerStyle CssClass="grid_page" />
                <RowStyle CssClass="grid" HorizontalAlign="Left" />
                <Columns>
                </Columns>
                <HeaderStyle CssClass="grid_header" HorizontalAlign="Justify" />
                <AlternatingRowStyle CssClass="grid_alternative_row" />
            </asp:GridView>
            <div class="clear"> </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
