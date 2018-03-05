<%@ page title="Tabulare CRM" language="C#" masterpagefile="~/MasterPage/supervisor.master" autoeventwireup="true" inherits="supervisor_mailing, App_Web_scj44z0b" %>

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
            <asp:PostBackTrigger ControlID="cmdImportar" />
        </Triggers>
        <ContentTemplate>
            <h1>
                Mailing
            </h1>
            <fieldset class="fieldset_l">
                <legend>Dados do Mailing</legend>
                <div class="div_padrao">
                    <table align="left" class="style10">
                        <tr>
                            <td class="style14">
                                <asp:Label ID="lblNome" runat="server" CssClass="label" Text="Nome do Mailing:"></asp:Label>
                            </td>
                            <td class="style21">
                                <asp:TextBox ID="txtMailing" runat="server" CssClass="textbox" Width="314px"></asp:TextBox>
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
                            <td class="style14">
                                <asp:Label ID="lblArquivo" runat="server" CssClass="label" Text="Arquivo:"></asp:Label>
                            </td>
                            <td class="style21">
                                <asp:FileUpload ID="fileDocumento" runat="server" CssClass="textbox" Width="330px" />
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td class="style14">
                                <asp:Label ID="lblCampanha" runat="server" CssClass="label" Text="Campanha:"></asp:Label>
                            </td>
                            <td class="style21">
                                <asp:DropDownList ID="dropCampanha" runat="server" CssClass="dropdown" 
                                    Width="400px" AutoPostBack="True" 
                                    onselectedindexchanged="dropCampanha_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="style14">
                                &nbsp;</td>
                            <td height="15">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style14" colspan="2">
                                <asp:Button ID="cmdSalvar" runat="server" CssClass="botao" Height="27px" 
                                    OnClick="cmdSalvar_Click" Text="Salvar" Width="83px" />
                                &nbsp;<asp:Button ID="cmdImportar" runat="server" CssClass="botao" Height="27px" 
                                    OnClick="cmdImportar_Click" Text="Importar" Width="83px" />
                                &nbsp;<asp:Button ID="cmdCancelar" runat="server" CssClass="botao" Height="27px" 
                                    OnClick="cmdCancelar_Click" Text="Cancelar" Width="83px" />
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style14" colspan="2">
                                <asp:Label ID="lblMensagem" runat="server" CssClass="label_observacao"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>

                
                
            
            <div class="div_padrao_direita">
                                <asp:CheckBox ID="chkDuplicado" runat="server" CssClass="chekBoxList" 
                                    Text="Não importar telefones já existentes na base de dados" />
                                    <br/>
                                    <br/><br/><br/>
                                    <asp:HyperLink ID="hypMascara" runat="server" CssClass="link_mascara" 
                                    NavigateUrl="~/documentos/importacao_mailing.xlsm" Target="_blank">Clique aqui para baixar a máscara de importação</asp:HyperLink>
                         
                            <asp:HiddenField ID="hddId" runat="server" />
                       
                                
                       
            </div>
            </fieldset> 
            <fieldset class="fieldset_l">
            <div class="div_padrao" >
                    <table class="style30">
                        <tr>
                            <td  align=left>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td  align=left>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:GridView ID="grdMailingPlanilha" runat="server" 
                                    AutoGenerateColumns="False" CssClass="grid" DataKeyNames="Cód. Mailing" 
                                    EnableModelValidation="True" OnRowCommand="grdDados_RowCommand" 
                                    OnRowDataBound="grdDados_RowDataBound" Style="text-align: left">
                                    <PagerStyle CssClass="grid_page" />
                                    <RowStyle CssClass="grid" HorizontalAlign="Left" />
                                    <Columns>
                                        <asp:BoundField DataField="Mailing" HeaderText="Mailing" />
                                        <asp:BoundField DataField="Campanha" HeaderText="Campanha" />
                                        <asp:BoundField DataField="Data Cadastro" HeaderText="Data Cadastro" />
                                        <asp:BoundField DataField="Ativo" HeaderText="Ativo" />
                                        <asp:ButtonField ButtonType="Image" CommandName="Abrir" HeaderText="Abrir" 
                                            ImageUrl="~/imagens/okmenor.gif" Text="Botão" />
                                    </Columns>
                                    <HeaderStyle CssClass="grid_header" HorizontalAlign="Justify" />
                                    <AlternatingRowStyle CssClass="grid_alternative_row" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblRegistros" runat="server" CssClass="label_descricao"></asp:Label>
                                -
                                <asp:CheckBox ID="chkAtivos" runat="server" AutoPostBack="True" Checked="True" 
                                    CssClass="chekBoxList" oncheckedchanged="chkAtivos_CheckedChanged" 
                                    Text="Listar apenas ativos" />
                            </td>
                        </tr>
                        <tr>
                            <td class="style32">
                                <asp:GridView ID="grdDados" runat="server" AutoGenerateColumns="False" CssClass="grid"
                                    DataKeyNames="Cód. Mailing" EnableModelValidation="True" OnRowCommand="grdDados_RowCommand"
                                    OnRowDataBound="grdDados_RowDataBound" Style="text-align: left">
                                    <PagerStyle CssClass="grid_page" />
                                    <RowStyle CssClass="grid" HorizontalAlign="Left" />
                                    <Columns>
                                        <asp:BoundField DataField="Mailing" HeaderText="Mailing" />
                                        <asp:BoundField DataField="Campanha" HeaderText="Campanha" />
                                        <asp:BoundField DataField="Data Cadastro" HeaderText="Data Cadastro" />
                                        <asp:BoundField DataField="Ativo" HeaderText="Ativo" />
                                        <asp:ButtonField ButtonType="Image" CommandName="Abrir" HeaderText="Abrir" 
                                        ImageUrl="~/imagens/okmenor.gif" Text="Botão" />
                                    </Columns>
                                    <HeaderStyle CssClass="grid_header" HorizontalAlign="Justify" />
                                    <AlternatingRowStyle CssClass="grid_alternative_row" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td class="style31">
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
