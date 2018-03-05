<%@ page title="Tabulare CRM" language="C#" masterpagefile="~/MasterPage/supervisor.master" autoeventwireup="true" inherits="supervisor_campanha, App_Web_scj44z0b" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <h1>
                Campanha
            </h1>
            <fieldset class="fieldset_l">
                <legend>Dados da Campanha</legend>
                <div class="div_padrao">
                    <table align="left" class="style10">
                        <tr>
                            <td class="style14">
                                &nbsp;</td>
                            <td class="style21">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style14">
                                <asp:Label ID="lblCampanha" runat="server" CssClass="label" Text="Campanha:"></asp:Label>
                            </td>
                            <td class="style21">
                                <asp:TextBox ID="txtCampanha" runat="server" CssClass="textbox" Width="485px" ReadOnly="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style14">
                                <asp:Label ID="lblOperadora" runat="server" CssClass="label" Text="Operadora:"></asp:Label>
                            </td>
                            <td class="style21">
                                <asp:TextBox ID="txtOperadora" runat="server" CssClass="textbox" Width="92px"
                                    MaxLength="2" onkeydown="mascara(this,soNumeros)" onkeypress="mascara(this,soNumeros)" onkeyup="mascara(this,soNumeros)"></asp:TextBox>
                                &nbsp; &nbsp;
                                <asp:CheckBox ID="chkEditarDadosProspect" runat="server" AutoPostBack="True" 
                                    Checked="True" CssClass="chekBoxList" 
                                    Text="Permitir editar campos no Dados do Prospect" />
                            </td>
                        </tr>
                        <tr>
                            <td class="style14">
                                <asp:Label ID="lblAtivo" runat="server" CssClass="label" Text="Ativo:"></asp:Label>
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
                                <asp:Button ID="cmdSalvar" runat="server" CssClass="botao" 
                                    onclick="cmdSalvar_Click" Text="Salvar" Width="83px" />
                                &nbsp;<asp:Button ID="cmdCancelar" runat="server" CssClass="botao" 
                                    onclick="cmdCancelar_Click" Text="Cancelar" Width="83px" />
                                &nbsp;</td>
                        </tr>
                    </table>
                </div>
                    </fieldset>
               
               <div class="div_padrao">
                <table class="style30">
                    <tr>
                        <td  align=left>
                            <asp:Label ID="lblRegistros" runat="server" CssClass="label_descricao" 
                                Text="| 0 registro(s) |"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style32">
                            <asp:GridView ID="dgCampanha" runat="server" AutoGenerateColumns="False" CssClass="grid"
                                DataKeyNames="Cód. Campanha" EnableModelValidation="True" 
                                Style="text-align: left" onrowcommand="dgCampanha_RowCommand" 
                                onrowdatabound="dgCampanha_RowDataBound">
                                <PagerStyle CssClass="grid_page" />
                                <RowStyle CssClass="grid" HorizontalAlign="Left" />
                                <Columns>
                                    <asp:BoundField DataField="Cód. Campanha" HeaderText="Cód. Campanha" />
                                    <asp:BoundField DataField="Campanha" HeaderText="Campanha" />
                                    <asp:BoundField DataField="Data de Cadastro" HeaderText="Data de Cadastro." />
                                    <asp:BoundField DataField="Operadora" HeaderText="Operadora" />
                                    <asp:BoundField DataField="Ativo" HeaderText="Ativo" />
                                    <asp:BoundField DataField="Editar Dados Prospect" HeaderText="Editar Dados Prospect" />
                                    <asp:ButtonField ButtonType="Image" CommandName="Abrir" HeaderText="Abrir" ImageUrl="~/imagens/okmenor.gif"
                                        Text="Botão" />
                                </Columns>
                                <HeaderStyle CssClass="grid_header" HorizontalAlign="Justify" />
                                <AlternatingRowStyle CssClass="grid_alternative_row" />
                            </asp:GridView>
                        </td>
                        
                    </tr>
                </table>
                </div>
                    
          
             <asp:HiddenField ID="hddId" runat="server" />
       <div class="clear"> </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
