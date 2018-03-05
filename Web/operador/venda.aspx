<%@ Page Language="C#" AutoEventWireup="true" CodeFile="venda.aspx.cs" Inherits="operador_venda" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../scripts/mascara.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="../css/print.css" />
    <style type="text/css">
        fieldset div.label span.block
        {
            width: 110px;
        }
        fieldset div.label span.y
        {
            width: 45px !important;
        }
    </style>
    <script src="../fancy/jquery-1.8.3.js" type="text/javascript"></script>
    <script src="../fancy/jquery.fancybox.pack.js" type="text/javascript"></script>
    <link href="../fancy/jquery.fancybox.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        
        .style1
        {
            height: 13px;
        }
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="3600">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
        </Triggers>
        <ContentTemplate>
            <h1>
                <asp:Label ID="lblTituloFormulario" runat="server" Text="Detalhes da Venda" CssClass="label_h1"></asp:Label>
            </h1>
            <div>
                <table class="style1">
                    <tr align="left">
                        <td class="style7" align="left">
                            <asp:HiddenField ID="hddIDHistorico" runat="server" />
                            <asp:HiddenField ID="hddIDProspect" runat="server" />
                            <asp:HiddenField ID="hddIDCampanha" runat="server" />
                            &nbsp;
                            <asp:HiddenField ID="hddIDVenda" runat="server" />
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
                                        <td style="text-align: right">
                                            <asp:Label ID="lblNome" runat="server" CssClass="label" Text="Nome:"></asp:Label>
                                        </td>
                                        <td class="style5">
                                            <asp:TextBox ID="txtNome" runat="server" CssClass="textbox" MaxLength="100" Width="505px"></asp:TextBox>
                                            <asp:Label ID="lblCPF" runat="server" CssClass="label" Text="CPF / CNPJ:"></asp:Label>
                                            <asp:TextBox ID="txtCPF_CNPJ" runat="server" CssClass="textbox" MaxLength="15"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right">
                                            <asp:Label ID="lblTelefone1" runat="server" CssClass="label" Text="Telefone1:"></asp:Label>
                                        </td>
                                        <td class="style6">
                                            <asp:TextBox ID="txtTelefone1" runat="server" CssClass="textbox" MaxLength="11"></asp:TextBox>
                                            <asp:Label ID="lblTelefone2" runat="server" CssClass="label" Text="Telefone2:"></asp:Label>
                                            <asp:TextBox ID="txtTelefone2" runat="server" CssClass="textbox" MaxLength="11"></asp:TextBox>
                                            <asp:Label ID="lblTelefone3" runat="server" CssClass="label" Text="Telefone3:"></asp:Label>
                                            <asp:TextBox ID="txtTelefone3" runat="server" CssClass="textbox" MaxLength="11"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblLogradouro" runat="server" CssClass="label" Text="Logradouro:"></asp:Label>
                                        </td>
                                        <td class="style6">
                                            <asp:TextBox ID="txtLogradouro" runat="server" CssClass="textbox" MaxLength="100"
                                                Width="350px"></asp:TextBox>
                                            <asp:Label ID="lblNum" runat="server" CssClass="label" Text="Núm:"></asp:Label>
                                            <asp:TextBox ID="txtNumero" runat="server" CssClass="textbox" MaxLength="50"></asp:TextBox>
                                            <asp:Label ID="lblComplemento" runat="server" CssClass="label" Text="Compl:"></asp:Label>
                                            <asp:TextBox ID="txtComplemento" runat="server" CssClass="textbox" MaxLength="50"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right">
                                            <asp:Label ID="lblBairro" runat="server" CssClass="label" Text="Bairro:"></asp:Label>
                                        </td>
                                        <td class="style6">
                                            <asp:TextBox ID="txtBairro" runat="server" CssClass="textbox" MaxLength="100"></asp:TextBox>
                                            <asp:Label ID="lblCidade" runat="server" CssClass="label" Text="Cidade:"></asp:Label>
                                            <asp:TextBox ID="txtCidade" runat="server" CssClass="textbox" MaxLength="100" Width="160px"></asp:TextBox>
                                            <asp:Label ID="lblEstado" runat="server" CssClass="label" Text="Estado:"></asp:Label>
                                            <asp:TextBox ID="txtEstado" runat="server" CssClass="textbox" MaxLength="50" Width="157px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right">
                                            <asp:Label ID="lblEmail" runat="server" CssClass="label" Text="Email:"></asp:Label>
                                        </td>
                                        <td class="style6">
                                            <asp:TextBox ID="txtEmail" runat="server" CssClass="textbox" Width="395px" MaxLength="100"></asp:TextBox>
                                            <asp:Label ID="lblCep" runat="server" CssClass="label" Text="CEP:"></asp:Label>
                                            <asp:TextBox ID="txtCep" runat="server" CssClass="textbox" MaxLength="10"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblCampo01" runat="server" CssClass="label" Text="Campo01" Visible="False"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCampo01" runat="server" CssClass="textbox" MaxLength="100" Visible="False"
                                                Width="190px"></asp:TextBox>
                                            <asp:DropDownList ID="dropCampo01" runat="server" CssClass="dropdown" Visible="False"
                                                Width="190px">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblCampo02" runat="server" CssClass="label" Text="Campo02" Visible="False"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCampo02" runat="server" CssClass="textbox" MaxLength="100" Visible="False"
                                                Width="190px"></asp:TextBox>
                                            <asp:DropDownList ID="dropCampo02" runat="server" CssClass="dropdown" Visible="False"
                                                Width="190px">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblCampo03" runat="server" CssClass="label" Text="Campo03" Visible="False"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCampo03" runat="server" CssClass="textbox" MaxLength="100" Visible="False"
                                                Width="190px"></asp:TextBox>
                                            <asp:DropDownList ID="dropCampo03" runat="server" CssClass="dropdown" Visible="False"
                                                Width="190px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblCampo04" runat="server" CssClass="label" Text="Campo04" Visible="False"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCampo04" runat="server" CssClass="textbox" MaxLength="100" Visible="False"
                                                Width="190px"></asp:TextBox>
                                            <asp:DropDownList ID="dropCampo04" runat="server" CssClass="dropdown" Visible="False"
                                                Width="190px">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblCampo05" runat="server" CssClass="label" Text="Campo05" Visible="False"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCampo05" runat="server" CssClass="textbox" MaxLength="100" Visible="False"
                                                Width="190px"></asp:TextBox>
                                            <asp:DropDownList ID="dropCampo05" runat="server" CssClass="dropdown" Visible="False"
                                                Width="190px">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblCampo06" runat="server" CssClass="label" Text="Campo06" Visible="False"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCampo06" runat="server" CssClass="textbox" MaxLength="100" Visible="False"
                                                Width="190px"></asp:TextBox>
                                            <asp:DropDownList ID="dropCampo06" runat="server" CssClass="dropdown" Visible="False"
                                                Width="190px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblCampo07" runat="server" CssClass="label" Text="Campo07" Visible="False"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCampo07" runat="server" CssClass="textbox" MaxLength="100" Visible="False"
                                                Width="190px"></asp:TextBox>
                                            <asp:DropDownList ID="dropCampo07" runat="server" CssClass="dropdown" Visible="False"
                                                Width="190px">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblCampo08" runat="server" CssClass="label" Text="Campo08" Visible="False"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCampo08" runat="server" CssClass="textbox" MaxLength="100" Visible="False"
                                                Width="190px"></asp:TextBox>
                                            <asp:DropDownList ID="dropCampo08" runat="server" CssClass="dropdown" Visible="False"
                                                Width="190px">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblCampo09" runat="server" CssClass="label" Text="Campo09" Visible="False"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCampo09" runat="server" CssClass="textbox" MaxLength="100" Visible="False"
                                                Width="190px"></asp:TextBox>
                                            <asp:DropDownList ID="dropCampo09" runat="server" CssClass="dropdown" Visible="False"
                                                Width="190px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblCampo10" runat="server" CssClass="label" Text="Campo10" Visible="False"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCampo10" runat="server" CssClass="textbox" MaxLength="100" Visible="False"
                                                Width="190px"></asp:TextBox>
                                            <asp:DropDownList ID="dropCampo10" runat="server" CssClass="dropdown" Visible="False"
                                                Width="190px">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="15">
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right">
                                            <asp:Label ID="lblCampanha" runat="server" CssClass="label" Text="Campanha"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblCampanha_valor" runat="server" CssClass="label_dadosvenda"></asp:Label>
                                        </td>
                                        <td style="text-align: right">
                                            <asp:Label ID="lblMailing" runat="server" CssClass="label" Text="Mailing"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblMailing_valor" runat="server" CssClass="label_dadosvenda"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right">
                                            <asp:Label ID="lblOperador" runat="server" CssClass="label" Text="Operador"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblOperador_valor" runat="server" CssClass="label_dadosvenda"></asp:Label>
                                        </td>
                                        <td style="text-align: right">
                                            <asp:Label ID="lblDataContato" runat="server" CssClass="label" Text="Data/Hora Contato"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblDataContato_valor" runat="server" CssClass="label_dadosvenda"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                            &nbsp;&nbsp;
                            <br />
                            <fieldset class="fieldset_atendimento" id="Fieldset1" runat="server">
                                <legend>Auditoria</legend>
                                <table>
                                    <tr>
                                        <td class="td">
                                            <asp:Label ID="lblBackoffice" runat="server" CssClass="label" Text="Backoffice"></asp:Label>
                                        </td>
                                        <td class="td_control">
                                            <asp:Label ID="lblBackoffice_valor" runat="server" CssClass="label_dadosvenda"></asp:Label>
                                        </td>
                                        <td class="td" rowspan="2">
                                            <asp:Label ID="lblObservacao" runat="server" CssClass="label" Text="Observação:"></asp:Label>
                                            <br />
                                        </td>
                                        <td class="td" rowspan="2">
                                            <asp:TextBox ID="txtObservacao" runat="server" CssClass="textbox" Height="50px" Width="400px"
                                                TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="td">
                                            <asp:Label ID="lblDataAuditoria" runat="server" CssClass="label" Text="Data/Hora Auditoria"></asp:Label>
                                        </td>
                                        <td class="td_control">
                                            <asp:Label ID="lblDataAuditoria_valor" runat="server" CssClass="label_dadosvenda"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="td" rowspan="2">
                                            <asp:Label ID="lblStatus" runat="server" CssClass="label" Text="Status da Auditoria:"></asp:Label>
                                        </td>
                                        <td class="td_control" rowspan="2">
                                            <asp:Label ID="lblStatusAuditoria_valor" runat="server" CssClass="label_dadosvenda"></asp:Label>
                                    </tr>
                                </table>
                                <tr>
                                    <td class="td">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:GridView ID="grdHistoricoVenda" runat="server" CssClass="grid" 
                                                    Height="200px"   DataKeyNames="Observação,IDTratamento"
                                                    Style="text-align: left" OnRowCommand="grdHistoricoVenda_RowCommand" 
                                                    AutoGenerateColumns="False">
                                                    <AlternatingRowStyle CssClass="grid_alternative_row" />
                                                    <HeaderStyle CssClass="grid_header" HorizontalAlign="Justify" />
                                                    <Columns>
                                                    <asp:BoundField DataField="IDTratamento" HeaderText="IDTratamento" />
                                                    <asp:BoundField DataField="Observação" HeaderText="Observação" />
                                                    <asp:BoundField DataField="Horário do Envio" HeaderText="Horário do Envio" />
                                                    <asp:BoundField DataField="Horário da Leitura" HeaderText="Horário da Leitura" />
                                                    <asp:BoundField DataField="Remetente" HeaderText="Remetente" />
                                                    <asp:ButtonField ButtonType="Image" CommandName="Abrir" HeaderText="Abrir" ImageUrl="~/imagens/okmenor.gif"
                                                            Text="Botão" />
                                                    </Columns>
                                                    <RowStyle CssClass="grid" HorizontalAlign="Left" />
                                                </asp:GridView>
                                            </td>
                                            <td class="td" rowspan="2">
                                                <asp:TextBox ID="txtObsVenda" runat="server" CssClass="textbox" Height="50px" ReadOnly="True"
                                                    TextMode="MultiLine" Width="316px"></asp:TextBox>
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                 <asp:Label ID="lblObsVenda" runat="server" CssClass="label" Text="Digite a Mensagem para enviar para equipe de Backoffice:" 
                                                 TextMode="MultiLine" Width="200px" style= "float:left"></asp:Label>
                                                <br />
                                                <br />
                                                <br />
                                                <asp:TextBox ID="txtEnviarObsVenda" runat="server" CssClass="textbox" Height="50px"
                                                    TextMode="MultiLine" Width="316px"></asp:TextBox>
                                                     <br />
                                                <br />
                                                <br />
                                                <asp:Button ID="cmdLimpar" runat="server" CssClass="botao" 
                                                    OnClick="cmdLimpar_Click" Text="Limpar" />
                                                &nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="cmdMensagem0" runat="server" CssClass="botao" 
                                                    OnClick="cmdMensagem_Click" Text="Enviar Observação" />
                                                <br />
                                                <br />
                                                     <br />
                                            </td>
                                            </table>
                                        </tr>
                                        <caption>
                                            &nbsp;&nbsp;&nbsp;&nbsp;
                                            <tr>
                                                <td colspan="2">
                                                    <br />
                                                    &nbsp;<asp:Button ID="cmdVoltarRodape" runat="server" CssClass="botao" 
                                                        OnClick="cmdVoltarRodape_Click" Text="Voltar" />
                                                    &nbsp;</td>
                                            </tr>
                                        </caption>
                                </tr>
                            </fieldset>
                            </table>
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
                                        <td class="style16">
                                            <asp:Label ID="lblVenda01" runat="server" CssClass="label" Text="Venda01" Visible="False"></asp:Label>
                                        </td>
                                        <td class="style17">
                                            <asp:TextBox ID="txtVenda01" runat="server" CssClass="textbox" Width="200px" Visible="False"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda01" runat="server" CssClass="dropdown" Width="200px"
                                                Visible="False">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="style18">
                                            <asp:Label ID="lblVenda02" runat="server" CssClass="label" Text="Venda02" Visible="False"></asp:Label>
                                        </td>
                                        <td class="style20">
                                            <asp:TextBox ID="txtVenda02" runat="server" CssClass="textbox" Width="200px" Visible="False"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda02" runat="server" CssClass="dropdown" Width="200px"
                                                Visible="False">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="style19">
                                            <asp:Label ID="lblVenda03" runat="server" CssClass="label" Text="Venda03" Visible="False"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtVenda03" runat="server" CssClass="textbox" Width="200px" Visible="False"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda03" runat="server" CssClass="dropdown" Width="200px"
                                                Visible="False">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style16">
                                            <asp:Label ID="lblVenda04" runat="server" CssClass="label" Text="Venda04" Visible="False"></asp:Label>
                                        </td>
                                        <td class="style17">
                                            <asp:TextBox ID="txtVenda04" runat="server" CssClass="textbox" Width="200px" Visible="False"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda04" runat="server" CssClass="dropdown" Width="200px"
                                                Visible="False">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="style18">
                                            <asp:Label ID="lblVenda05" runat="server" CssClass="label" Text="Venda05" Visible="False"></asp:Label>
                                        </td>
                                        <td class="style20">
                                            <asp:TextBox ID="txtVenda05" runat="server" CssClass="textbox" Width="200px" Visible="False"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda05" runat="server" CssClass="dropdown" Width="200px"
                                                Visible="False">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="style19">
                                            <asp:Label ID="lblVenda06" runat="server" CssClass="label" Text="Venda06" Visible="False"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtVenda06" runat="server" CssClass="textbox" Width="200px" Visible="False"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda06" runat="server" CssClass="dropdown" Width="200px"
                                                Visible="False">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style16">
                                            <asp:Label ID="lblVenda07" runat="server" CssClass="label" Text="Venda07" Visible="False"></asp:Label>
                                        </td>
                                        <td class="style17">
                                            <asp:TextBox ID="txtVenda07" runat="server" CssClass="textbox" Width="200px" Visible="False"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda07" runat="server" CssClass="dropdown" Width="200px"
                                                Visible="False">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="style18">
                                            <asp:Label ID="lblVenda08" runat="server" CssClass="label" Text="Venda08" Visible="False"></asp:Label>
                                        </td>
                                        <td class="style20">
                                            <asp:TextBox ID="txtVenda08" runat="server" CssClass="textbox" Width="200px" Visible="False"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda08" runat="server" CssClass="dropdown" Width="200px"
                                                Visible="False">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="style19">
                                            <asp:Label ID="lblVenda09" runat="server" CssClass="label" Text="Venda09" Visible="False"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtVenda09" runat="server" CssClass="textbox" Width="200px" Visible="False"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda09" runat="server" CssClass="dropdown" Width="200px"
                                                Visible="False">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style16">
                                            <asp:Label ID="lblVenda10" runat="server" CssClass="label" Text="Venda10" Visible="False"></asp:Label>
                                        </td>
                                        <td class="style17">
                                            <asp:TextBox ID="txtVenda10" runat="server" CssClass="textbox" Width="200px" Visible="False"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda10" runat="server" CssClass="dropdown" Width="200px"
                                                Visible="False">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="style18">
                                            <asp:Label ID="lblVenda11" runat="server" CssClass="label" Text="Venda11" Visible="False"></asp:Label>
                                        </td>
                                        <td class="style20">
                                            <asp:TextBox ID="txtVenda11" runat="server" CssClass="textbox" Width="200px" Visible="False"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda11" runat="server" CssClass="dropdown" Width="200px"
                                                Visible="False">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="style19">
                                            <asp:Label ID="lblVenda12" runat="server" CssClass="label" Text="Venda12" Visible="False"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtVenda12" runat="server" CssClass="textbox" Width="200px" Visible="False"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda12" runat="server" CssClass="dropdown" Width="200px"
                                                Visible="False">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style16">
                                            <asp:Label ID="lblVenda13" runat="server" CssClass="label" Text="Venda13" Visible="False"></asp:Label>
                                        </td>
                                        <td class="style17">
                                            <asp:TextBox ID="txtVenda13" runat="server" CssClass="textbox" Width="200px" Visible="False"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda13" runat="server" CssClass="dropdown" Width="200px"
                                                Visible="False">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="style18">
                                            <asp:Label ID="lblVenda14" runat="server" CssClass="label" Text="Venda14" Visible="False"></asp:Label>
                                        </td>
                                        <td class="style20">
                                            <asp:TextBox ID="txtVenda14" runat="server" CssClass="textbox" Width="200px" Visible="False"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda14" runat="server" CssClass="dropdown" Width="200px"
                                                Visible="False">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="style19">
                                            <asp:Label ID="lblVenda15" runat="server" CssClass="label" Text="Venda15" Visible="False"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtVenda15" runat="server" CssClass="textbox" Width="200px" Visible="False"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda15" runat="server" CssClass="dropdown" Width="200px"
                                                Visible="False">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style16">
                                            <asp:Label ID="lblVenda16" runat="server" CssClass="label" Text="Venda16" Visible="False"></asp:Label>
                                        </td>
                                        <td class="style17">
                                            <asp:TextBox ID="txtVenda16" runat="server" CssClass="textbox" Width="200px" Visible="False"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda16" runat="server" CssClass="dropdown" Width="200px"
                                                Visible="False">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="style18">
                                            <asp:Label ID="lblVenda17" runat="server" CssClass="label" Text="Venda17" Visible="False"></asp:Label>
                                        </td>
                                        <td class="style20">
                                            <asp:TextBox ID="txtVenda17" runat="server" CssClass="textbox" Width="200px" Visible="False"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda17" runat="server" CssClass="dropdown" Width="200px"
                                                Visible="False">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="style19">
                                            <asp:Label ID="lblVenda18" runat="server" CssClass="label" Text="Venda18" Visible="False"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtVenda18" runat="server" CssClass="textbox" Width="200px" Visible="False"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda18" runat="server" CssClass="dropdown" Width="200px"
                                                Visible="False">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style16">
                                            <asp:Label ID="lblVenda19" runat="server" CssClass="label" Text="Venda19" Visible="False"></asp:Label>
                                        </td>
                                        <td class="style17">
                                            <asp:TextBox ID="txtVenda19" runat="server" CssClass="textbox" Width="200px" Visible="False"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda19" runat="server" CssClass="dropdown" Width="200px"
                                                Visible="False">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="style18">
                                            <asp:Label ID="lblVenda20" runat="server" CssClass="label" Text="Venda20" Visible="False"></asp:Label>
                                        </td>
                                        <td class="style20">
                                            <asp:TextBox ID="txtVenda20" runat="server" CssClass="textbox" Width="200px" Visible="False"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda20" runat="server" CssClass="dropdown" Width="200px"
                                                Visible="False">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="style19">
                                            <asp:Label ID="lblVenda21" runat="server" CssClass="label" Text="Venda21" Visible="False"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtVenda21" runat="server" CssClass="textbox" Width="200px" Visible="False"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda21" runat="server" CssClass="dropdown" Width="200px"
                                                Visible="False">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style16">
                                            <asp:Label ID="lblVenda22" runat="server" CssClass="label" Text="Venda22" Visible="False"></asp:Label>
                                        </td>
                                        <td class="style17">
                                            <asp:TextBox ID="txtVenda22" runat="server" CssClass="textbox" Width="200px" Visible="False"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda22" runat="server" CssClass="dropdown" Width="200px"
                                                Visible="False">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="style18">
                                            <asp:Label ID="lblVenda23" runat="server" CssClass="label" Text="Venda23" Visible="False"></asp:Label>
                                        </td>
                                        <td class="style20">
                                            <asp:TextBox ID="txtVenda23" runat="server" CssClass="textbox" Width="200px" Visible="False"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda23" runat="server" CssClass="dropdown" Width="200px"
                                                Visible="False">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="style19">
                                            <asp:Label ID="lblVenda24" runat="server" CssClass="label" Text="Venda24" Visible="False"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtVenda24" runat="server" CssClass="textbox" Width="200px" Visible="False"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda24" runat="server" CssClass="dropdown" Width="200px"
                                                Visible="False">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style16">
                                            <asp:Label ID="lblVenda25" runat="server" CssClass="label" Text="Venda25" Visible="False"></asp:Label>
                                        </td>
                                        <td class="style17">
                                            <asp:TextBox ID="txtVenda25" runat="server" CssClass="textbox" Width="200px" Visible="False"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda25" runat="server" CssClass="dropdown" Width="200px"
                                                Visible="False">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="style18">
                                            <asp:Label ID="lblVenda26" runat="server" CssClass="label" Text="Venda26" Visible="False"></asp:Label>
                                        </td>
                                        <td class="style20">
                                            <asp:TextBox ID="txtVenda26" runat="server" CssClass="textbox" Width="200px" Visible="False"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda26" runat="server" CssClass="dropdown" Width="200px"
                                                Visible="False">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="style19">
                                            <asp:Label ID="lblVenda27" runat="server" CssClass="label" Text="Venda27" Visible="False"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtVenda27" runat="server" CssClass="textbox" Width="200px" Visible="False"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda27" runat="server" CssClass="dropdown" Width="200px"
                                                Visible="False">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style16">
                                            <asp:Label ID="lblVenda28" runat="server" CssClass="label" Text="Venda28" Visible="False"></asp:Label>
                                        </td>
                                        <td class="style17">
                                            <asp:TextBox ID="txtVenda28" runat="server" CssClass="textbox" Width="200px" Visible="False"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda28" runat="server" CssClass="dropdown" Width="200px"
                                                Visible="False">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="style18">
                                            <asp:Label ID="lblVenda29" runat="server" CssClass="label" Text="Venda29" Visible="False"></asp:Label>
                                        </td>
                                        <td class="style20">
                                            <asp:TextBox ID="txtVenda29" runat="server" CssClass="textbox" Width="200px" Visible="False"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda29" runat="server" CssClass="dropdown" Width="200px"
                                                Visible="False">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="style19">
                                            <asp:Label ID="lblVenda30" runat="server" CssClass="label" Text="Venda30" Visible="False"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtVenda30" runat="server" CssClass="textbox" Width="200px" Visible="False"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda30" runat="server" CssClass="dropdown" Width="200px"
                                                Visible="False">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style16">
                                            <asp:Label ID="lblVenda31" runat="server" CssClass="label" Text="Venda31" Visible="False"></asp:Label>
                                        </td>
                                        <td class="style17">
                                            <asp:TextBox ID="txtVenda31" runat="server" CssClass="textbox" Width="200px" Visible="False"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda31" runat="server" CssClass="dropdown" Width="200px"
                                                Visible="False">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="style18">
                                            <asp:Label ID="lblVenda32" runat="server" CssClass="label" Text="Venda32" Visible="False"></asp:Label>
                                        </td>
                                        <td class="style20">
                                            <asp:TextBox ID="txtVenda32" runat="server" CssClass="textbox" Width="200px" Visible="False"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda32" runat="server" CssClass="dropdown" Width="200px"
                                                Visible="False">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="style19">
                                            <asp:Label ID="lblVenda33" runat="server" CssClass="label" Text="Venda33" Visible="False"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtVenda33" runat="server" CssClass="textbox" Width="200px" Visible="False"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda33" runat="server" CssClass="dropdown" Width="200px"
                                                Visible="False">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style16">
                                            <asp:Label ID="lblVenda34" runat="server" CssClass="label" Text="Venda34" Visible="False"></asp:Label>
                                        </td>
                                        <td class="style17">
                                            <asp:TextBox ID="txtVenda34" runat="server" CssClass="textbox" Width="200px" Visible="False"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda34" runat="server" CssClass="dropdown" Width="200px"
                                                Visible="False">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="style18">
                                            <asp:Label ID="lblVenda35" runat="server" CssClass="label" Text="Venda35" Visible="False"></asp:Label>
                                        </td>
                                        <td class="style20">
                                            <asp:TextBox ID="txtVenda35" runat="server" CssClass="textbox" Width="200px" Visible="False"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda35" runat="server" CssClass="dropdown" Width="200px"
                                                Visible="False">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="style19">
                                            <asp:Label ID="lblVenda36" runat="server" CssClass="label" Text="Venda36" Visible="False"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtVenda36" runat="server" CssClass="textbox" Width="200px" Visible="False"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda36" runat="server" CssClass="dropdown" Width="200px"
                                                Visible="False">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style16">
                                            <asp:Label ID="lblVenda37" runat="server" CssClass="label" Text="Venda37" Visible="False"></asp:Label>
                                        </td>
                                        <td class="style17">
                                            <asp:TextBox ID="txtVenda37" runat="server" CssClass="textbox" Width="200px" Visible="False"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda37" runat="server" CssClass="dropdown" Width="200px"
                                                Visible="False">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="style18">
                                            <asp:Label ID="lblVenda38" runat="server" CssClass="label" Text="Venda38" Visible="False"></asp:Label>
                                        </td>
                                        <td class="style20">
                                            <asp:TextBox ID="txtVenda38" runat="server" CssClass="textbox" Width="200px" Visible="False"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda38" runat="server" CssClass="dropdown" Width="200px"
                                                Visible="False">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="style19">
                                            <asp:Label ID="lblVenda39" runat="server" CssClass="label" Text="Venda39" Visible="False"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtVenda39" runat="server" CssClass="textbox" Width="200px" Visible="False"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda39" runat="server" CssClass="dropdown" Width="200px"
                                                Visible="False">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style16">
                                            <asp:Label ID="lblVenda40" runat="server" CssClass="label" Text="Venda40" Visible="False"></asp:Label>
                                        </td>
                                        <td class="style17">
                                            <asp:TextBox ID="txtVenda40" runat="server" CssClass="textbox" Width="200px" Visible="False"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda40" runat="server" CssClass="dropdown" Width="200px"
                                                Visible="False">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="style18">
                                            <asp:Label ID="lblVenda41" runat="server" CssClass="label" Text="Venda41" Visible="False"></asp:Label>
                                        </td>
                                        <td class="style20">
                                            <asp:TextBox ID="txtVenda41" runat="server" CssClass="textbox" Width="200px" Visible="False"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda41" runat="server" CssClass="dropdown" Width="200px"
                                                Visible="False">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="style19">
                                            <asp:Label ID="lblVenda42" runat="server" CssClass="label" Text="Venda42" Visible="False"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtVenda42" runat="server" CssClass="textbox" Width="200px" Visible="False"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda42" runat="server" CssClass="dropdown" Width="200px"
                                                Visible="False">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style16">
                                            <asp:Label ID="lblVenda43" runat="server" CssClass="label" Text="Venda43" Visible="False"></asp:Label>
                                        </td>
                                        <td class="style17">
                                            <asp:TextBox ID="txtVenda43" runat="server" CssClass="textbox" Width="200px" Visible="False"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda43" runat="server" CssClass="dropdown" Width="200px"
                                                Visible="False">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="style18">
                                            <asp:Label ID="lblVenda44" runat="server" CssClass="label" Text="Venda44" Visible="False"></asp:Label>
                                        </td>
                                        <td class="style20">
                                            <asp:TextBox ID="txtVenda44" runat="server" CssClass="textbox" Width="200px" Visible="False"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda44" runat="server" CssClass="dropdown" Width="200px"
                                                Visible="False">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="style19">
                                            <asp:Label ID="lblVenda45" runat="server" CssClass="label" Text="Venda45" Visible="False"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtVenda45" runat="server" CssClass="textbox" Width="200px" Visible="False"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda45" runat="server" CssClass="dropdown" Width="200px"
                                                Visible="False">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style16">
                                            <asp:Label ID="lblVenda46" runat="server" CssClass="label" Text="Venda46" Visible="False"></asp:Label>
                                        </td>
                                        <td class="style17">
                                            <asp:TextBox ID="txtVenda46" runat="server" CssClass="textbox" Width="200px" Visible="False"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda46" runat="server" CssClass="dropdown" Width="200px"
                                                Visible="False">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="style18">
                                            <asp:Label ID="lblVenda47" runat="server" CssClass="label" Text="Venda47" Visible="False"></asp:Label>
                                        </td>
                                        <td class="style20">
                                            <asp:TextBox ID="txtVenda47" runat="server" CssClass="textbox" Width="200px" Visible="False"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda47" runat="server" CssClass="dropdown" Width="200px"
                                                Visible="False">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="style19">
                                            <asp:Label ID="lblVenda48" runat="server" CssClass="label" Text="Venda48" Visible="False"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtVenda48" runat="server" CssClass="textbox" Width="200px" Visible="False"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda48" runat="server" CssClass="dropdown" Width="200px"
                                                Visible="False">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style16">
                                            <asp:Label ID="lblVenda49" runat="server" CssClass="label" Text="Venda49" Visible="False"></asp:Label>
                                        </td>
                                        <td class="style17">
                                            <asp:TextBox ID="txtVenda49" runat="server" CssClass="textbox" Width="200px" Visible="False"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda49" runat="server" CssClass="dropdown" Width="200px"
                                                Visible="False">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="style18">
                                            <asp:Label ID="lblVenda50" runat="server" CssClass="label" Text="Venda50" Visible="False"></asp:Label>
                                        </td>
                                        <td class="style20">
                                            <asp:TextBox ID="txtVenda50" runat="server" CssClass="textbox" Width="200px" Visible="False"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda50" runat="server" CssClass="dropdown" Width="200px"
                                                Visible="False">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="style19">
                                            <asp:Label ID="lblVenda51" runat="server" CssClass="label" Text="Venda51" Visible="False"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtVenda51" runat="server" CssClass="textbox" Width="200px" Visible="False"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda51" runat="server" CssClass="dropdown" Width="200px"
                                                Visible="False">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style16">
                                            <asp:Label ID="lblVenda52" runat="server" CssClass="label" Text="Venda52" Visible="False"></asp:Label>
                                        </td>
                                        <td class="style17">
                                            <asp:TextBox ID="txtVenda52" runat="server" CssClass="textbox" Width="200px" Visible="False"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda52" runat="server" CssClass="dropdown" Width="200px"
                                                Visible="False">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="style18">
                                            <asp:Label ID="lblVenda53" runat="server" CssClass="label" Text="Venda53" Visible="False"></asp:Label>
                                        </td>
                                        <td class="style20">
                                            <asp:TextBox ID="txtVenda53" runat="server" CssClass="textbox" Width="200px" Visible="False"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda53" runat="server" CssClass="dropdown" Width="200px"
                                                Visible="False">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="style19">
                                            <asp:Label ID="lblVenda54" runat="server" CssClass="label" Text="Venda54" Visible="False"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtVenda54" runat="server" CssClass="textbox" Width="200px" Visible="False"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda54" runat="server" CssClass="dropdown" Width="200px"
                                                Visible="False">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style16">
                                            <asp:Label ID="lblVenda55" runat="server" CssClass="label" Text="Venda55" Visible="False"></asp:Label>
                                        </td>
                                        <td class="style17">
                                            <asp:TextBox ID="txtVenda55" runat="server" CssClass="textbox" Width="200px" Visible="False"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda55" runat="server" CssClass="dropdown" Width="200px"
                                                Visible="False">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="style18">
                                            <asp:Label ID="lblVenda56" runat="server" CssClass="label" Text="Venda56" Visible="False"></asp:Label>
                                        </td>
                                        <td class="style20">
                                            <asp:TextBox ID="txtVenda56" runat="server" CssClass="textbox" Width="200px" Visible="False"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda56" runat="server" CssClass="dropdown" Width="200px"
                                                Visible="False">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="style19">
                                            <asp:Label ID="lblVenda57" runat="server" CssClass="label" Text="Venda57" Visible="False"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtVenda57" runat="server" CssClass="textbox" Width="200px" Visible="False"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda57" runat="server" CssClass="dropdown" Width="200px"
                                                Visible="False">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style16">
                                            <asp:Label ID="lblVenda58" runat="server" CssClass="label" Text="Venda58" Visible="False"></asp:Label>
                                        </td>
                                        <td class="style17">
                                            <asp:TextBox ID="txtVenda58" runat="server" CssClass="textbox" Width="200px" Visible="False"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda58" runat="server" CssClass="dropdown" Width="200px"
                                                Visible="False">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="style18">
                                            <asp:Label ID="lblVenda59" runat="server" CssClass="label" Text="Venda59" Visible="False"></asp:Label>
                                        </td>
                                        <td class="style20">
                                            <asp:TextBox ID="txtVenda59" runat="server" CssClass="textbox" Width="200px" Visible="False"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda59" runat="server" CssClass="dropdown" Width="200px"
                                                Visible="False">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="style19">
                                            <asp:Label ID="lblVenda60" runat="server" CssClass="label" Text="Venda60" Visible="False"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtVenda60" runat="server" CssClass="textbox" Width="200px" Visible="False"></asp:TextBox>
                                            <asp:DropDownList ID="dropVenda60" runat="server" CssClass="dropdown" Width="200px"
                                                Visible="False">
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
    </form>
</body>
</html>
