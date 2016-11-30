using System;
using System.Text;

/// <summary>
/// Unidad lógica más que sintáctica(puede contener carácteres especiales)
/// </summary>
public class Palabra
{
    private readonly string _cadena;
    private char[] _char;
    public Palabra(string s)
    {
        _cadena = s;
        Silabeador();
    }

    private void Silabeador()
    {
        var temp = new StringBuilder();
        for (var i = 0; i < _cadena.Length; i++)
        {
            temp.Append(_cadena[i]);
            if (!Vocal(_cadena[i]) || i==0) continue;
            switch (_cadena[i - 1])
            {
                case 'r':
                    if (i > 1 && (_cadena[i - 2] == 'd' || _cadena[i - 2] == 'D'))
                    {
                        if(i > 2) temp.Insert(temp.Length - 3, '-');
                        break;
                    }
                    goto case 'l';
                    
                case 'l':
                    if (i > 1 && (_cadena[i - 2] == 'l' || _cadena[i - 2] == 't' || _cadena[i - 2] == 'p' ||
                        _cadena[i - 2] == 'b' || _cadena[i - 2] == 'g' || _cadena[i - 2] == 'f' ||
                        _cadena[i - 2] == 'L' || _cadena[i - 2] == 'T' || _cadena[i - 2] == 'P' ||
                        _cadena[i - 2] == 'B' || _cadena[i - 2] == 'G' || _cadena[i - 2] == 'F'))
                    {
                        if (i > 2) temp.Insert(temp.Length - 3, '-');
                        break;
                    }
                    goto case 'h';
                case 'h':
                    if (i > 1 && (_cadena[i - 2] == 'c' || _cadena[i - 2] == 'C'))
                    {
                        if (i > 2) temp.Insert(temp.Length - 3, '-');
                        break;
                    }
                    goto default;
                default:
                    if (i > 1) { temp.Insert(temp.Length - 2, '-');}
                    break;
            }
            if (i == _cadena.Length-1 || !Vocal(_cadena[i + 1])) continue;
            if (Hiato(i))
            {
                temp.Append('-');
                continue;
            }
            if (Triptongo(i))
            {
                temp.Append(new[] { _cadena[i + 1], _cadena[i + 2] });
                i += 2;
            }
            else
            {
                if (!Diptongo(i))continue;

                temp.Append(new[] { _cadena[i + 1] });
                i++;
            }
        }
        _char = new char[temp.Length];
        temp.CopyTo(0, _char, 0, temp.Length);
    }
    /// <summary>
    /// Función que retorna la palabra formateada atendiendo al espacio disponible
    /// </summary>
    /// <param name="columnas">El ancho máximo de columna</param>
    /// <param name="espacio">El espacio que queda en la columna actual</param>
    /// <returns>Tupla que contiene: 
    /// -El espacio que queda en la columna actual
    /// -La cadena con la palabra formateada
    /// </returns>
    public Tuple<short, string> Formato(short columnas, short espacio)
    {
        if(_cadena==((char)10).ToString()) return new Tuple<short, string>(columnas,Environment.NewLine);
        if (espacio >= _cadena.Length + (espacio < columnas ? 1 : 0))
        {
            return new Tuple<short, string>((short)(espacio - _cadena.Length - (espacio < columnas ? 1 : 0)),
                espacio < columnas ? " " + _cadena : _cadena);
        }
        var formateado = new StringBuilder();
        var temp = "";
        var lineaUsada = 0;
        for (var i = 0; i < _char.Length; i++)
        {
            if (_char[i] != '-')
            {
                formateado.Append(_char[i]);
                if (i != _char.Length - 1) { continue; }
            }
            if (espacio < formateado.Length + (espacio < columnas ? 2 : 1))//Espacio + guión o solo guión
            {
                if (lineaUsada>0) temp += "-";
                temp += Environment.NewLine;
                espacio = columnas;
                lineaUsada = 0;
            }
            else { if(espacio < columnas && lineaUsada == 0) { temp += " "; espacio--;} }
            espacio -= (short)formateado.Length;
            temp += formateado;
            lineaUsada++;
            formateado.Clear();
        }
        return new Tuple<short, string>(espacio, temp);
    }

    private static bool Vocal(char c)
    {
        return c == 'e' || c == 'a' || c == 'o' || c == 'i' || c == 'u' || c == 'ó' || c == 'í' || 
               c == 'á' || c == 'é' || c == 'ú' || c == 'ü' || c == 'E' || c == 'A' || c == 'O' || 
               c == 'I' || c == 'U' || c == 'Ó' || c == 'Í' || c == 'Á' || c == 'É' || c == 'Ú' || 
               c == 'Ü';
    }

    private static bool VocalDebil(char c)
    {
        return c == 'i' || c == 'u' || c == 'ü' || c == 'I' || c == 'U' || c == 'Ü';
    }
    /// <summary>
    /// Devuelve la comprobación de si la vocal es fuerte o débil tónica(incluida aquí para los casos de hiatos)
    /// El único caso en el que podría interferir de manera inesperada es en los diptongos (d-d)
    /// pero en este caso seguiría categorizandose como diptongo (d-f)
    /// </summary>
    /// <param name="c">Caracter a comprobar</param>
    /// <returns>Es vocal fuerte o débil tónica</returns>
    private static bool VocalFuerte(char c)
    {
        return c == 'e' || c == 'a' || c == 'o' || c == 'ó' || c == 'í' || c == 'á' || c == 'é' || 
               c == 'ú' || c == 'E' || c == 'A' || c == 'O' || c == 'Ó' || c == 'Í' || c == 'Á' || 
               c == 'É' || c == 'Ú';
    }

    private static bool Consonante(char c)
    {
        return c == 's' || c == 'n' || c == 'r' || c == 'l' || c == 'd' || c == 't' || c == 'c'
            || c == 'm' || c == 'p' || c == 'b' || c == 'h' || c == 'q' || c == 'y' || c == 'v'
            || c == 'g' || c == 'f' || c == 'j' || c == 'z' || c == 'ñ' || c == 'x' || c == 'k'
            || c == 'w'
            || c == 'S' || c == 'N' || c == 'R' || c == 'L' || c == 'D' || c == 'T' || c == 'C'
            || c == 'M' || c == 'P' || c == 'B' || c == 'H' || c == 'Q' || c == 'Y' || c == 'V'
            || c == 'G' || c == 'F' || c == 'J' || c == 'Z' || c == 'Ñ' || c == 'X' || c == 'K'
            || c == 'W';
    }
    
    private static bool Especial(char c)
    {
        return c == '@' || c == '#' || c == '_' || c == '-' || c == '\'' || c == '/' || c == '\\' 
            || c == '$' || c == '€' || c == '%' || c == ':';
    }

    private static bool Url(string s)
    {
        Uri uriResult;
        return Uri.TryCreate(s, UriKind.Absolute, out uriResult)
    && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
    }
    private bool Diptongo(int i)
    {
        //if (i == _cadena.Length-1 || !Vocal(_cadena[i + 1])) continue;
        //if (i > _cadena.Length - 2) { return false;}
        return VocalFuerte(_cadena[i]) && VocalDebil(_cadena[i + 1]) ||
               VocalDebil(_cadena[i]) && VocalDebil(_cadena[i + 1]) ||
               VocalDebil(_cadena[i]) && VocalFuerte(_cadena[i + 1]);
    }

    private bool Triptongo(int i)
    {
        if (i > _cadena.Length - 3) { return false; }
        return VocalDebil(_cadena[i]) && VocalFuerte(_cadena[i + 1]) && VocalDebil(_cadena[i + 2]);
    }

    private bool Hiato(int i)
    {
        //if (i == _cadena.Length-1 || !Vocal(_cadena[i + 1])) continue;
        //if (i > _cadena.Length - 2) { return false; }
        return VocalFuerte(_cadena[i]) && VocalFuerte(_cadena[i + 1]);
    }
}