<%@ page title="Tabulare CRM" language="C#" masterpagefile="~/MasterPage/supervisor.master" autoeventwireup="true" inherits="relatorio_cliente, App_Web_wym5kje3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
       <Triggers>
            
        </Triggers>
       <ContentTemplate>
       
       <h1>
                <asp:Label ID="lblTituloFormulario" runat="server" Text="Cliente" CssClass="label_h1"></asp:Label>
            </h1>
           <fieldset class="fieldset_atendimento">
                <legend>Dados do Cliente</legend>
                <div class="div_relatorio">
          
               <table class="style1">
                   <tr>
                       <td style="text-align: right">
                           <asp:Label ID="lblNome" runat="server" CssClass="label" Text="Nome:"></asp:Label>
                       </td>
                       <td class="style5">
                           <asp:TextBox ID="txtNome" runat="server" CssClass="textbox" MaxLength="100" 
                               Width="505px" ReadOnly="True"></asp:TextBox>
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

</asp:Content>

