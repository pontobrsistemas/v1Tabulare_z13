<%@ page title="Tabulare CRM" language="C#" masterpagefile="~/MasterPage/supervisor.master" autoeventwireup="true" inherits="supervisor_usuario, App_Web_scj44z0b" %>

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
        <ContentTemplate>
            <h1>
                Usuário
            </h1>
            <fieldset class="fieldset_l">
                <legend>Dados do Usuário</legend>
                <div class="conteudo">
                    <div style="width: 500px; float: left;">
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="lblNome" runat="server" CssClass="label" Text="Nome:"></asp:Label>
                                </td>
                                <td class="style21">
                                    <asp:TextBox ID="txtNome" runat="server" CssClass="textbox" Width="314px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblLogin" runat="server" CssClass="label" Text="Login:"></asp:Label>
                                </td>
                                <td class="style21">
                                    <asp:TextBox ID="txtLogin" runat="server" CssClass="textbox"></asp:TextBox>
                                    <asp:Label ID="lblSenha" runat="server" CssClass="label" Text="Senha:"></asp:Label>
                                    <asp:TextBox ID="txtSenha" runat="server" CssClass="textbox" TextMode="Password"
                                        Width="110px"></asp:TextBox>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblPerfil" runat="server" CssClass="label" Text="Perfil:"></asp:Label>
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="radPerfil" runat="server" CssClass="radiobutton" RepeatDirection="Horizontal">
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblAtivo" runat="server" CssClass="label" Text="Ativo:"></asp:Label>
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="radAtivo" runat="server" CssClass="radiobutton" RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True" Value="1">Sim</asp:ListItem>
                                        <asp:ListItem Value="0">Não</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td height="15">
                                    <asp:HiddenField ID="hddId" runat="server" />
                                </td>
                            </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Button ID="cmdSalvar" runat="server" CssClass="botao" Height="27px" 
                                            OnClick="cmdSalvar_Click" Text="Salvar" Width="83px" />
                                        &nbsp;<asp:Button ID="cmdCancelar" runat="server" CssClass="botao" Height="27px" 
                                            OnClick="cmdCancelar_Click" Text="Cancelar" Width="83px" />
                                        &nbsp;<asp:Button ID="cmdFechar" runat="server" CssClass="botao" Height="27px" 
                                            Text="Fechar" Width="83px" />
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
                        <asp:Button ID="bTnTodos" runat="server" CssClass="botao" Height="27px" OnClick="bTnTodos_Click"
                            Text="Todas" Width="83px" />
                        &nbsp;<asp:Button ID="bTnNenhum" runat="server" CssClass="botao" Height="27px" OnClick="bTnNenhum_Click"
                            Text="Nenhuma" Width="83px" />
                            </div>

                   </div>
                 </fieldset>           
            <div class="div_padrao">
                <table>
                    <tr>
                        <td align="left">
                            <asp:CheckBox ID="CheckBoxUsuariosAtivos" runat="server" AutoPostBack="True" Checked="True"
                                CssClass="chekBoxList" OnCheckedChanged="CheckBoxUsuariosAtivos_CheckedChanged"
                                Text="Listar apenas usuários ativos" />
                        </td>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblUsuariosAtivos" runat="server" CssClass="label_descricao" Text="0 operador(es) ativo(s)"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="gridUsuario" runat="server" AutoGenerateColumns="False" CssClass="grid"
                                    DataKeyNames="Cód. Usuário" EnableModelValidation="True" OnRowCommand="gridUsuario_RowCommand"
                                    OnRowDataBound="gridUsuario_RowDataBound" Style="text-align: left" Width="850px">
                                    <PagerStyle CssClass="grid_page" />
                                    <RowStyle CssClass="grid" HorizontalAlign="Left" />
                                    <Columns>
                                        <asp:BoundField DataField="Nome" HeaderText="Nome" />
                                        <asp:BoundField DataField="Login" HeaderText="Login" />
                                        <asp:BoundField DataField="Perfil" HeaderText="Perfil" />
                                        <asp:BoundField DataField="Perfil" HeaderText="Campanha" />
                                        <asp:BoundField DataField="Ativo" HeaderText="Ativo" />
                                        <asp:ButtonField ButtonType="Image" CommandName="Abrir" HeaderText="Abrir" ImageUrl="~/imagens/okmenor.gif"
                                            Text="Botão" />
                                    </Columns>
                                    <HeaderStyle CssClass="grid_header" HorizontalAlign="Justify" />
                                    <AlternatingRowStyle CssClass="grid_alternative_row" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </tr>
                </table>
            </div>
           <div class="clear"> </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
