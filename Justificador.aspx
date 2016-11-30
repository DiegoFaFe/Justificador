﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Base.master" AutoEventWireup="true" CodeFile="Justificador.aspx.cs" Inherits="Justificador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <div class="container theme-showcase" role="main">

      <!-- Main jumbotron for a primary marketing message or call to action -->
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
              <asp:TextBox class="col-sm-12" ID="TBEntrada" CssClass="form-control" runat="server" OnTextChanged="TBEntrada_TextChanged"></asp:TextBox>
            </div>
          </div>
          <div class="panel panel-primary">
            <div class="panel-heading">
              <h3 class="panel-title">Número de caracteres por columna</h3>
            </div>
            <div class="panel-body" style="text-align: center;">
              <h3>  
                    <asp:LinkButton ID="BotonMenos" CssClass="btn btn-sm btn-primary" runat="server" OnClick="BotonMenos_Click"><span class="glyphicon glyphicon-minus"></span></asp:LinkButton>
                    <asp:Label ID="LabelColumnas" CssClass="label label-primary" runat="server" Text="61"></asp:Label>
                    <asp:LinkButton ID="BotonMas" CssClass="btn btn-sm btn-primary" runat="server" OnClick="BotonMas_Click"><span class="glyphicon glyphicon-plus"></span></asp:LinkButton>
              </h3>
            </div>
          </div>
        </div>
        <div class="col-sm-6">
          <div class="<%= "panel panel-"+Estilo(Estado)%>">
            <div class="panel-heading">
              <h3 class="panel-title">Texto justificado</h3>
            </div>
            <div class="panel-body">
              <asp:TextBox class="col-sm-12" ID="TBSalida" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
          </div>
        </div>
          <!--default primary success info warning danger-->
      </div>
      </ContentTemplate>
      </asp:UpdatePanel>


      <div class="page-header">
        <h1>Notas</h1>
      </div>
      <div class="well">
        <p></p>
      </div>

    </div>

</asp:Content>

