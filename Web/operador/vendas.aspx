<%@ Page Language="C#" AutoEventWireup="true" CodeFile="vendas.aspx.cs" Inherits="operador_vendas" %>

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

        
    <style type="text/css">


    </style>
</head>
<body>
    <form id="form1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="3600">
    </asp:ScriptManager>
    
      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
       <Triggers>
            <asp:PostBackTrigger ControlID="btnExportar" />
        </Triggers>
       <ContentTemplate>
       
       <h1>
                <asp:Label ID="lblTituloFormulario" runat="server" Text="Vendas" CssClass="label_h1"></asp:Label>
            </h1>
           <fieldset class="fieldset_l">
                <legend>Filtro do Relatório</legend>
                <div class="div_padrao">
          
             

               <table class="style1">
                   <tr>
                       <td class="style12" style="text-align: left">
                           <asp:Label ID="lblCampanha" runat="server" CssClass="label" Text="Campanha:"></asp:Label>
                       </td>
                       <td class="style3" style="text-align: left" colspan="5">
                           <asp:DropDownList ID="dropCampanha" runat="server" AutoPostBack="True" 
                               CssClass="dropdown" onselectedindexchanged="dropCampanha_SelectedIndexChanged" 
                               Width="344px">
                           </asp:DropDownList>
                       </td>
                   </tr>
                   <tr>
                       <td class="style12" style="text-align: left">
                           <asp:Label ID="lblDataInicial" runat="server" CssClass="label" 
                               Text="Data Inicial:"></asp:Label>
                       </td>
                       <td class="style3" style="text-align: left">
                           <asp:TextBox ID="txtdatDataInicial" runat="server" CssClass="textbox" 
                               style="text-align: left" onkeydown="mascara(this,data)" onkeypress="mascara(this,data)" onkeyup="mascara(this,data)"></asp:TextBox>
                           <asp:CalendarExtender ID="txtdatDataInicial_CalendarExtender" runat="server" 
                               CssClass="cal_Theme1" Format="dd/MM/yyyy" TargetControlID="txtdatDataInicial">
                           </asp:CalendarExtender>
                       </td>
                       <td class="style11" style="text-align: left">
                           <asp:Label ID="lblDataFinal" runat="server" CssClass="label" Text="Data Final:"></asp:Label>
                       </td>
                       <td class="style5" style="text-align: left">
                           <asp:TextBox ID="txtdatDataFinal" runat="server" CssClass="textbox" 
                               style="text-align: left" onkeydown="mascara(this,data)" onkeypress="mascara(this,data)" onkeyup="mascara(this,data)"></asp:TextBox>
                           <asp:CalendarExtender ID="txtdatDataFinal_CalendarExtender" runat="server" 
                               CssClass="cal_Theme1" Format="dd/MM/yyyy" TargetControlID="txtdatDataFinal">
                           </asp:CalendarExtender>
                       </td>
                       <td class="style17" style="text-align: left">
                           <asp:Label ID="lblTelfone1" runat="server" CssClass="label" Text="Telefone 1:"></asp:Label>
                       </td>
                       <td class="style16" style="text-align: left">
                           <asp:TextBox ID="txtTelefone1_filtro" runat="server" CssClass="textbox" 
                               style="text-align: left" MaxLength="11" onkeydown="mascara(this,soNumeros)" onkeypress="mascara(this,soNumeros)" onkeyup="mascara(this,soNumeros)"></asp:TextBox>
                       </td>
                   </tr>
                   <tr>
                       <td class="style12" style="text-align: left">
                           <asp:Label ID="lblNome" runat="server" CssClass="label" Text="Nome:"></asp:Label>
                       </td>
                       <td class="style3" style="text-align: left">
                           <asp:TextBox ID="txtNome_filtro" runat="server" CssClass="textbox" 
                               style="text-align: left" Width="208px" MaxLength="200"></asp:TextBox>
                       </td>
                       <td class="style11" style="text-align: left">
                           <asp:Label ID="lblCPFCNPJ" runat="server" CssClass="label" Text="CPF / CNPJ:"></asp:Label>
                       </td>
                       <td class="style5" style="text-align: left">
                           <asp:TextBox ID="txtCPFCNPJ_filtro" runat="server" CssClass="textbox" 
                               style="text-align: left" MaxLength="18" onkeydown="mascara(this,soNumeros)" onkeypress="mascara(this,soNumeros)" onkeyup="mascara(this,soNumeros)"></asp:TextBox>
                       </td>
                       <td class="style17" style="text-align: left">
                           <asp:Label ID="lblOperadoresAuditoria" runat="server" CssClass="label" 
                               Text="Operador:"></asp:Label>
                       </td>
                       <td class="style16" style="text-align: left">
                           <asp:DropDownList ID="DropOperador" runat="server" CssClass="dropdown" 
                               Width="193px">
                           </asp:DropDownList>
                       </td>
                       <td style="text-align: left">
                           &nbsp;</td>
                   </tr>
                   <tr>
                       <td class="style12" style="text-align: left">
                           <asp:Label ID="lblStatusAuditoria" runat="server" CssClass="label" 
                               Text="Status Auditoria:"></asp:Label>
                       </td>
                       <td class="style3" style="text-align: left" colspan="4">
                           <asp:DropDownList ID="dropStatusAuditoria" runat="server" CssClass="dropdown" 
                               Width="344px">
                           </asp:DropDownList>
                       </td>
                   </tr>
                   <tr>
                       <td class="style12" style="text-align: left">
                           <asp:Label ID="lblDadosVenda" runat="server" CssClass="label" 
                               Text="Dados da venda:"></asp:Label>
                       </td>
                       <td class="style3" style="text-align: left">
                           <asp:DropDownList ID="dropDadosVenda" runat="server" CssClass="dropdown" 
                               Width="204px">
                           </asp:DropDownList>
                       </td>
                       <td class="style11" colspan="3" style="text-align: left">
                           <asp:TextBox ID="txtTextoDadosVenda" runat="server" CssClass="textbox" 
                               style="text-align: left" Width="252px"></asp:TextBox>
                       </td>
                   </tr>
                   <tr>
                       <td style="text-align: left" colspan="6" height="15">
                           &nbsp;</td>
                   </tr>
                   <tr>
                       <td class="style12" colspan="6" style="text-align: left">
                           <asp:Button ID="btnGerar" runat="server" CssClass="botao" 
                               onclick="btnGerar_Click" Text="Gerar" />
                           &nbsp;<asp:Button ID="btnExportar" runat="server" CssClass="botao" 
                               Text="Exportar" onclick="btnExportar_Click" />
                       </td>
                   </tr>
               </table>

           </div>
                    
            </fieldset>

           
           <fieldset class="fieldset_l">
                <legend>Dados da Venda</legend>
                <div class="div_relatorio">
                    <asp:Label ID="lblRegistros" runat="server" CssClass="label_descricao" 
                        Text="| 0 registro(s) |"></asp:Label>
                    
               <asp:GridView ID="grdDados" CssClass="grid" runat="server" 
                   AutoGenerateColumns="True" EnableModelValidation="True" 
                        onrowdatabound="grdDados_RowDataBound">
                  <Columns>
                            
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
