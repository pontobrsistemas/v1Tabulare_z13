<%@ Page Title="Tabulare CRM" Language="C#" MasterPageFile="~/MasterPage/supervisor.master"
    AutoEventWireup="true" CodeFile="vendasSintetico.aspx.cs" Inherits="supervisor_vendasSintetico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style10
        {
            height: 173px;
            width: 500px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <Triggers>
            <asp:PostBackTrigger ControlID="btnExportar" />
        </Triggers>
        <ContentTemplate>--%>
    <h1>
        Relatório Vendas Sintético (Conversão)
    </h1>
    <fieldset class="fieldset_l">
        <legend>Filtro do Relatório</legend>
        <div class="conteudo">
            <div style="width: 500px; float: left;">
                <table align="left" class="style10">
                    <tr align="left">
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblDataInicial" runat="server" CssClass="label" Text="Data Inicial:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtdatDataInicial" runat="server" CssClass="textbox" Style="text-align: left"
                                onkeydown="mascara(this,data)" onkeypress="mascara(this,data)" onkeyup="mascara(this,data)"
                                Width="70px"></asp:TextBox>
                            <asp:CalendarExtender ID="txtdatDataInicial_CalendarExtender" runat="server" CssClass="cal_Theme1"
                                Format="dd/MM/yyyy" TargetControlID="txtdatDataInicial">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lblDataFinal" runat="server" CssClass="label" Text="Data Final:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtdatDataFinal" runat="server" CssClass="textbox" Style="text-align: left"
                                onkeydown="mascara(this,data)" onkeypress="mascara(this,data)" onkeyup="mascara(this,data)"
                                Width="70px"></asp:TextBox>
                            <asp:CalendarExtender ID="txtdatDataFinal_CalendarExtender" runat="server" CssClass="cal_Theme1"
                                Format="dd/MM/yyyy" TargetControlID="txtdatDataFinal">
                            </asp:CalendarExtender>
                            &nbsp; &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lblAuditoria" runat="server" CssClass="label" Text="Auditoria:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="dropAuditoria" runat="server" CssClass="dropdown" Width="389px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" height="15">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2">
                            <asp:Button ID="cmdGerar" runat="server" CssClass="botao" Text="Gerar Dados" OnClick="cmdGerar_Click" />
                            &nbsp;<asp:Button ID="btnExportar" runat="server" CssClass="botao" OnClick="btnExportar_Click"
                                Text="Exportar" />
                        </td>
                    </tr>
                </table>
            </div>
            <fieldset class="fieldset_campanha">
                <legend>Campanha</legend>
                <div class="conteudo_campanha">
                    <asp:CheckBoxList ID="chkCampanha" runat="server" CssClass="chekBoxList_div" RepeatColumns="1"
                        Width="380px">
                    </asp:CheckBoxList>
                </div>
            </fieldset>
            <div class="div_botao_checkboxlist">
                <asp:Button ID="bTnTodos" runat="server" CssClass="botao" Height="27px" Text="Todos"
                    OnClick="bTnTodos_Click" Width="83px" />
                &nbsp;<asp:Button ID="bTnNenhum" runat="server" CssClass="botao" Height="27px" Text="Nenhum"
                    OnClick="bTnNenhum_Click" Width="83px" />
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
                    <asp:GridView ID="dgDados" runat="server" CssClass="grid" EnableModelValidation="True"
                        Style="text-align: left" AutoGenerateColumns="false" OnRowDataBound="dgDados_RowDataBound">
                        <PagerStyle CssClass="grid_page" />
                        <RowStyle CssClass="grid" HorizontalAlign="Left" />
                        <Columns>
                            <asp:BoundField DataField="Usuario" HeaderText="Operador" />
                            <asp:BoundField DataField="Contatos" HeaderText="Contatos" />
                            <asp:BoundField DataField="Vendas" HeaderText="Vendas" />
                            <asp:BoundField DataField="" HeaderText="Conversão" />
                            <asp:BoundField DataField="ProspectsUnicos" HeaderText="Prospects<br/>Únicos" HtmlEncode="False" />
                            <asp:BoundField DataField="" HeaderText="Conversão<br/>(Prospects Únicos)" HtmlEncode="False" />
                        </Columns>
                        <HeaderStyle CssClass="grid_header" HorizontalAlign="Justify" />
                        <AlternatingRowStyle CssClass="grid_alternative_row" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
    <asp:HiddenField ID="hddId" runat="server" />
   <%-- </ContentTemplate> 
    </asp:UpdatePanel>--%>

    <fieldset class="fieldset_l_dashboard"  runat="server" id="fieldsetVendasSintetico" visible="false">
        <legend runat="server" id="legenda_VendasSintetico">Vendas Sintético</legend>
        <asp:Literal ID="lblScript" runat="server"></asp:Literal>
        <div id="VendasSintetico" style="width: 905px; height: 200px;"/>
    </fieldset>
    <div class="clear"> </div>
</asp:Content>
