<%@ page title="Tabulare CRM" language="C#" masterpagefile="~/MasterPage/supervisor.master" autoeventwireup="true" inherits="relatorio_clienteFiltro, App_Web_wym5kje3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
        </Triggers>
        <ContentTemplate>
            <h1>
                <asp:Label ID="lblTituloFormulario" runat="server" Text="Consultar Cliente" CssClass="label_h1"></asp:Label>
            </h1>
            <fieldset class="fieldset_l">
                <legend>Filtro do Relatório</legend>
                <div class="div_padrao">
                    <table class="style1">
                        <tr>
                            <td class="style12" style="text-align: left">
                                <asp:Label ID="lblTelfone1" runat="server" CssClass="label" Text="Telefone:"></asp:Label>
                            </td>
                            <td class="style3" style="text-align: left">
                                <asp:TextBox ID="txtTelefone1_filtro" runat="server" CssClass="textbox" MaxLength="11"
                                    Style="text-align: left" onkeydown="mascara(this,soNumeros)" onkeypress="mascara(this,soNumeros)" onkeyup="mascara(this,soNumeros)"></asp:TextBox>
                            </td>
                            <td class="style11" style="text-align: left">
                                &nbsp;
                            </td>
                            <td class="style5" style="text-align: left">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="style12" style="text-align: left">
                                <asp:Label ID="lblNome" runat="server" CssClass="label" Text="Nome:"></asp:Label>
                            </td>
                            <td class="style3" style="text-align: left">
                                <asp:TextBox ID="txtNome_filtro" runat="server" CssClass="textbox" Style="text-align: left"
                                    Width="208px" MaxLength="200"></asp:TextBox>
                            </td>
                            <td class="style11" style="text-align: left">
                                <asp:Label ID="lblCPFCNPJ" runat="server" CssClass="label" Text="CPF / CNPJ:" 
                                    Width="70px"></asp:Label>
                            </td>
                            <td class="style5" style="text-align: left">
                                <asp:TextBox ID="txtCPFCNPJ_filtro" runat="server" CssClass="textbox" Style="text-align: left"
                                    MaxLength="18" onkeydown="mascara(this,soNumeros)" onkeypress="mascara(this,soNumeros)" onkeyup="mascara(this,soNumeros)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left" colspan="4" height="15">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="style12" colspan="4" style="text-align: left">
                                <asp:Button ID="btnGerar" runat="server" CssClass="botao" OnClick="btnGerar_Click"
                                    Text="Pesquisar" />
                                &nbsp;
                            </td>
                        </tr>
                    </table>
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
                            <asp:GridView ID="grdDados" CssClass="grid" runat="server" AutoGenerateColumns="False"
                                EnableModelValidation="True" OnRowDataBound="grdDados_RowDataBound" DataKeyNames="Cód. Prospect">
                                <Columns>
                                    <asp:BoundField DataField="Nome Prospect" HeaderText="Nome Prospect" />
                                    <asp:BoundField DataField="CPF / CNPJ" HeaderText="CPF / CNPJ" />
                                    <asp:BoundField DataField="Telefone 1" HeaderText="Telefone 1" />
                                    <asp:BoundField DataField="Telefone 2" HeaderText="Telefone 2" />
                                    <asp:BoundField DataField="Telefone 3" HeaderText="Telefone 3" />
                                    <asp:BoundField DataField="Mailing" HeaderText="Mailing" />
                                    <asp:BoundField DataField="Campanha" HeaderText="Campanha" />
                                    <asp:BoundField DataField="Último Status" HeaderText="Último Status" />
                                    <asp:BoundField DataField="Data Último Contato" HeaderText="Data Último Contato" />
                                    <asp:BoundField DataField="Usuário do Sistema" HeaderText="Usuário do Sistema" />
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
