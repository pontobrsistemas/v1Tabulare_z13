<%@ page language="C#" autoeventwireup="true" title="Tabulare CRM" inherits="operador_trocarSenha, App_Web_wzw5p3vb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script src="../scripts/mascara.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="../css/print.css" />
    <script src="../fancy/jquery-1.8.3.js" type="text/javascript"></script>
    <script src="../fancy/jquery.fancybox.pack.js" type="text/javascript"></script>
    <link href="../fancy/jquery.fancybox.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="3600">
    </asp:ScriptManager>
    </asp:Content>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <h1>
                Trocar Senha
            </h1>
            <div class="box_fancy">
                <fieldset class="fieldset_l"><legend>Trocar Senha</legend>
                    <br />
                    <table class="style1">
                        <tr>
                            <td class="style2">
                                <asp:Label ID="lblSenhaAtual" runat="server" CssClass="label" Text="Senha Atual:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSenhaAtual" CssClass="textbox" runat="server" 
                                    TextMode="Password"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style2">
                                <asp:Label ID="lblNovaSenha" runat="server" CssClass="label" Text="Nova Senha:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtNovaSenha" runat="server" CssClass="textbox" 
                                    TextMode="Password"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style2">
                                <asp:Label ID="lblRepitaNovaSenha" runat="server" CssClass="label" Text="Repita Nova Senha:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtRepetirNovaSenha" runat="server" CssClass="textbox" 
                                    TextMode="Password"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style2">
                                &nbsp;
                            </td>
                            <td>
                                <asp:Button ID="bntSalvar" runat="server" CssClass="botao" Text="Salvar" OnClick="bntSalvar_Click" />
                                &nbsp;&nbsp;
                                </td>
                        </tr>
                    </table>
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
