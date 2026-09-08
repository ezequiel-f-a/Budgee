using System.ComponentModel;

namespace Enums
{
    /// <summary>
    /// Dias del mes. Posee del 1 al 28 y "Último", "Penúltimo" y "Antepenúltimo" para englobar los dias de todos los meses.
    /// </summary>
    public enum Dia_del_Mes
    {
        [Description("1")]
        Uno,
        [Description("2")]
        Dos,
        [Description("3")]
        Tres,
        [Description("4")]
        Cuatro,
        [Description("5")]
        Cinco,
        [Description("6")]
        Seis,
        [Description("7")]
        Siete,
        [Description("8")]
        Ocho,
        [Description("9")]
        Nueve,
        [Description("10")]
        Diez,
        [Description("11")]
        Once,
        [Description("12")]
        Doce,
        [Description("13")]
        Trece,
        [Description("14")]
        Catorce,
        [Description("15")]
        Quince,
        [Description("16")]
        Dieciseis,
        [Description("17")]
        Diecisiete,
        [Description("18")]
        Dieciocho,
        [Description("19")]
        Diecinueve,
        [Description("20")]
        Viente,
        [Description("21")]
        Veintiuno,
        [Description("22")]
        Veintidos,
        [Description("23")]
        Veintitres,
        [Description("24")]
        Veinticuatro,
        [Description("25")]
        Veinticinco,
        [Description("26")]
        Veintiséis,
        [Description("27")]
        Veintisiete,
        [Description("28")]
        Veintiocho,
        [Description("Antepenúltimo")]
        Antepenultimo,
        [Description("Penúltimo")]
        Penultimo,
        [Description("Último")]
        Ultimo
    }
}
