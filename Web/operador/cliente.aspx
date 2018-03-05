<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cliente.aspx.cs" 
Inherits="operador_cliente" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title></title>

    <script src="../scripts/mascara.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="../css/print.css" />

    <style type="text/css">
        fieldset div.label span.block {width:110px;}
        fieldset div.label span.y {width:45px !important;}
    </style>

    <script src="../fancy/jquery-1.8.3.js" type="text/javascript"></script>
    <script src="../fancy/jquery.fancybox.pack.js" type="text/javascript"></script>
    <link href="../fancy/jquery.fancybox.css" rel="stylesheet" type="text/css" />

        <script type="text/javascript">

            function AbrirbackofficeVenda_filtro() {
                parent.window.location.href = "atendimento.aspx?acao=backofficeVenda_filtro";
            }       
    </script>

    <style type="text/css">


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
                <asp:Label ID="lblTituloFormulario" runat="server" Text="Cliente" CssClass="label_h1"></asp:Label>
            </h1>
           <fieldset class="fieldset_l">
                <legend>Dados do Cliente</legend>
                <div class="div_padrao">
          
             

               <table class="style1">
                   <tr>
                       <td style="text-align: right">
                           <asp:Label ID="lblNome" runat="server" CssClass="label" Text="Nome:"></asp:Label>
                       </td>
                       <td class="style5">
                           <asp:TextBox ID="txtNome" runat="server" CssClass="textbox" MaxLength="100" 
                               Width="413px" ReadOnly="True"></asp:TextBox>
                           <asp:Label ID="lblCPF" runat="server" CssClass="label" Text="CPF / CNPJ:"></asp:Label>
                           <asp:TextBox ID="txtCPF_CNPJ" runat="server" CssClass="textbox" MaxLength="15" 
                               ReadOnly="True"></asp:TextBox>
                       </td>
                   </tr>
                   <tr>
                       <td style="text-align: right">
                           <asp:Label ID="lblTelefone1" runat="server" CssClass="label" Text="Telefone1:"></asp:Label>
                       </td>
                       <td class="style6">
                           <asp:TextBox ID="txtTelefone1" runat="server" CssClass="textbox" MaxLength="11" 
                               ReadOnly="True"></asp:TextBox>
                           <asp:Label ID="lblTelefone2" runat="server" CssClass="label" Text="Telefone2:"></asp:Label>
                           <asp:TextBox ID="txtTelefone2" runat="server" CssClass="textbox" MaxLength="11" 
                               ReadOnly="True"></asp:TextBox>
                           <asp:Label ID="lblTelefone3" runat="server" CssClass="label" Text="Telefone3:"></asp:Label>
                           <asp:TextBox ID="txtTelefone3" runat="server" CssClass="textbox" MaxLength="11" 
                               ReadOnly="True"></asp:TextBox>
                       </td>
                   </tr>
                   <tr>
                       <td>
                           <asp:Label ID="lblLogradouro" runat="server" CssClass="label" 
                               Text="Logradouro:"></asp:Label>
                       </td>
                       <td class="style6">
                           <asp:TextBox ID="txtLogradouro" runat="server" CssClass="textbox" 
                               MaxLength="100" Width="350px" ReadOnly="True"></asp:TextBox>
                           <asp:Label ID="lblNum" runat="server" CssClass="label" Text="Núm:"></asp:Label>
                           <asp:TextBox ID="txtNumero" runat="server" CssClass="textbox" MaxLength="50" 
                               ReadOnly="True"></asp:TextBox>
                           <asp:Label ID="lblComplemento" runat="server" CssClass="label" Text="Compl:"></asp:Label>
                           <asp:TextBox ID="txtComplemento" runat="server" CssClass="textbox" 
                               MaxLength="50" ReadOnly="True"></asp:TextBox>
                       </td>
                   </tr>
                   <tr>
                       <td style="text-align: right">
                           <asp:Label ID="lblBairro" runat="server" CssClass="label" Text="Bairro:"></asp:Label>
                       </td>
                       <td class="style6">
                           <asp:TextBox ID="txtBairro" runat="server" CssClass="textbox" MaxLength="100" 
                               ReadOnly="True"></asp:TextBox>
                           <asp:Label ID="lblCidade" runat="server" CssClass="label" Text="Cidade:"></asp:Label>
                           <asp:TextBox ID="txtCidade" runat="server" CssClass="textbox" MaxLength="100" 
                               Width="160px" ReadOnly="True"></asp:TextBox>
                           <asp:Label ID="lblEstado" runat="server" CssClass="label" Text="Estado:"></asp:Label>
                           <asp:TextBox ID="txtEstado" runat="server" CssClass="textbox" MaxLength="50" 
                               Width="157px" ReadOnly="True"></asp:TextBox>
                       </td>
                   </tr>
                   <tr>
                       <td style="text-align: right">
                           <asp:Label ID="lblEmail" runat="server" CssClass="label" Text="Email:"></asp:Label>
                       </td>
                       <td class="style6">
                           <asp:TextBox ID="txtEmail" runat="server" CssClass="textbox" MaxLength="100" 
                               Width="395px" ReadOnly="True"></asp:TextBox>
                           <asp:Label ID="lblCep" runat="server" CssClass="label" Text="CEP:"></asp:Label>
                           <asp:TextBox ID="txtCep" runat="server" CssClass="textbox" MaxLength="10" 
                               ReadOnly="True"></asp:TextBox>
                       </td>
                   </tr>
                   <tr>
                       <td class="style12" style="text-align: left" colspan="2">
                           <asp:Button ID="cmdVoltar" runat="server" CssClass="botao" 
                               OnClientClick="javascript:history.back(-1)" Text="Voltar" />
                           &nbsp;</td>
                   </tr>
                   <tr>
                       <td style="text-align: left" colspan="2" height="15">
                           &nbsp;</td>
                   </tr>
               </table>

           </div>
                    
            </fieldset>

           
           <fieldset class="fieldset_l">
                <legend>Histórico de Contatos</legend>
                <div class="div_relatorio">
                    <asp:Label ID="lblRegistros" runat="server" CssClass="label_descricao" 
                        Text="| 0 registro(s) |"></asp:Label>
                    
               <asp:GridView ID="grdDados" CssClass="grid" runat="server" 
                   AutoGenerateColumns="False" EnableModelValidation="True" 
                        onrowdatabound="grdDados_RowDataBound" >
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
          </div>
                    
            </fieldset>
            
       </ContentTemplate>
    </asp:UpdatePanel>
    
    </form>
</body>
</html>
