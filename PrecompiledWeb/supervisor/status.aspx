<%@ page title="Tabulare CRM" language="C#" masterpagefile="~/MasterPage/supervisor.master" autoeventwireup="true" inherits="supervisor_status, App_Web_scj44z0b" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <h1>
                Status
            </h1>
            <fieldset class="fieldset_l">
                <legend>Dados do Status</legend>
                <div class="div_padrao">
                <table  >
                    <tr>
                        <td >
                            <asp:Label ID="lbCampanha" runat="server" CssClass="label" Text="Campanha:"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="dropCampanha" runat="server" Width="487px" CssClass="dropdown"
                                AutoPostBack="True" OnSelectedIndexChanged="dropCampanha_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="style14">
                            <asp:Label ID="lblStatus" runat="server" CssClass="label" Text="Status:"></asp:Label>
                        </td>
                        <td class="style21">
                            <asp:TextBox ID="txtStatus" runat="server" CssClass="textbox" Width="485px" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style14">
                            <asp:Label ID="lblQtdTentativas" runat="server" CssClass="label" Text="Quant. Tentativas:"></asp:Label>
                        </td>
                        <td class="style21">
                            <asp:TextBox ID="txtQtdeTentativas" runat="server" CssClass="textbox" Width="92px"
                                MaxLength="2" onkeydown="mascara(this,soNumeros)" onkeypress="mascara(this,soNumeros)" onkeyup="mascara(this,soNumeros)"></asp:TextBox>
                            &nbsp;
                            <asp:Label ID="lblAcao" runat="server" CssClass="label" Text="Ação:"></asp:Label>
                            <asp:DropDownList ID="dropAcao" Enabled="false" runat="server" CssClass="dropdown"
                                Width="130px">
                            </asp:DropDownList>
                            &nbsp;
                            <asp:Label ID="lblTempoRetorno" runat="server" CssClass="label" Text="Tempo Retorno:"></asp:Label>
                            <asp:TextBox ID="txtHoraRetorno" runat="server" CssClass="textbox" Width="95px" MaxLength="5"
                            onkeydown="mascara(this,horas)" onkeypress="mascara(this,horas)" onkeyup="mascara(this,horas)"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style14">
                            <asp:Label ID="lblAtivo" runat="server" CssClass="label" 
                                Text="Ativo:"></asp:Label>
                        </td>
                        <td class="style21">
                            <asp:RadioButtonList ID="radAtivo" runat="server" CssClass="radiobutton" 
                                RepeatDirection="Horizontal">
                                <asp:ListItem Selected="True" Value="1">Sim</asp:ListItem>
                                <asp:ListItem Value="0">Não</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" height="15">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style14" colspan="2">
                            <asp:Button ID="cmdSalvar" runat="server" CssClass="botao" Height="27px" 
                                OnClick="cmdSalvar_Click" Text="Salvar" Width="83px" />
                            &nbsp;<asp:Button ID="cmdCancelar" runat="server" CssClass="botao" 
                                OnClick="cmdCancelar_Click" Text="Cancelar" Width="83px" />
                            &nbsp;</td>
                    </tr>
                </table>  
                </div>
                
               <asp:HiddenField ID="hddId" runat="server" />
            </div>
            </fieldset>
            
            <table class="style30">
                    <tr>
                        <td align=left>
                            <asp:Label ID="lblRegistro" runat="server" CssClass="label_descricao"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style32">
                            <asp:GridView ID="dgStatus" runat="server" AutoGenerateColumns="False" CssClass="grid"
                                DataKeyNames="Cód. Status" EnableModelValidation="True" OnRowCommand="dgStatus_RowCommand"
                                OnRowDataBound="dgStatus_RowDataBound" Style="text-align: left">
                                <PagerStyle CssClass="grid_page" />
                                <RowStyle CssClass="grid" HorizontalAlign="Left" />
                                <Columns>
                                    <asp:BoundField DataField="Status" HeaderText="Status" />
                                    <asp:BoundField DataField="Acao" HeaderText="Ação" />
                                    <asp:BoundField DataField="Qtde Tent." HeaderText="Qtde Tent." />
                                    <asp:BoundField DataField="Tempo Retorno" HeaderText="Tempo Retorno" />
                                    <asp:BoundField DataField="Ativo" HeaderText="Ativo" />
                                    <asp:ButtonField ButtonType="Image" CommandName="Abrir" HeaderText="Abrir" ImageUrl="~/imagens/okmenor.gif"
                                        Text="Botão" />
                                </Columns>
                                <HeaderStyle CssClass="grid_header" HorizontalAlign="Justify" />
                                <AlternatingRowStyle CssClass="grid_alternative_row" />
                            </asp:GridView>
                        </td>
                    </tr>
                    </table>
                        <div class="clear"> </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
