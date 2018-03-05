<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="login_Default"
    ValidateRequest="false" %>

<%@ Register Assembly="PontoBr" Namespace="PontoBr.CustomWebControls" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tabulare CRM</title>
    <script src="../scripts/mascara.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="../css/Login.css" />
    </head>
<body>
    <div class="geral">
        <div class="topo">
        </div>
        <div class="login">
            <form runat="server" class="formlogin">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <p>
                        <strong>Login</strong><br />
                        <cc1:CustomTextBox ID="txtUsuario"                        
                        runat="server" CssClass="textbox"></cc1:CustomTextBox>
                        <asp:FilteredTextBoxExtender runat="server" ID="filterUsuario" FilterMode="InvalidChars" InvalidChars="'" TargetControlID="txtUsuario">
                        </asp:FilteredTextBoxExtender>
                    </p>
                    <p>
                        <strong>Senha</strong><br />
                        <cc1:CustomTextBox ID="txtSenha" runat="server" TextMode="Password" 
                            CssClass="textbox"></cc1:CustomTextBox>
                        <asp:FilteredTextBoxExtender ID="filterSenha" runat="server" FilterMode="InvalidChars"
                            InvalidChars="'" TargetControlID="txtSenha">
                        </asp:FilteredTextBoxExtender>
                    </p>
                    <p>
                        <strong>Ramal</strong><br />
                        <cc1:CustomTextBox ID="txtRamal" runat="server" CssClass="textbox"></cc1:CustomTextBox>
                        <asp:FilteredTextBoxExtender ID="filterRamal" runat="server" FilterMode="InvalidChars"
                            InvalidChars="'" TargetControlID="txtRamal">
                        </asp:FilteredTextBoxExtender>
                        
                        
                    </p>

                    <asp:Button ID="cmdEntrar" runat="server" CssClass="botao" 
                                        OnClick="cmdEntrar_Click" Text="Entrar" />
                        <br/>

                    
                        
                    
                </ContentTemplate>
            </asp:UpdatePanel>
            </form>
        </div>
        <div class="rodape">
            
            
            <asp:Label ID="lblCopyright" runat="server" 
                Text="Copyright © 2015 - PontoBR Sistemas"></asp:Label>
            
            
&nbsp;</div>
    </div>
</body>
</html>
