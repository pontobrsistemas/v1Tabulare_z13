<%@ page title="Tabulare CRM" language="C#" masterpagefile="~/MasterPage/backoffice.master" autoeventwireup="true" inherits="backoffice_Default, App_Web_nwlk444e" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <script type="text/javascript">
        google.load("visualization", "1", { packages: ["corechart"] });
        google.setOnLoadCallback(drawChart);
        function drawChart() {
        var data = google.visualization.arrayToDataTable([
	        <%RetornarContatosOperadores(); %>]);

            var options = {
                title: '',
                legend: { position: 'none' },
                hAxis: {slantedText:true, slantedTextAngle:90 }
            };

            var chart = new google.visualization.ColumnChart(document.getElementById('contatos dos operadores'));
            chart.draw(data, options);
        }
    </script>
    <script type="text/javascript">
        google.load("visualization", "1", { packages: ["corechart"] });
        google.setOnLoadCallback(drawChart);
        function drawChart() {
        var data = google.visualization.arrayToDataTable([
	        <%RetornarVendas(); %>]);

            var options = {
                title: '',
                legend: { position: 'none' },
                hAxis: {slantedText:true, slantedTextAngle:90 }
            };

            var chart = new google.visualization.ColumnChart(document.getElementById('Vendas'));
            chart.draw(data, options);
        }
    </script>
    <script type="text/javascript">
        google.load("visualization", "1", { packages: ["corechart"] });
        google.setOnLoadCallback(drawChart);
        function drawChart() {
        var data = google.visualization.arrayToDataTable([
	        <%RetornarMailingVirgem(); %>]);

            var options = {
                title: '',
                legend: { position: 'none' },
                hAxis: {slantedText:true, slantedTextAngle:90 }
            };

            var chart = new google.visualization.ColumnChart(document.getElementById('Mailing Virgem'));
            chart.draw(data, options);
        }
    </script>
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <script type="text/javascript">
        google.load("visualization", "1", { packages: ["corechart"] });
        google.setOnLoadCallback(drawChart);
        function drawChart() {
        var data = new google.visualization.DataTable();

        data.addColumn('string');
        data.addColumn('number');

        data.addRows([<%RetornarStatusContatos(); %>]);

            var options = {
                title: '',
                legend: { position: 'none' }
            };

            var chart = new google.visualization.PieChart(document.getElementById('Status'));
            chart.draw(data, options);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
            <h1>
                Inicial - Dashboard
            </h1>
            <div class="box_dashboard">
                <fieldset class="fieldset_filtro">
                    <legend runat="server" id="legend_filtro">Filtro</legend>
                    <div id="filtro">
                        <asp:Label runat="server" Text="Campanha:" CssClass="label" ID="lblCampanha"></asp:Label>
                        <asp:DropDownList runat="server" Width="250px" ID="dropCampanha" CssClass="dropdown">
                        </asp:DropDownList>
                        &nbsp;<asp:Label runat="server" Text="Período:" CssClass="label" ID="lblPeriodo"></asp:Label>
                        <asp:TextBox ID="txtdatDataInicial" runat="server" CssClass="textbox" Style="text-align: left"
                            Width="80px" onkeydown="mascara(this,data)" onkeypress="mascara(this,data)" onkeyup="mascara(this,data)"></asp:TextBox>
                        <asp:CalendarExtender ID="txtdatDataInicial_CalendarExtender" runat="server" CssClass="cal_Theme1"
                            Format="dd/MM/yyyy" TargetControlID="txtdatDataInicial">
                        </asp:CalendarExtender>
                        &nbsp;a
                        <asp:TextBox ID="txtdatDataFinal" runat="server" CssClass="textbox" Style="text-align: left"
                            Width="80px" onkeydown="mascara(this,data)" onkeypress="mascara(this,data)" onkeyup="mascara(this,data)"></asp:TextBox>
                        <asp:CalendarExtender ID="txtdatDataFinal_CalendarExtender" runat="server" CssClass="cal_Theme1"
                            Format="dd/MM/yyyy" TargetControlID="txtdatDataFinal">
                        </asp:CalendarExtender>
                        &nbsp;<asp:CheckBox ID="chkTop10" runat="server" Text="Exibir os 10 maiores" Checked="true"
                            class="chekBoxList" />
                        &nbsp;<asp:Button ID="cmdAtualizar" runat="server" CssClass="botao" Text="Atualizar"
                            OnClick="cmdAtualizar_Click" Width="100px" />
                    </div>
                </fieldset>
                <fieldset class="fieldset_l_dashboard">
                    <legend runat="server" id="legenda_contatos_realizados">contatos dos operadores hoje</legend>
                    <div id="contatos dos operadores" style="width: 905px; height: 200px;" />
                </fieldset>
                <fieldset class="fieldset_l_dashboard ">
                    <legend runat="server" id="legenda_vendas">venda(s) efetivadas hoje</legend>
                    <div id="Vendas" style="width: 905px; height: 200px;" />
                </fieldset>
                <br />
                <fieldset class="fieldset_l_dashboard ">
                    <legend runat="server" id="legenda_mailing_virgem">prospects virgens disponíveis</legend>
                    <div id="Mailing Virgem" style="width: 450px; height: 200px;" />
                </fieldset>
                <fieldset class="fieldset_l_dashboard ">
                    <legend runat="server" id="legenda_status_contato">Status dos contatos realizados</legend>
                    <div id="Status" style="width: 450px; height: 200px;" />
                </fieldset>
                <div class="clear">
                </div>
            </div>
</asp:Content>


