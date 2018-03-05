<%@ page language="C#" autoeventwireup="true" inherits="operador_agendamentos, App_Web_wzw5p3vb" title="Tabulare CRM" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../scripts/mascara.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="../css/print.css" />
    <script src="../fancy/jquery-1.8.3.js" type="text/javascript"></script>
    <script src="../fancy/jquery.fancybox.pack.js" type="text/javascript"></script>
    <link href="../fancy/jquery.fancybox.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="3600"
    EnableScriptGlobalization="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <h1>
                Agendamentos
            </h1>
            <div class="box_fancy">
            <asp:Button ID="bTnAtualizar" runat="server" CssClass="botao" Text="Atualizar"
                         OnClick="bTnAtualizar_Click" />
                <fieldset class="fieldset_l">
                    <legend>Agendamentos</legend>
                    <div class="div_relatorio">
                    
                   <asp:Label ID="lblRegistros" runat="server" CssClass="label_descricao"></asp:Label>
                    &nbsp;
                    &nbsp;<br /> <asp:GridView ID="dgProspects" runat="server" OnRowDataBound="dgProspects_RowDataBound"
                            EnableModelValidation="True" AutoGenerateColumns="False"
                            CssClass="grid" DataKeyNames="Cód. Prospect" Width="850px">
                            <PagerStyle CssClass="grid_page" />
                            <RowStyle CssClass="grid" HorizontalAlign="Left" />
                            <Columns>
                                <asp:BoundField DataField="Cliente" HeaderText="Cliente" />
                                <asp:BoundField DataField="Telefone 1" HeaderText="Telefone 1" />
                                <asp:BoundField DataField="Status" HeaderText="Status" />
                                <asp:BoundField DataField="Data do Agendamento" HeaderText="Data do Agendamento" />
                                <asp:BoundField DataField="Observação" HeaderText="Observação" />                                
                            </Columns>
                            <HeaderStyle CssClass="grid_header" HorizontalAlign="Justify" />
                            <AlternatingRowStyle CssClass="grid_alternative_row" />
                        </asp:GridView>
                        </div>
                </fieldset>
            </div>
            <div class="clear">
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
