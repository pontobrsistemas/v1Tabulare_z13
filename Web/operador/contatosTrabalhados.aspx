<%@ Page Language="C#" AutoEventWireup="true" Title="Tabulare CRM" CodeFile="contatosTrabalhados.aspx.cs"
    Inherits="operador_contatosTrabalhados" %>

    
    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../scripts/mascara.js" type="text/javascript"></script>
    <script src="../fancy/jquery-1.8.3.js" type="text/javascript"></script>
    <script src="../fancy/jquery.fancybox.pack.js" type="text/javascript"></script>
    <link href="../fancy/jquery.fancybox.css" rel="stylesheet" type="text/css" />
    <link href="../css/print.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">

        function AbrirAgendamento() {
            parent.window.location.href = "atendimento.aspx?acao=contatosTrabalhados";
        }       
    </script>
    <style type="text/css">
        .textbox
        {
            border: 1px solid #198AA7;
            color: #000000;
            font-family: Verdana;
            font-size: 11px;
            margin-bottom: 0;
            margin-left: 3px;
            padding: 5px 0;
            text-transform: uppercase;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="3600"
        EnableScriptGlobalization="true">
    </asp:ScriptManager>
    </asp:Content>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnExportar" />
        </Triggers>
        <ContentTemplate>
            <h1>
                Contatos Trabalhados
            </h1>
            <div class="box_fancy">
                <fieldset class="fieldset_l">
                    <legend>Contatos Trabalhados</legend>
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="lblData" runat="server" Text="Data Inicial:" CssClass="label"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="datDataInicial" runat="server" CssClass="textbox" Format="MMMM d, yyyy"
                                    Width="90px" AutoPostBack="True" onkeydown="mascara(this,data)" onkeypress="mascara(this,data)"
                                    onkeyup="mascara(this,data)" MaxLength="10"></asp:TextBox>
                            </td>
                            <td>
                                <asp:CalendarExtender ID="datDataInicial_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                                    TargetControlID="datDataInicial" CssClass="cal_Theme1">
                                </asp:CalendarExtender>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </td>
                            <td>
                                <asp:Label ID="lblDataFinal" runat="server" CssClass="label" Text="Data Final:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="datDataFinal" runat="server" CssClass="textbox" Format="MMMM d, yyyy"
                                    Width="90px" AutoPostBack="True" onkeydown="mascara(this,data)" onkeypress="mascara(this,data)"
                                    onkeyup="mascara(this,data)" MaxLength="10"></asp:TextBox>
                            </td>
                            <td>
                                <asp:CalendarExtender ID="datDataFinal_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                                    TargetControlID="datDataFinal" CssClass="cal_Theme1">
                                </asp:CalendarExtender>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </td>
                            <td>
                                <asp:Button ID="cmdGerarDados" runat="server" CssClass="botao" OnClick="cmdGerarDados_Click"
                                    Text="Gerar Dados" Width="120px" />
                            </td>
                            <td>
                                &nbsp;<asp:Button ID="btnExportar" runat="server" CssClass="botao" OnClick="btnExportar_Click"
                                    Text="Exportar" Width="120px" />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <br />
                    <asp:Label ID="lblNumeroLinhas" runat="server" CssClass="label_descricao"></asp:Label>
                    <asp:GridView ID="GridContatosTrabalhados" runat="server" CssClass="grid" AutoGenerateColumns="False"
                         EnableModelValidation="True" OnRowDataBound="GridContatosTrabalhados_RowDataBound">
                        <RowStyle CssClass="grid" HorizontalAlign="Left" />
                        <Columns>
                            <asp:BoundField DataField="Nome" HeaderText="Nome" />
                            <asp:BoundField DataField="Telefone1" HeaderText="Telefone" />
                            <asp:BoundField DataField="CPF_CNPJ" HeaderText="CPF/CNPJ" />
                            <asp:BoundField DataField="Status" HeaderText="Status" />
                            <asp:BoundField DataField="Mailing" HeaderText="Mailing" />
                            <asp:BoundField DataField="Data Contato" HeaderText="Data/Hora Contato" />
                            <asp:BoundField DataField="Venda" HeaderText="Venda" />
                        </Columns>
                        <HeaderStyle CssClass="grid_header" HorizontalAlign="Justify" />
                        <AlternatingRowStyle CssClass="grid_alternative_row" />
                    </asp:GridView>
                </fieldset>
            </div>
            <div class="clear">
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </asp:Content>
    </form>
</body>
</html>
