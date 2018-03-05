<%@ Page Title="Tabulare CRM" Language="C#" MasterPageFile="~/MasterPage/supervisor.master"
    AutoEventWireup="true" CodeFile="blackList.aspx.cs" Inherits="supervisor_blackList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <%--<Triggers>
            <asp:PostBackTrigger ControlID="cmdImportar" />
        </Triggers>--%>
        <ContentTemplate>
            <h1>
                BlackList
            </h1>

            <fieldset class="fieldset_l">
                <legend>Dados do Telefone</legend>
                <div class="div_padrao">
                    <table align="left" class="style10">
                        <tr>
                            <td class="style14">
                                <asp:Label ID="lblTelefone" runat="server" CssClass="label" Text="Telefone:"></asp:Label>
                            </td>
                            <td class="style21">
                                <asp:TextBox ID="txtTelefone" runat="server" CssClass="textbox" Width="227px" MaxLength="11" 
                                   onkeydown="mascara(this,soNumeros)" onkeypress="mascara(this,soNumeros)" onkeyup="mascara(this,soNumeros)" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" height="15">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style14" colspan="2">
                                <asp:Button ID="cmdSalvar" runat="server" CssClass="botao" 
                                    onclick="cmdSalvar_Click" Text="Bloquear" Width="83px" />
                                &nbsp;&nbsp;<asp:Button ID="cmdExcluir" runat="server" CssClass="botao" 
                                    onclick="cmdExcluir_Click" Text="Excluir" Width="83px" />
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
                        <td align=left>
                            <asp:Label ID="lblRegistros" runat="server" CssClass="label_descricao" 
                                Text="| 0 registro(s) |"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style32">
                            <asp:GridView ID="dgDados" runat="server" AutoGenerateColumns="False" CssClass="grid"
                                DataKeyNames="Telefone" EnableModelValidation="True" 
                                Style="text-align: left" onrowcommand="dgDados_RowCommand" 
                                onrowdatabound="dgDados_RowDataBound">
                                <PagerStyle CssClass="grid_page" />
                                <RowStyle CssClass="grid" HorizontalAlign="Left" />
                                <Columns>
                                    <asp:BoundField DataField="Telefone" HeaderText="Telefone" />
                                    <asp:BoundField DataField="Data/Hora Cadastro" HeaderText="Data/Hora Cadastro" />
                                    <asp:BoundField DataField="Responsável pela Inclusão" HeaderText="Responsável pela Inclusão." />
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
                    
             <div class="clear"> </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

