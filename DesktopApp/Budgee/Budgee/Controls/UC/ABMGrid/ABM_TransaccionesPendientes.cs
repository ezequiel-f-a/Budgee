using SL.Services;
using SL.Services.Extensions;
using System;
using System.Linq;
using System.Windows.Forms;
using UI.Controls.Buttons;
using UI.Forms.Talonarios;

namespace UI.Controls.UC.ABMGrids
{
    public partial class ABM_TransaccionesPendientes : ABM_Transacciones
    {
        protected Button but_Concretar;
        public ABM_TransaccionesPendientes()
        {
            talonario = new Talonario_Transaccion(false);
            InitializeComponent();
            SetupAll();
        }
        protected override void RefreshList()
        {
            try
            {
                list = servicio.GetAll(x => x.Estado == true && x.Concretada == false && x.Cuenta.Habilitada == true && x.Cuenta.Estado == true && x.Cuenta.Usuario.ID_Usuario == AppData.CurrentUser.ID_Usuario).OrderByDescending(x => x.Fecha).ThenBy(x => x.Descripcion).ToList();
                base.RefreshList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
        void SetupAll()
        {
            but_Concretar = new DarkButton() { Text = "Concretar", Anchor = AnchorStyles.Right };
            but_Concretar.Click += but_Concretar_Click;
            flow_Buttons.Controls.Add(but_Concretar, 3, 0);
        }
        void but_Concretar_Click(object sender, EventArgs e)
        {
            if (grid_Main.SelectedCells.Count == 0)
            {
                MessageBox.Show("No se seleccionó ningún elemento.".Translate());
                return;
            }

            if (MessageBox.Show("¿Está seguro que desea concretar la transacción?".Translate(), "Advertencia".Translate(), MessageBoxButtons.OKCancel) != DialogResult.OK) return;

            var transaccion = filtered_list[grid_Main.CurrentRow.Index];

            if (transaccion.Fecha == null)
            {
                if (MessageBox.Show("La transacción no posee una fecha. ¿Desea establecer la fecha y hora actual para concretarla?".Translate(), "Advertencia".Translate(), MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    MessageBox.Show("Si desea concretar la transacción, deberá establecer su fecha desde el talonario de modificación respectivo.".Translate(), "Advertencia".Translate());
                    return;
                }
                else
                {
                    transaccion.Fecha = DateTime.Now;
                }
            }

            if(transaccion.Fecha > DateTime.Now)
            {
                if (MessageBox.Show("La transacción posee una fecha y hora superior a la actual. ¿Desea establecer la fecha y hora actual para concretarla?".Translate(), "Advertencia".Translate(), MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    MessageBox.Show("Si desea concretar la transacción, deberá establecer su fecha desde el talonario de modificación respectivo.".Translate(), "Advertencia".Translate());
                    return;
                }
                else
                {
                    transaccion.Fecha = DateTime.Now;
                }
            }

            try
            {
                (servicio as BLL.Services.TransaccionService).ConcretarTransaccion(transaccion);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
            
            RefreshList();
        }
    }
}
