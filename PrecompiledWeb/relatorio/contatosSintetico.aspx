<%@ page title="Tabulare CRM" language="C#" masterpagefile="~/MasterPage/supervisor.master" autoeventwireup="true" inherits="relatorio_contatosSintetico, App_Web_wym5kje3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
  <Triggers>
            <asp:PostBackTrigger ControlID="btnExportar" />
        </Triggers>
        <ContentTemplate>
            <h1>
               Relatório Contatos Trabalhados (Sintético)
            </h1>
            <fieldset class="fieldset_l">
                <legend>Filtro</legend>
                  <div class="div_padrao">
                    <table align="left" class="style10">
                        <tr>
                            <td class="style11">
                                <asp:Label ID="lblDataInicial" runat="server" CssClass="label" 
                                    Text="Data Inicial:" Width="70px"></asp:Label>
                            </td>
                            <td class="style21">
                                <asp:TextBox ID="txtdatDataInicial" runat="server" CssClass="textbox" 
                                    style="text-align: left" onkeydown="mascara(this,data)" 
                                    onkeypress="mascara(this,data)" onkeyup="mascara(this,data)" Width="70px"></asp:TextBox>
                                <asp:CalendarExtender ID="txtdatDataInicial_CalendarExtender" runat="server" 
                                    CssClass="cal_Theme1" Format="dd/MM/yyyy" TargetControlID="txtdatDataInicial">
                                </asp:CalendarExtender>
                            </td>
                            <td class="style21" rowspan="7">

                                <fieldset class="fieldset_campanha">

                                    <legend>Status da Ligação (tabulação):</legend>
                                    <div class="conteudo_campanha">
                                    <asp:CheckBoxList ID="chkStatus" runat="server" CssClass="chekBoxList_div" 
                                        RepeatColumns="1" Width="380px">
                                    </asp:CheckBoxList>
                                    </div>
                                </fieldset>&nbsp;<br/><asp:Button ID="cmdTodos" runat="server" CssClass="botao" 
                                    onclick="cmdTodos_Click" Text="Todos" Width="120px" />
                                &nbsp;<asp:Button ID="cmdNenhum" runat="server" CssClass="botao" 
                                    onclick="cmdNenhum_Click" Text="Nenhum" Width="120px" />
                            </td>
                        </tr>
                        <tr>
                            <td class="style11">
                                <asp:Label ID="lblDataFinal" runat="server" CssClass="label" Text="Data Final:"></asp:Label>
                            </td>
                            <td class="style21">
                                <asp:TextBox ID="txtdatDataFinal" runat="server" CssClass="textbox" 
                                    style="text-align: left" onkeydown="mascara(this,data)" 
                                    onkeypress="mascara(this,data)" onkeyup="mascara(this,data)" Width="70px"></asp:TextBox>
                                <asp:CalendarExtender ID="txtdatDataFinal_CalendarExtender" runat="server" 
                                    CssClass="cal_Theme1" Format="dd/MM/yyyy" TargetControlID="txtdatDataFinal">
                                </asp:CalendarExtender>
                            </td>
                           
                        </tr>
                        <tr>
                            <td class="style11">
                                <asp:Label ID="lblCampanha" runat="server" CssClass="label" Text="Campanha:"></asp:Label>
                            </td>
                            <td class="style21">
                                <asp:DropDownList ID="dropCampanha" runat="server" AutoPostBack="True" 
                                    CssClass="dropdown" OnSelectedIndexChanged="dropCampanha_SelectedIndexChanged" 
                                    Width="389px">
                                </asp:DropDownList>
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
                            <td class="style11">
                                <asp:Label ID="lblOperador" runat="server" CssClass="label" Text="Operador:"></asp:Label>
                            </td>
                            <td class="style21">
                                <asp:DropDownList ID="dropOperador" runat="server" CssClass="dropdown" 
                                    Width="389px">
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
                                <asp:Button ID="cmdGerarDados" runat="server" CssClass="botao" OnClick="cmdGerarDados_Click"
                                    Text="Gerar Dados" Width="120px" />
                                &nbsp;&nbsp;<asp:Button ID="btnExportar" runat="server" CssClass="botao" 
                                    Text="Exportar" Width="120px" onclick="btnExportar_Click" />
                            </td>
                        </tr>
                    </table>

                    
                    <br />
                </div>
            </fieldset>
            <br/>

            <div class="div_relatorio">
                    <table >
                       <tr>
                            <td class="style32">
                                <asp:GridView ID="dgDados" runat="server" AutoGenerateColumns="True" CssClass="grid"
                                    EnableModelValidation="True" Style="text-align: left" 
                                    onrowdatabound="dgDados_RowDataBound" >
                                    <PagerStyle CssClass="grid_page" />
                                    <RowStyle CssClass="grid" HorizontalAlign="Left" />
                                    <Columns>
                                        
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
