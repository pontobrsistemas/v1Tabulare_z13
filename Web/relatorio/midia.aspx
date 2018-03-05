<%@ Page Title="Tabulare CRM" Language="C#" MasterPageFile="~/MasterPage/supervisor.master"
    AutoEventWireup="true" CodeFile="midia.aspx.cs" Inherits="supervisor_midia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script language="javascript" type="text/javascript">
        function fechatudo() {
            var oMe = window.self;
            oMe.opener = window.self;
            oMe.close();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="cmdExportar" />
        </Triggers>
        <ContentTemplate>
            <h1>
                Relatório de Mídia
            </h1>
            <fieldset class="fieldset_l">
                <legend>Filtro do Relatório</legend>
                <div class="conteudo">
                    <div style="width: 500px; float: left; height: 185px;">
                        <table>
                            <tr>
                                <td class="style14" align="right">
                                    <asp:Label ID="lblDataInicial" runat="server" CssClass="label" Text="Data Inicial:"></asp:Label>
                                </td>
                                <td class="style21" align="left">
                                    <asp:TextBox ID="txtdatDataInicial" runat="server" CssClass="textbox" Style="text-align: left"
                                    onkeydown="mascara(this,data)" onkeypress="mascara(this,data)" 
                                        onkeyup="mascara(this,data)" Width="70px"></asp:TextBox>
                                    <asp:CalendarExtender ID="txtdatDataInicial_CalendarExtender" runat="server" CssClass="cal_Theme1"
                                        Format="dd/MM/yyyy" TargetControlID="txtdatDataInicial">
                                    </asp:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td class="style14" align="right">
                                    <asp:Label ID="lblDataFinal" runat="server" CssClass="label" Text="Data Final:"></asp:Label>
                                </td>
                                <td class="style21" align="left">
                                    <asp:TextBox ID="txtdatDataFinal" runat="server" CssClass="textbox" Style="text-align: left"
                                    onkeydown="mascara(this,data)" onkeypress="mascara(this,data)" 
                                        onkeyup="mascara(this,data)" Width="70px"></asp:TextBox>
                                    <asp:CalendarExtender ID="txtdatDataFinal_CalendarExtender" runat="server" CssClass="cal_Theme1"
                                        Format="dd/MM/yyyy" TargetControlID="txtdatDataFinal">
                                    </asp:CalendarExtender>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td class="style14" colspan="2">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="style14" colspan="2">
                                    <asp:Button ID="cmdGerar" runat="server" CssClass="botao" OnClick="cmdGerar_Click"
                                        Text="Gerar Dados" Width="120px" />
                                    &nbsp;<asp:Button ID="cmdExportar" runat="server" CssClass="botao" OnClick="cmdExportar_Click"
                                        Text="Exportar Dados" Width="120px" />
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </div>
                    <fieldset class="fieldset_campanha">
                        <legend>Campanha</legend>
                        <div class="conteudo_campanha">
                            <asp:CheckBoxList ID="chkCampanha" runat="server" CssClass="chekBoxList_div" RepeatColumns="1" Width="380px">
                            </asp:CheckBoxList>
                        </div>
                        </fieldset>
                        <div class="div_botao_checkboxlist">
                        <asp:Button ID="bTnTodos" runat="server" CssClass="botao" Text="Todos"
                             OnClick="bTnTodos_Click" Width="120px" />
                        &nbsp;<asp:Button ID="bTnNenhum" runat="server" CssClass="botao"  Text="Nenhum"
                           OnClick="bTnNenhum_Click" Width="120px" />
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                        </div>
                </div>
            </fieldset>
            <div class="div_relatorio">
                <table>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lblRegistros" runat="server" CssClass="label_descricao" Text="| 0 registro(s) |"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="dgDados" runat="server" AutoGenerateColumns="False" CssClass="grid"
                                EnableModelValidation="True" OnRowDataBound="dgDados_RowDataBound" Style="text-align: left">
                                <PagerStyle CssClass="grid_page" />
                                <RowStyle CssClass="grid" HorizontalAlign="Left" />
                                <Columns>
                                    <asp:BoundField DataField="Midia" HeaderText="Mídia" />
                                    <asp:BoundField DataField="Quantidade" HeaderText="Contatos" />
                                    <asp:BoundField DataField="Vendas" HeaderText="Vendas" />
                                    <asp:BoundField DataField="" HeaderText="Conversão" />
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
