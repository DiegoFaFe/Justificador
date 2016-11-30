using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Justificador : System.Web.UI.Page
{
    protected enum Fases { Default, Final, Release, Test, Development }
    protected Fases Estado { get; private set; }
    protected short Columnas;
    protected Texto texto;

    protected void Page_Load(object sender, EventArgs e)
    {
        Estado = Fases.Release;

        Title = "El Justificador";
        TBEntrada.AutoPostBack = true;
        TBEntrada.TextMode = TextBoxMode.MultiLine;
        TBEntrada.Rows = 10;
        TBSalida.ReadOnly = true;
        TBSalida.TextMode = TextBoxMode.MultiLine;
        TBSalida.Rows = 10;

        Columnas = Convert.ToInt16(LabelColumnas.Text);
        texto = new Texto(Columnas, TBEntrada.Text);
    }

    protected string Estilo(Fases estado)
    {
        //success info warning danger
        switch (estado)
        {
            case Fases.Final: return "success";
            case Fases.Release: return "info";
            case Fases.Test: return "warning";
            case Fases.Development: return "danger";
            default: return "primary";
        }
    }

    protected void TBEntrada_TextChanged(object sender, EventArgs e)
    {
        TBSalida.Text = texto.Refrescar(TBEntrada.Text);
    }

    protected void BotonMenos_Click(object sender, EventArgs eventArgs)
    {
        if (Columnas > 6)
        { 
            Columnas--;
            LabelColumnas.Text = Columnas.ToString();
        }
        TBSalida.Text = texto.Refrescar(Columnas);
    }
    protected void BotonMas_Click(object sender, EventArgs eventArgs)
    {
        if (Columnas < 61)
        {
            Columnas++;
            LabelColumnas.Text = Columnas.ToString();
        }
        TBSalida.Text = texto.Refrescar(Columnas);
    }
}