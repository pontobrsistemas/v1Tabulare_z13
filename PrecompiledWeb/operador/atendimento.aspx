<%@ page title="Tabulare CRM" language="C#" masterpagefile="~/MasterPage/operador.master" autoeventwireup="true" inherits="operador_atendimento, App_Web_wzw5p3vb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script language="javascript" type="text/javascript">
        function fechatudo() {
            var oMe = window.self;
            oMe.opener = window.self;
            oMe.close();
        }
    </script>
    <%--  Verifica se já existe Telefone cadastado na base--%>
    <script type="text/javascript">
        function doPostBack(t) {
            if (t.value != "") {
                __doPostBack(t.name, "");
            }
        }
    </script>
    <style type="text/css">
        .style1
        {
            background-color: rgb(245, 245, 245);
            border-bottom: 2px solid #fff;
            width: 235px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <%--  <h1>
                Atendimento&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblAlertaMsg" runat="server" ForeColor="Red" Text="-" 
                    Visible="False"></asp:Label>
            </h1>--%>
            <table style="width: 992px">
                <tr>
                    <td class="celula_nome_campo" colspan="7">
                        <div class="bg_titulo titulo_claro" style="width: auto;">
                            <div class="titulo_left bg_title_color1">
                                <asp:Label ID="Label3" runat="server" Text="Atendimento"></asp:Label>
                            </div>
                            <asp:Label ID="lblAlertaMsg" runat="server" ForeColor="Red" Text="-" Visible="False"></asp:Label>
                        </div>
                    </td>
                </tr>
            </table>
            <div>
                <table class="style1">
                    <tr>
                        <td class="style7">
                            <asp:Button ID="bTnProximoProspect" runat="server" Text="Próximo Prospect" CssClass="botao"
                                OnClick="bTnProximoProspect_Click" />
                        </td>
                        <td class="style8">
                            <asp:Button ID="bTnSalvarContato" runat="server" Text="Salvar Contato" CssClass="botao"
                                OnClick="bTnSalvarContato_Click" />
                        </td>
                        <td style="text-align: left" class="style13">
                            <asp:Button ID="bTnCadastrar" runat="server" align="left" CssClass="botao" OnClick="bTnCadastrar_Click"
                                Text="Cadastro Manual" />
                        </td>
                        <td class="style13" style="text-align: left">
                            <asp:Button ID="bTnCancelarInd" runat="server" CssClass="botao" OnClick="bTnCancelarInd_Click"
                                Text="Cancelar Cadastro" />
                        </td>
                        <td class="style13" style="text-align: left">
                            <asp:Button ID="bTnDiscar" runat="server" CssClass="botao" OnClick="bTnDiscar_Click"
                                Text="Discar" />
                        </td>
                        <td class="style13" style="text-align: left">
                            <asp:Button ID="bTnDesconectar" runat="server" CssClass="botao" OnClick="bTnDesconectar_Click"
                                Text="Desconectar" />
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <div>
                <asp:TabContainer ID="TabContainerAtendimento" runat="server" Width="990px" ActiveTabIndex="0"
                    align="left" Height="1133px">
                    <asp:TabPanel ID="Prospect" HeaderText="Prospect" runat="server">
                        <HeaderTemplate>
                            Prospect
                        </HeaderTemplate>
                        <ContentTemplate>
                            <br />
                            <fieldset class="fieldset_atendimento" id="PainelDadosProspect" runat="server">
                                <legend>Dados do Prospect</legend>
                                <table>
                                    <tr>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblMailing" runat="server" CssClass="label" Text="Mailing:"></asp:Label>
                                        </td>
                                        <td class="celula_campo" colspan="4">
                                            <asp:TextBox ID="txtMailing" runat="server" CssClass="textbox" ReadOnly="True" Width="369px"></asp:TextBox>
                                        </td>
                                        <td class="celula_campo">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblNome" runat="server" CssClass="label" Text="Nome:"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtNome" runat="server" CssClass="textbox" MaxLength="100" Width="190px"></asp:TextBox>
                                        </td>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblCPF" runat="server" CssClass="label" Text="CPF/CNPJ:"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtCPF_CNPJ" runat="server" CssClass="textbox" MaxLength="15" onkeydown="mascara(this,soNumeros)"
                                                onkeypress="mascara(this,soNumeros)" onkeyup="mascara(this,soNumeros)"></asp:TextBox>
                                        </td>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblCampanha" runat="server" CssClass="label" Text="Campanha:"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:DropDownList ID="dropCampanha" runat="server" AutoPostBack="True" CssClass="dropdown"
                                                OnSelectedIndexChanged="dropCampanha_SelectedIndexChanged" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblTelefone1" runat="server" CssClass="label" Text="Telefone1:"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtTelefone1" runat="server" CssClass="textbox" MaxLength="11" onblur="doPostBack(this)"
                                                onkeydown="mascara(this,soNumeros)" onkeypress="mascara(this,soNumeros)" onkeyup="mascara(this,soNumeros)"
                                                OnTextChanged="txtTelefone1_TextChanged"></asp:TextBox>
                                        </td>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblTelefone2" runat="server" CssClass="label" Text="Telefone2:"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtTelefone2" runat="server" CssClass="textbox" MaxLength="11" onkeydown="mascara(this,soNumeros)"
                                                onkeypress="mascara(this,soNumeros)" onkeyup="mascara(this,soNumeros)"></asp:TextBox>
                                        </td>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblTelefone3" runat="server" CssClass="label" Text="Telefone3:"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtTelefone3" runat="server" CssClass="textbox" MaxLength="11" onkeydown="mascara(this,soNumeros)"
                                                onkeypress="mascara(this,soNumeros)" onkeyup="mascara(this,soNumeros)"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblLogradouro" runat="server" CssClass="label" Text="Logradouro:"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtLogradouro" runat="server" CssClass="textbox" MaxLength="100"
                                                Width="190px"></asp:TextBox>
                                        </td>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblNum" runat="server" CssClass="label" Text="Núm:"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtNumero" runat="server" CssClass="textbox" MaxLength="50" onkeydown="mascara(this,soNumeros)"
                                                onkeypress="mascara(this,soNumeros)" onkeyup="mascara(this,soNumeros)"></asp:TextBox>
                                        </td>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblComplemento" runat="server" CssClass="label" Text="Compl:"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtComplemento" runat="server" CssClass="textbox" MaxLength="50"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblBairro" runat="server" CssClass="label" Text="Bairro:"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtBairro" runat="server" CssClass="textbox" MaxLength="100" Width="190px"></asp:TextBox>
                                        </td>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblCidade" runat="server" CssClass="label" Text="Cidade:"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtCidade" runat="server" CssClass="textbox" MaxLength="100" Width="190px"></asp:TextBox>
                                        </td>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblEstado" runat="server" CssClass="label" Text="Estado:"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtEstado" runat="server" CssClass="textbox" MaxLength="50" Width="190px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblEmail" runat="server" CssClass="label" Text="Email:"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtEmail" runat="server" CssClass="textbox" MaxLength="100" Width="190px"></asp:TextBox>
                                        </td>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblCep" runat="server" CssClass="label" Text="CEP:"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtCep" runat="server" CssClass="textbox" MaxLength="10" onkeydown="mascara(this,soNumeros)"
                                                onkeypress="mascara(this,soNumeros)" onkeyup="mascara(this,soNumeros)" Width="190px"></asp:TextBox>
                                        </td>
                                        <td class="celula_nome_campo">
                                            <asp:Button ID="bTnBuscarCep" runat="server" CssClass="botao" OnClick="bTnBuscarCep_Click"
                                                Text="Pesquisar" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblCampo01" runat="server" CssClass="label" Text="Campo01" Visible="False"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtCampo01" runat="server" CssClass="textbox" MaxLength="100" Visible="False"
                                                Width="190px"></asp:TextBox>
                                            <asp:DropDownList ID="dropCampo01" runat="server" CssClass="dropdown" Visible="False"
                                                Width="190px">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblCampo02" runat="server" CssClass="label" Text="Campo02" Visible="False"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtCampo02" runat="server" CssClass="textbox" MaxLength="100" Visible="False"
                                                Width="190px"></asp:TextBox>
                                            <asp:DropDownList ID="dropCampo02" runat="server" CssClass="dropdown" Visible="False"
                                                Width="190px">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblCampo03" runat="server" CssClass="label" Text="Campo03" Visible="False"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtCampo03" runat="server" CssClass="textbox" MaxLength="100" Visible="False"
                                                Width="190px"></asp:TextBox>
                                            <asp:DropDownList ID="dropCampo03" runat="server" CssClass="dropdown" Visible="False"
                                                Width="190px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblCampo04" runat="server" CssClass="label" Text="Campo04" Visible="False"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtCampo04" runat="server" CssClass="textbox" MaxLength="100" Visible="False"
                                                Width="190px"></asp:TextBox>
                                            <asp:DropDownList ID="dropCampo04" runat="server" CssClass="dropdown" Visible="False"
                                                Width="190px">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblCampo05" runat="server" CssClass="label" Text="Campo05" Visible="False"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtCampo05" runat="server" CssClass="textbox" MaxLength="100" Visible="False"
                                                Width="190px"></asp:TextBox>
                                            <asp:DropDownList ID="dropCampo05" runat="server" CssClass="dropdown" Visible="False"
                                                Width="190px">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblCampo06" runat="server" CssClass="label" Text="Campo06" Visible="False"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtCampo06" runat="server" CssClass="textbox" MaxLength="100" Visible="False"
                                                Width="190px"></asp:TextBox>
                                            <asp:DropDownList ID="dropCampo06" runat="server" CssClass="dropdown" Visible="False"
                                                Width="190px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblCampo07" runat="server" CssClass="label" Text="Campo07" Visible="False"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtCampo07" runat="server" CssClass="textbox" MaxLength="100" Visible="False"
                                                Width="190px"></asp:TextBox>
                                            <asp:DropDownList ID="dropCampo07" runat="server" CssClass="dropdown" Visible="False"
                                                Width="190px">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblCampo08" runat="server" CssClass="label" Text="Campo08" Visible="False"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtCampo08" runat="server" CssClass="textbox" MaxLength="100" Visible="False"
                                                Width="190px"></asp:TextBox>
                                            <asp:DropDownList ID="dropCampo08" runat="server" CssClass="dropdown" Visible="False"
                                                Width="190px">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblCampo09" runat="server" CssClass="label" Text="Campo09" Visible="False"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtCampo09" runat="server" CssClass="textbox" MaxLength="100" Visible="False"
                                                Width="190px"></asp:TextBox>
                                            <asp:DropDownList ID="dropCampo09" runat="server" CssClass="dropdown" Visible="False"
                                                Width="190px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblCampo10" runat="server" CssClass="label" Text="Campo10" Visible="False"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtCampo10" runat="server" CssClass="textbox" MaxLength="100" Visible="False"
                                                Width="190px"></asp:TextBox>
                                            <asp:DropDownList ID="dropCampo10" runat="server" CssClass="dropdown" Visible="False"
                                                Width="190px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    </tr>
                                </table>
                            </fieldset>
                            <fieldset class="fieldset_atendimento" id="Fieldset1" runat="server">
                                <legend>Status de interação</legend>
                                <table class="style1">
                                    <tr>
                    <td class="celula_nome_campo">
                       <asp:Label ID="Label31" runat="server" CssClass="label" Text="Resultado Contato:"></asp:Label>
                    </td>
                    <td class="celula_campo">
                       <asp:DropDownList ID="dropStatus" runat="server" Width="417px" OnSelectedIndexChanged="dropStatus_SelectedIndexChanged"
                                                AutoPostBack="True" CssClass="dropdown">
                                            </asp:DropDownList>
                    </td>
                    <td class="celula_nome_campo">
                      <asp:Label ID="lblData" runat="server" CssClass="label" Text="Data:" Visible="False"></asp:Label>
                    </td>
                    <td class="celula_campo">
                      <asp:TextBox ID="txtDataAgendamento" runat="server" Width="144px" Visible="False"
                                                CssClass="textbox" onkeydown="mascara(this,data)" onkeypress="mascara(this,data)"
                                                onkeyup="mascara(this,data)"></asp:TextBox>
                    </td>
                    <td class="celula_nome_campo">
                       <asp:Label ID="lblHora" runat="server" CssClass="label" Text="Hora:" Visible="False"></asp:Label>
                    </td>
                    <td class="celula_campo">
                       <asp:TextBox ID="txtHoraAgendamento" runat="server" CssClass="textbox" Visible="False"
                                                Width="56px" onkeydown="mascara(this,horas)" onkeypress="mascara(this,horas)"
                                                onkeyup="mascara(this,horas)"></asp:TextBox>
                    </td>
                     
                    <td class="celula_campo">
                          <asp:CalendarExtender ID="txtDataAgendamento_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                                                TargetControlID="txtDataAgendamento" Enabled="True" CssClass="cal_Theme1">
                                            </asp:CalendarExtender>
                    </td>
                </tr>



                                    <tr>
                                        <td class="celula_nome_campo">
                                        <asp:Label ID="lblAgendarPara" runat="server" CssClass="label" Text="Agendar para:"></asp:Label>
                                            </td>
                                        <td class="celula_campo">
                                            <asp:DropDownList ID="dropOperadorAgendamento" runat="server" Width="417px" 
                                                CssClass="dropdown">
                                            </asp:DropDownList>
                                            </td>
                                    
                                    </tr>



                                    <tr>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="Label32" runat="server" CssClass="label" Text="Mídia:"></asp:Label></td>
                                        <td class="celula_campo">
                                            <asp:DropDownList ID="dropMidias" runat="server" Width="417px" CssClass="dropdown">
                                            </asp:DropDownList></td>
                                    </tr>
                                  
                                </table>
                            </fieldset>
                            <br />
                            <asp:Panel ID="PainelScript" runat="server" GroupingText="Script" CssClass="panel_l">
                                <tr>
                    <td class="celula_nome_campo">
                       
                    </td>
                    <td class="celula_campo">
                       
                    </td>
                    <td class="celula_nome_campo">
                      
                    </td>
                    <td class="celula_campo">
                      
                    </td>
                    <td class="celula_nome_campo">
                       
                    </td>
                    <td class="celula_campo">
                       
                    </td>
                </tr>

                                <table class="style1">
                                    <tr>
                                        <td class="style6">
                                            <asp:Label ID="lblPergunta" runat="server" CssClass="label" Text="Pergunta:"></asp:Label>
                                        </td>
                                        <td class="style6" colspan="2">
                                            <asp:Label ID="lblTextoDaPergunta" runat="server" CssClass="label"></asp:Label>
                                            <asp:Button ID="bTnReiniciarScript" runat="server" CssClass="botao" Text="Reiniciar Script"
                                                align="right" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblScripLigacao" runat="server" CssClass="label" Text="Script Respostas:"></asp:Label>
                                        </td>
                                        <td class="style6">
                                            <asp:ListBox ID="lsbRespostas" runat="server" Width="400px" CssClass="listBox"></asp:ListBox>
                                        </td>
                                        <td class="style6">
                                            <asp:GridView ID="dgResposta" runat="server" CssClass="grid" Height="75px" Width="300px">
                                                <PagerStyle CssClass="grid_page" />
                                                <RowStyle CssClass="grid" HorizontalAlign="Left" />
                                                <HeaderStyle CssClass="grid_header" HorizontalAlign="Justify" />
                                                <AlternatingRowStyle CssClass="grid_alternative_row" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblScripLigacao0" runat="server" CssClass="label" Text="Informação:"></asp:Label>
                                        </td>
                                        <td class="style6" colspan="2">
                                            <asp:TextBox ID="txtInformacao" runat="server" CssClass="textbox" Width="815px" Height="40px"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:HiddenField ID="hddId" runat="server" />
                            <asp:Timer ID="timerAtualizarMensagens" runat="server" Interval="30000" OnTick="timerAtualizarMensagens_Tick">
                            </asp:Timer>
                            <br />
                            <fieldset id="PanelObservacao" runat="server" class="fieldset_atendimento_observacao">
                                <legend>Observação</legend>
                                <asp:TextBox ID="txtObservacao" runat="server" CssClass="textbox" Height="119px"
                                    MaxLength="3000" TextMode="MultiLine" Width="511px"></asp:TextBox>
                            </fieldset>
                            <fieldset class="fieldset_atendimento_observacao">
                                <legend>Top 5 da semana</legend>
                                <asp:Label ID="lblTopSemanal" runat="server" CssClass="label_top"></asp:Label>
                            </fieldset>
                            <br />
                            <fieldset class="fieldset_atendimento" id="PanelHistorico" runat="server">
                                <legend>Histórico de contatos com o Prospect</legend>
                                <asp:CheckBox ID="chkMailingDiferente" runat="server" OnCheckedChanged="chkMailingDiferente_CheckedChanged"
                                    Text="Exibir histórico deste telefone em outros mailings" AutoPostBack="True"
                                    CssClass="chekBoxList" />
                                <br />
                                <asp:Label ID="lblRegistros" runat="server" CssClass="label_descricao"></asp:Label>
                                <asp:GridView ID="dgHistorico" runat="server" CssClass="grid" Align="left" Width="940px"
                                    AutoGenerateColumns="False" OnRowDataBound="dgHistorico_RowDataBound">
                                    <RowStyle CssClass="grid" HorizontalAlign="Left" />
                                    <Columns>
                                        <asp:BoundField DataField="Status" HeaderText="Status" />
                                        <asp:BoundField DataField="Observação" HeaderText="Observação" />
                                        <asp:BoundField DataField="Mailing" HeaderText="Mailing" />
                                        <asp:BoundField DataField="Campanha" HeaderText="Campanha" />
                                        <asp:BoundField DataField="Usuário" HeaderText="Usuário" />
                                        <asp:BoundField DataField="Data Contato" HeaderText="Data Contato" />
                                    </Columns>
                                    <HeaderStyle CssClass="grid_header" HorizontalAlign="Justify" />
                                    <AlternatingRowStyle CssClass="grid_alternative_row" />
                                </asp:GridView>
                            </fieldset>
                            <br />
                        </ContentTemplate>
                    </asp:TabPanel>
                    <asp:TabPanel ID="DadosVenda" runat="server" HeaderText="Dados da Venda">
                        <HeaderTemplate>
                            Dados da Venda
                        </HeaderTemplate>
                        <ContentTemplate>
                            <br />
                            <fieldset class="fieldset_l" id="PainelDadosVenda" runat="server">
                                <legend>Dados da Venda</legend>
                                <br />
                                <table class="style10">
                                    <tr>
                    <td class="celula_nome_campo">
                       
                        <asp:Label ID="lblVenda01" runat="server" CssClass="label" Text="Venda01" 
                            Visible="False"></asp:Label>
                       
                    </td>
                    <td class="celula_campo">
                       
                        <asp:TextBox ID="txtVenda01" runat="server" CssClass="textbox" Visible="False" 
                            Width="200px"></asp:TextBox>
                        <asp:DropDownList ID="dropVenda01" runat="server" CssClass="dropdown" 
                            Visible="False" Width="200px">
                        </asp:DropDownList>
                       
                    </td>
                    <td class="celula_nome_campo">
                      
                        <asp:Label ID="lblVenda02" runat="server" CssClass="label" Text="Venda02" 
                            Visible="False"></asp:Label>
                      
                    </td>
                    <td class="celula_campo">
                      
                        <asp:TextBox ID="txtVenda02" runat="server" CssClass="textbox" Visible="False" 
                            Width="200px"></asp:TextBox>
                        <asp:DropDownList ID="dropVenda02" runat="server" CssClass="dropdown" 
                            Visible="False" Width="200px">
                        </asp:DropDownList>
                      
                    </td>
                    <td class="celula_nome_campo">
                       
                        <asp:Label ID="lblVenda03" runat="server" CssClass="label" Text="Venda03" 
                            Visible="False"></asp:Label>
                       
                    </td>
                    <td class="celula_campo">
                       
                        <asp:TextBox ID="txtVenda03" runat="server" CssClass="textbox" Visible="False" 
                            Width="200px"></asp:TextBox>
                        <asp:DropDownList ID="dropVenda03" runat="server" CssClass="dropdown" 
                            Visible="False" Width="200px">
                        </asp:DropDownList>
                       
                    </td>
                </tr>





                                    <tr>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblVenda04" runat="server" CssClass="label" Text="Venda04" 
                                                Visible="False"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtVenda04" runat="server" CssClass="textbox" Visible="False" 
                                                Width="200px"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda04" runat="server" CssClass="dropdown" 
                                                Visible="False" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblVenda05" runat="server" CssClass="label" Text="Venda05" 
                                                Visible="False"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtVenda05" runat="server" CssClass="textbox" Visible="False" 
                                                Width="200px"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda05" runat="server" CssClass="dropdown" 
                                                Visible="False" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblVenda06" runat="server" CssClass="label" Text="Venda06" 
                                                Visible="False"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtVenda06" runat="server" CssClass="textbox" Visible="False" 
                                                Width="200px"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda06" runat="server" CssClass="dropdown" 
                                                Visible="False" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblVenda07" runat="server" CssClass="label" Text="Venda07" 
                                                Visible="False"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtVenda07" runat="server" CssClass="textbox" Visible="False" 
                                                Width="200px"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda07" runat="server" CssClass="dropdown" 
                                                Visible="False" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblVenda08" runat="server" CssClass="label" Text="Venda08" 
                                                Visible="False"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtVenda08" runat="server" CssClass="textbox" Visible="False" 
                                                Width="200px"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda08" runat="server" CssClass="dropdown" 
                                                Visible="False" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblVenda09" runat="server" CssClass="label" Text="Venda09" 
                                                Visible="False"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtVenda09" runat="server" CssClass="textbox" Visible="False" 
                                                Width="200px"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda09" runat="server" CssClass="dropdown" 
                                                Visible="False" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblVenda10" runat="server" CssClass="label" Text="Venda10" 
                                                Visible="False"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtVenda10" runat="server" CssClass="textbox" Visible="False" 
                                                Width="200px"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda10" runat="server" CssClass="dropdown" 
                                                Visible="False" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblVenda11" runat="server" CssClass="label" Text="Venda11" 
                                                Visible="False"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtVenda11" runat="server" CssClass="textbox" Visible="False" 
                                                Width="200px"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda11" runat="server" CssClass="dropdown" 
                                                Visible="False" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblVenda12" runat="server" CssClass="label" Text="Venda12" 
                                                Visible="False"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtVenda12" runat="server" CssClass="textbox" Visible="False" 
                                                Width="200px"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda12" runat="server" CssClass="dropdown" 
                                                Visible="False" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblVenda13" runat="server" CssClass="label" Text="Venda13" 
                                                Visible="False"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtVenda13" runat="server" CssClass="textbox" Visible="False" 
                                                Width="200px"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda13" runat="server" CssClass="dropdown" 
                                                Visible="False" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblVenda14" runat="server" CssClass="label" Text="Venda14" 
                                                Visible="False"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtVenda14" runat="server" CssClass="textbox" Visible="False" 
                                                Width="200px"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda14" runat="server" CssClass="dropdown" 
                                                Visible="False" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblVenda15" runat="server" CssClass="label" Text="Venda15" 
                                                Visible="False"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtVenda15" runat="server" CssClass="textbox" Visible="False" 
                                                Width="200px"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda15" runat="server" CssClass="dropdown" 
                                                Visible="False" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblVenda16" runat="server" CssClass="label" Text="Venda16" 
                                                Visible="False"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtVenda16" runat="server" CssClass="textbox" Visible="False" 
                                                Width="200px"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda16" runat="server" CssClass="dropdown" 
                                                Visible="False" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblVenda17" runat="server" CssClass="label" Text="Venda17" 
                                                Visible="False"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtVenda17" runat="server" CssClass="textbox" Visible="False" 
                                                Width="200px"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda17" runat="server" CssClass="dropdown" 
                                                Visible="False" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblVenda18" runat="server" CssClass="label" Text="Venda18" 
                                                Visible="False"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtVenda18" runat="server" CssClass="textbox" Visible="False" 
                                                Width="200px"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda18" runat="server" CssClass="dropdown" 
                                                Visible="False" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblVenda19" runat="server" CssClass="label" Text="Venda19" 
                                                Visible="False"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtVenda19" runat="server" CssClass="textbox" Visible="False" 
                                                Width="200px"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda19" runat="server" CssClass="dropdown" 
                                                Visible="False" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblVenda20" runat="server" CssClass="label" Text="Venda20" 
                                                Visible="False"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtVenda20" runat="server" CssClass="textbox" Visible="False" 
                                                Width="200px"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda20" runat="server" CssClass="dropdown" 
                                                Visible="False" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblVenda21" runat="server" CssClass="label" Text="Venda21" 
                                                Visible="False"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtVenda21" runat="server" CssClass="textbox" Visible="False" 
                                                Width="200px"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda21" runat="server" CssClass="dropdown" 
                                                Visible="False" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblVenda22" runat="server" CssClass="label" Text="Venda22" 
                                                Visible="False"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtVenda22" runat="server" CssClass="textbox" Visible="False" 
                                                Width="200px"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda22" runat="server" CssClass="dropdown" 
                                                Visible="False" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblVenda23" runat="server" CssClass="label" Text="Venda23" 
                                                Visible="False"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtVenda23" runat="server" CssClass="textbox" Visible="False" 
                                                Width="200px"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda23" runat="server" CssClass="dropdown" 
                                                Visible="False" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblVenda24" runat="server" CssClass="label" Text="Venda24" 
                                                Visible="False"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtVenda24" runat="server" CssClass="textbox" Visible="False" 
                                                Width="200px"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda24" runat="server" CssClass="dropdown" 
                                                Visible="False" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblVenda25" runat="server" CssClass="label" Text="Venda25" 
                                                Visible="False"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtVenda25" runat="server" CssClass="textbox" Visible="False" 
                                                Width="200px"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda25" runat="server" CssClass="dropdown" 
                                                Visible="False" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblVenda26" runat="server" CssClass="label" Text="Venda26" 
                                                Visible="False"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtVenda26" runat="server" CssClass="textbox" Visible="False" 
                                                Width="200px"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda26" runat="server" CssClass="dropdown" 
                                                Visible="False" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblVenda27" runat="server" CssClass="label" Text="Venda27" 
                                                Visible="False"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtVenda27" runat="server" CssClass="textbox" Visible="False" 
                                                Width="200px"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda27" runat="server" CssClass="dropdown" 
                                                Visible="False" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblVenda28" runat="server" CssClass="label" Text="Venda28" 
                                                Visible="False"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtVenda28" runat="server" CssClass="textbox" Visible="False" 
                                                Width="200px"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda28" runat="server" CssClass="dropdown" 
                                                Visible="False" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblVenda29" runat="server" CssClass="label" Text="Venda29" 
                                                Visible="False"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtVenda29" runat="server" CssClass="textbox" Visible="False" 
                                                Width="200px"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda29" runat="server" CssClass="dropdown" 
                                                Visible="False" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblVenda30" runat="server" CssClass="label" Text="Venda30" 
                                                Visible="False"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtVenda30" runat="server" CssClass="textbox" Visible="False" 
                                                Width="200px"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda30" runat="server" CssClass="dropdown" 
                                                Visible="False" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblVenda31" runat="server" CssClass="label" Text="Venda31" 
                                                Visible="False"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtVenda31" runat="server" CssClass="textbox" Visible="False" 
                                                Width="200px"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda31" runat="server" CssClass="dropdown" 
                                                Visible="False" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblVenda32" runat="server" CssClass="label" Text="Venda32" 
                                                Visible="False"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtVenda32" runat="server" CssClass="textbox" Visible="False" 
                                                Width="200px"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda32" runat="server" CssClass="dropdown" 
                                                Visible="False" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblVenda33" runat="server" CssClass="label" Text="Venda33" 
                                                Visible="False"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtVenda33" runat="server" CssClass="textbox" Visible="False" 
                                                Width="200px"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda33" runat="server" CssClass="dropdown" 
                                                Visible="False" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblVenda34" runat="server" CssClass="label" Text="Venda34" 
                                                Visible="False"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtVenda34" runat="server" CssClass="textbox" Visible="False" 
                                                Width="200px"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda34" runat="server" CssClass="dropdown" 
                                                Visible="False" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblVenda35" runat="server" CssClass="label" Text="Venda35" 
                                                Visible="False"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtVenda35" runat="server" CssClass="textbox" Visible="False" 
                                                Width="200px"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda35" runat="server" CssClass="dropdown" 
                                                Visible="False" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblVenda36" runat="server" CssClass="label" Text="Venda36" 
                                                Visible="False"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtVenda36" runat="server" CssClass="textbox" Visible="False" 
                                                Width="200px"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda36" runat="server" CssClass="dropdown" 
                                                Visible="False" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblVenda37" runat="server" CssClass="label" Text="Venda37" 
                                                Visible="False"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtVenda37" runat="server" CssClass="textbox" Visible="False" 
                                                Width="200px"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda37" runat="server" CssClass="dropdown" 
                                                Visible="False" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblVenda38" runat="server" CssClass="label" Text="Venda38" 
                                                Visible="False"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtVenda38" runat="server" CssClass="textbox" Visible="False" 
                                                Width="200px"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda38" runat="server" CssClass="dropdown" 
                                                Visible="False" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblVenda39" runat="server" CssClass="label" Text="Venda39" 
                                                Visible="False"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtVenda39" runat="server" CssClass="textbox" Visible="False" 
                                                Width="200px"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda39" runat="server" CssClass="dropdown" 
                                                Visible="False" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblVenda40" runat="server" CssClass="label" Text="Venda40" 
                                                Visible="False"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtVenda40" runat="server" CssClass="textbox" Visible="False" 
                                                Width="200px"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda40" runat="server" CssClass="dropdown" 
                                                Visible="False" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblVenda41" runat="server" CssClass="label" Text="Venda41" 
                                                Visible="False"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtVenda41" runat="server" CssClass="textbox" Visible="False" 
                                                Width="200px"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda41" runat="server" CssClass="dropdown" 
                                                Visible="False" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblVenda42" runat="server" CssClass="label" Text="Venda42" 
                                                Visible="False"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtVenda42" runat="server" CssClass="textbox" Visible="False" 
                                                Width="200px"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda42" runat="server" CssClass="dropdown" 
                                                Visible="False" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblVenda43" runat="server" CssClass="label" Text="Venda43" 
                                                Visible="False"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtVenda43" runat="server" CssClass="textbox" Visible="False" 
                                                Width="200px"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda43" runat="server" CssClass="dropdown" 
                                                Visible="False" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblVenda44" runat="server" CssClass="label" Text="Venda44" 
                                                Visible="False"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtVenda44" runat="server" CssClass="textbox" Visible="False" 
                                                Width="200px"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda44" runat="server" CssClass="dropdown" 
                                                Visible="False" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblVenda45" runat="server" CssClass="label" Text="Venda45" 
                                                Visible="False"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtVenda45" runat="server" CssClass="textbox" Visible="False" 
                                                Width="200px"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda45" runat="server" CssClass="dropdown" 
                                                Visible="False" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblVenda46" runat="server" CssClass="label" Text="Venda46" 
                                                Visible="False"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtVenda46" runat="server" CssClass="textbox" Visible="False" 
                                                Width="200px"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda46" runat="server" CssClass="dropdown" 
                                                Visible="False" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblVenda47" runat="server" CssClass="label" Text="Venda47" 
                                                Visible="False"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtVenda47" runat="server" CssClass="textbox" Visible="False" 
                                                Width="200px"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda47" runat="server" CssClass="dropdown" 
                                                Visible="False" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblVenda48" runat="server" CssClass="label" Text="Venda48" 
                                                Visible="False"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtVenda48" runat="server" CssClass="textbox" Visible="False" 
                                                Width="200px"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda48" runat="server" CssClass="dropdown" 
                                                Visible="False" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblVenda49" runat="server" CssClass="label" Text="Venda49" 
                                                Visible="False"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtVenda49" runat="server" CssClass="textbox" Visible="False" 
                                                Width="200px"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda49" runat="server" CssClass="dropdown" 
                                                Visible="False" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblVenda50" runat="server" CssClass="label" Text="Venda50" 
                                                Visible="False"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtVenda50" runat="server" CssClass="textbox" Visible="False" 
                                                Width="200px"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda50" runat="server" CssClass="dropdown" 
                                                Visible="False" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblVenda51" runat="server" CssClass="label" Text="Venda51" 
                                                Visible="False"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtVenda51" runat="server" CssClass="textbox" Visible="False" 
                                                Width="200px"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda51" runat="server" CssClass="dropdown" 
                                                Visible="False" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblVenda52" runat="server" CssClass="label" Text="Venda52" 
                                                Visible="False"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtVenda52" runat="server" CssClass="textbox" Visible="False" 
                                                Width="200px"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda52" runat="server" CssClass="dropdown" 
                                                Visible="False" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblVenda53" runat="server" CssClass="label" Text="Venda53" 
                                                Visible="False"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtVenda53" runat="server" CssClass="textbox" Visible="False" 
                                                Width="200px"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda53" runat="server" CssClass="dropdown" 
                                                Visible="False" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblVenda54" runat="server" CssClass="label" Text="Venda54" 
                                                Visible="False"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtVenda54" runat="server" CssClass="textbox" Visible="False" 
                                                Width="200px"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda54" runat="server" CssClass="dropdown" 
                                                Visible="False" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblVenda55" runat="server" CssClass="label" Text="Venda55" 
                                                Visible="False"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtVenda55" runat="server" CssClass="textbox" Visible="False" 
                                                Width="200px"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda55" runat="server" CssClass="dropdown" 
                                                Visible="False" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblVenda56" runat="server" CssClass="label" Text="Venda56" 
                                                Visible="False"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtVenda56" runat="server" CssClass="textbox" Visible="False" 
                                                Width="200px"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda56" runat="server" CssClass="dropdown" 
                                                Visible="False" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblVenda57" runat="server" CssClass="label" Text="Venda57" 
                                                Visible="False"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtVenda57" runat="server" CssClass="textbox" Visible="False" 
                                                Width="200px"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda57" runat="server" CssClass="dropdown" 
                                                Visible="False" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblVenda58" runat="server" CssClass="label" Text="Venda58" 
                                                Visible="False"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtVenda58" runat="server" CssClass="textbox" Visible="False" 
                                                Width="200px"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda58" runat="server" CssClass="dropdown" 
                                                Visible="False" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblVenda59" runat="server" CssClass="label" Text="Venda59" 
                                                Visible="False"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtVenda59" runat="server" CssClass="textbox" Visible="False" 
                                                Width="200px"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda59" runat="server" CssClass="dropdown" 
                                                Visible="False" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="celula_nome_campo">
                                            <asp:Label ID="lblVenda60" runat="server" CssClass="label" Text="Venda60" 
                                                Visible="False"></asp:Label>
                                        </td>
                                        <td class="celula_campo">
                                            <asp:TextBox ID="txtVenda60" runat="server" CssClass="textbox" Visible="False" 
                                                Width="200px"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda60" runat="server" CssClass="dropdown" 
                                                Visible="False" Width="200px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                        </ContentTemplate>
                    </asp:TabPanel>
                </asp:TabContainer>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
