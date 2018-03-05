<%@ page title="Tabulare CRM" language="C#" masterpagefile="~/MasterPage/supervisor.master" autoeventwireup="true" inherits="supervisor_resubmitMailing, App_Web_scj44z0b" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <h1>
                Resubmit Mailing
            </h1>
            <fieldset class="fieldset_l">
            <div class="div_padrao">
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="lblCampanha" runat="server" CssClass="label" Text="Campanha:"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="dropCampanha" runat="server" AutoPostBack="True" 
                                CssClass="dropdown" OnSelectedIndexChanged="dropCampanha_SelectedIndexChanged" 
                                Width="340px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblMailing" runat="server" CssClass="label" Text="Mailing:"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="dropMailing" runat="server" CssClass="dropdown" 
                                Width="338px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td height="15">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:Button ID="cmdEfetuarResubmit" runat="server" CssClass="botao" 
                                OnClick="cmdEfetuarResubmit_Click" Text="Efetuar resubmit" Width="120px" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </td>
                    </tr>
                </table>
                        </div>
                <legend>Dados do Mailing</legend>
                <fieldset class="fieldset_campanha">
                    <legend>Status da Ligação (tabulação)</legend>
                    <div class="conteudo_campanha">
                    <asp:CheckBoxList ID="chkLStatus" runat="server" CssClass="chekBoxList_div" 
                        RepeatColumns="1" Width="380px">
                    </asp:CheckBoxList>
                    </div>
                </fieldset>
                <div class="div_botao_checkboxlist">
                <asp:Button ID="cmdTodos" runat="server" CssClass="botao" OnClick="cmdTodos_Click" Height="27px" Text="Todos" Width="120px" />
                &nbsp;<asp:Button ID="cmdNenhum" runat="server" CssClass="botao" OnClick="cmdNenhum_Click" Height="27px" Text="Nenhum" Width="120px" />
               <asp:Button ID="cmdCalcular" runat="server" CssClass="botao" OnClick="cmdCalcular_Click" Height="27px" Text="Calcular quantidades" Width="150px" />
           </div>
            </fieldset><br />
            <fieldset class="fieldset_l">
                <legend>Filtro Avançado</legend>
                <div class="div_padrao">
                    <asp:CheckBox ID="chkFiltroAvancado" runat="server" CssClass="chekBoxList" Text="Usar Filtro Avançado como parâmetro para o Resubmit" />
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="lblDataInicial" runat="server" CssClass="label" Text="Data Inicial:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="datDataInicial" runat="server" CssClass="textbox" Width="337px"></asp:TextBox>
                                <asp:CalendarExtender ID="datDataInicial_CalendarExtender" runat="server" CssClass="cal_Theme1"
                                    TargetControlID="datDataInicial">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                <asp:Label ID="lblBairro" runat="server" CssClass="label" Text="Bairro:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtBairro" runat="server" CssClass="textbox" Width="337px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDataFinal" runat="server" CssClass="label" Text="Data Final:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="datDataFinal" runat="server" CssClass="textbox" Width="337px"></asp:TextBox>
                                <asp:CalendarExtender ID="datDataFinal_CalendarExtender" runat="server" CssClass="cal_Theme1"
                                    TargetControlID="datDataFinal">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                <asp:Label ID="lblCidade" runat="server" CssClass="label" Text="Cidade:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCidade" runat="server" CssClass="textbox" Width="337px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblOperador" runat="server" CssClass="label" Text="Operador:"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="dropOperador" runat="server" CssClass="dropdown" Width="340px">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="lblCEP" runat="server" CssClass="label" Text="CEP:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCep" runat="server" CssClass="textbox" Width="337px" onkeydown="mascara(this,soNumeros)" onkeypress="mascara(this,soNumeros)" onkeyup="mascara(this,soNumeros)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </div>
            </fieldset>
            <div class="clear"> </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
