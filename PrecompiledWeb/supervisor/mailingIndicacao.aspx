<%@ page title="Tabulare CRM" language="C#" masterpagefile="~/MasterPage/supervisor.master" autoeventwireup="true" inherits="supervisor_mailingIndicacao, App_Web_scj44z0b" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style10
        {
            width: 872px;
        }
        .style11
        {
            height: 21px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <h1>
                Mailing Indicação
            </h1>
            <fieldset class="fieldset_l">
                <legend>Dados do Mailing Indicação (Cadastro manual)</legend>
                <div class="div_padrao">
                    <table align="left" class="style10">
                        <tr>
                            <td class="style14">
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
                            <td class="style11">
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
                                <asp:Button ID="cmdSalvar" runat="server" CssClass="botao" Height="27px" OnClick="cmdSalvar_Click"
                                    Text="Salvar" Width="83px" />
                                &nbsp;<asp:Button ID="cmdCancelar" runat="server" CssClass="botao" Height="27px"
                                    OnClick="cmdCancelar_Click" Text="Cancelar" Width="83px" />
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </div>
            </fieldset>

            <div class="div_padrao">
                <table>
                <br>
                    <td align="left">
                        <asp:Label ID="lblRegistros" runat="server" CssClass="label_descricao" Text="| 0 registro(s) |"></asp:Label><br />
                        <asp:GridView ID="grdDados" runat="server" AutoGenerateColumns="False" CssClass="grid"
                            EnableModelValidation="True" Style="text-align: left" OnRowDataBound="grdDados_RowDataBound">
                            <PagerStyle CssClass="grid_page" />
                            <RowStyle CssClass="grid" HorizontalAlign="Left" /> 
                            <Columns>
                                <asp:BoundField DataField="Campanha" HeaderText="Campanha" />
                                <asp:BoundField DataField="Mailing" HeaderText="Mailing Indicação" />
                            </Columns>
                            <HeaderStyle CssClass="grid_header" HorizontalAlign="Justify" />
                            <AlternatingRowStyle CssClass="grid_alternative_row" />
                        </asp:GridView>
                         </td>
                </table>
            </div>
             <div class="clear"> </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
