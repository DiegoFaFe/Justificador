<%@ Page Title="" Language="C#" MasterPageFile="~/Base.master" AutoEventWireup="true" CodeFile="Justificador.aspx.cs" Inherits="Justificador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <div class="container theme-showcase" role="main">
      <div class="jumbotron" style="text-justify:inter-word">
        <h1>Justificador de textos</h1>
        <p style="text-indent: 5%;">La prueba técnica consiste en escribir un algoritmo en C# que pida por pantalla un texto y un número. El entero representa un número de columnas por el que dividiremos el texto.</p>
		<p style="text-indent: 5%;">La aplicación tiene que devolver el texto con saltos de líneas insertados, de forma que ninguna de las líneas sea más larga (el número de caracteres, incluidos espacios) que el número de columnas que le hemos indicado. Intenta que las líneas sean lo más largas posible, dentro del límite, y siempre que puedas, pon el salto de línea en el espacio entre palabras.</p>
		<p></p>
      </div>

      <div class="page-header">
        <h1>Estado Actual: </h1>
      </div>
      <div class="<%= "alert alert-"+Estilo(Estado)%>" role="alert">
        <% switch (Estado){case Fases.Final: %>
        <strong>¡Prueba Superada!</strong> Este código ha superado la prueba.
        <% break; case Fases.Release: %>
        <strong>Versión Final</strong> Este código está en su versión final esperando su evaluación.
        <% break; case Fases.Test: %>
        <strong>Pruebas</strong> Este código está aún en fase de pruebas.
        <% break; case Fases.Development: %>
        <strong>No operativo</strong> Trabajando en ello.
        <% break;} %>
      </div>
      <div class="page-header">
        <h1>Demostración</h1>
      </div>
      <asp:UpdatePanel ID="UpdatePanels" runat="server">
      <ContentTemplate>
      <div class="row">
        <div class="col-sm-6">
          <div class="<%= "panel panel-"+Estilo(Estado)%>">
            <div class="panel-heading">
              <h3 class="panel-title">Entrada de texto</h3>
            </div>
            <div class="panel-body">
              <asp:TextBox class="col-sm-12" ID="TBEntrada" CssClass="form-control" runat="server" OnTextChanged="TBEntrada_TextChanged" style="resize:none;"></asp:TextBox>
            </div>
          </div>
          <div class="panel panel-primary">
            <div class="panel-heading">
              <div class="input-group">
                  <div class="input-group-addon"><span class="glyphicon glyphicon-align-justify"/>Número de caracteres por columna</div>
                  <asp:TextBox ID="SpinColumnas" CssClass="form-control input-lg" runat="server" type="number" min="5" max="61" step="1" Text="61" OnTextChanged="SpinColumnas_TextChanged"/>
              </div>
            </div>
          </div>
        </div>
        <div class="col-sm-6">
          <div class="<%= "panel panel-"+Estilo(Estado)%>">
            <div class="panel-heading">
              <h3 class="panel-title">Texto justificado</h3>
            </div>
            <div class="panel-body">
              <asp:TextBox class="col-sm-12" ID="TBSalida" CssClass="form-control" runat="server" style="resize:none;"></asp:TextBox>
            </div>
          </div>
        </div>
          <!--default primary success info warning danger-->
      </div>
      </ContentTemplate>
      </asp:UpdatePanel>


      <div class="page-header">
        <h1>Notas
        <div class="btn-group">
            <a href="/Codigos.aspx#Justificador" class="btn btn-default">Códigos</a>
            <a href="/Codigos.aspx#Justificador" class="btn btn-default dropdown-toggle" data-toggle="dropdown"><span class="caret"></span></a>
            <ul class="dropdown-menu">
                <li><a href="https://github.com/DiegoFaFe/Justificador/archive/master.zip"><span class="glyphicon glyphicon-download"/>Descarga directa(.zip)</a></li>
                <li><a href="https://github.com/DiegoFaFe/Justificador"><span class="fa fa-github"/>Github</a></li>
                <li class="divider"></li>
                <li><a href="#"><span class="glyphicon glyphicon-folder-open"/>Descarga Completa</a></li>
            </ul>
        </div>
        </h1>
      </div>
      <div class="well">
        <h3>v1.1 <small><time datetime="2016-12-10T22:10:19+01:00">10 de diciembre del 2016</time></small></h3>
        <p style="text-indent: 5%;">-Se cambia la entrada del número de caracteres por columna a un spinbox</p>
        <p style="text-indent: 5%;">-Se rebaja el tamaño mínimo de columna de 6 a 5</p>
        <p style="text-indent: 5%;">-Ahora los guiones(-) no son contabilizados como caracteres</p>
        <h3>v1.0 <small><time datetime="2016-11-30T12:37:52+01:00">30 de noviembre del 2016</time></small></h3>
        <p style="text-indent: 5%;">-Primera versión completamente funcional</p>
      </div>

    </div>

</asp:Content>

