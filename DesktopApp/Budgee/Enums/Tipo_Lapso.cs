using System.ComponentModel;

namespace Enums
{
    /// <summary>
    /// Lapsos de uso común. Adicionalmente la alternativa "Intervalo" para establecer un lapso entre dos fechas.
    /// </summary>
    public enum Tipo_Lapso
    {
        [Description("Histórico")]
        Historico,
        [Description("Este Año")]
        Este_Año,
        [Description("Este Semestre")]
        Este_Semestre,
        [Description("Este Cuatrimestre")]
        Este_Cuatrimestre,
        [Description("Este Trimestre")]
        Este_Trimestre,
        [Description("Este Mes")]
        Este_Mes,
        [Description("Esta Semana")]
        Esta_Semana,
        [Description("Este Día")]
        Este_Dia,
        [Description("Intervalo")]
        Intervalo
    }
}
