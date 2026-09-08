using BLL.Contracts;
using BLL.Services;
using Domain;
using SL.BLL.Contracts;
using SL.Services;
using SL.Services.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace UI.Controls.UC
{
    public partial class UC_Overview : UserControl
    {
        Estadistica_Overview estadistica;
        IEnumerable<Transaccion> transacciones;
        bool refreshing = false;
        public UC_Overview()
        {
            InitializeComponent();
            this.BackColor = UI_Config.BackColor_Tab;
            grid_Overview.BackgroundColor = UI_Config.BackColor_DarkBackground;
            CheckForIllegalCrossThreadCalls = false;
        }
        void GetEstadistica()
        {
            try
            {
                estadistica = EstadisticaOverviewService.Current.GetEstadistica();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
        void RefreshData()
        {
            try
            {
                transacciones = TransaccionService.Current.GetAll(x => x.Estado && x.Cuenta.Estado && x.Cuenta.Usuario.ID_Usuario == AppData.CurrentUser.ID_Usuario).ToList();
                new System.Threading.Thread(() => { RefreshBalanceGlobal(); }).Start();
                new System.Threading.Thread(() => { RefreshGrid(); }).Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
        void RefreshBalanceGlobal()
        {
            try
            {
                lbl_BalanceGlobal.Text = $"{"Balance Global".Translate()}: $ {UsuarioService.Current.GetBalanceGlobal(estadistica.Usuario, transacciones)}";
                lbl_BalanceGlobalPotencial.Text = $"{"Balance Global Potencial".Translate()}: $ {UsuarioService.Current.GetBalanceGlobalPotencial(estadistica.Usuario, transacciones)}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
        void RefreshGrid()
        {
            try
            {
                if (refreshing) return;

                refreshing = true;

                grid_Overview.DataSource = null;

                grid_Overview.DataSource = estadistica.Cuentas.Select(x => new {
                    x.Nombre,
                    Balance = $"{CuentaService.Current.GetBalance(x, transacciones)} {x.Divisa.GetDescription().Translate()}",
                    Balance_Potencial = $"{CuentaService.Current.GetBalancePotencial(x, transacciones)} {x.Divisa.GetDescription().Translate()}"
                }).ToList();

                grid_Overview.ClearSelection();

                grid_Overview.SetupLanguageForDataGridView();

                refreshing = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
        private void but_Exportar_Click(object sender, EventArgs e)
        {
            try
            {
                var sv = new SaveFileDialog()
                {
                    Title = "Guardar como".Translate(),
                    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    Filter =
                $"{"Libro de Excel".Translate()} (.xlsx) | *.xlsx|" +
                $"CSV | *.csv|" +
                $"PDF | *.pdf"
                };

                if (sv.ShowDialog() == DialogResult.OK)
                {
                    string path = sv.FileName;

                    string extension = Path.GetExtension(path);

                    var dt = ConversionService.DataGridView_ToDataTable(grid_Overview);

                    var headers = new string[] {
                    $"{"Fecha".Translate()}: {DateTime.Now}",
                    lbl_BalanceGlobal.Text,
                    lbl_BalanceGlobalPotencial.Text };

                    if (extension == ".xlsx") ConversionService.DataTable_to_XLSX_WithHeaders(dt, path, headers);

                    if (extension == ".csv") ConversionService.DataTable_to_CSV_WithHeaders(dt, path, headers);

                    if (extension == ".pdf") ConversionService.DataTable_to_PDF(dt, path,
                        title: "OVERVIEW".Translate(),
                        centered_title: true,
                        headers: headers,
                        centered_columns: true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
        private void UC_Overview_SizeChanged(object sender, EventArgs e)
        {
            grid_Overview.Size = new Size(grid_Overview.Width, ClientSize.Height - grid_Overview.Location.Y - 25);
        }
        private void UC_Overview_VisibleChanged(object sender, EventArgs e)
        {
            if (!Visible) return;
            if (estadistica == null) GetEstadistica();
            RefreshData();
        }
    }
}
