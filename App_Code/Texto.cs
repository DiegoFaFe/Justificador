using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Descripción breve de Texto
/// </summary>
public class Texto
{
    private readonly List<Palabra> _palabras;
    private short _columnas;

    public Texto(int columnas, string s)
    {
        _columnas = (short) columnas;
        _palabras = new List<Palabra>();
        foreach (var t in s.Replace(((char)10).ToString(), " \n").Split(' '))
        {
            _palabras.Add(new Palabra(t));
        }
    }

    public string Refrescar(string s)
    {
        _palabras.Clear();
        foreach (var t in s.Replace(((char)10).ToString(), " \n").Split(' '))
        {
            _palabras.Add(new Palabra(t));
        }
        return _columnas == -1 ? "" : Justificar();
    }
    public string Refrescar(short c)
    {
        _columnas = c;
        return _palabras.Count == 0 ? "" : Justificar();
    }

    private string Justificar()
    {
        var texto = "";
        var espacio = _columnas;
        foreach (var t in _palabras)
        {
            var temp = t.Formato(_columnas, espacio);
            texto += temp.Item2;
            espacio = temp.Item1;
        }
        return texto;
    }
}