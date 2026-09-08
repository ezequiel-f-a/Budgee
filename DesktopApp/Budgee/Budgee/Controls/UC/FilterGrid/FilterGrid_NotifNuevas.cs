using SL.Services;
using SL.Services.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Controls.Buttons;

namespace UI.Controls.UC.FilterGrid
{
    public partial class FilterGrid_NotifNuevas : FilterGrid_Notificaciones
    {
        Button but_Visto, but_VistoTodos;
        public FilterGrid_NotifNuevas()
        {
            InitializeComponent();
            SetupAll();
        }
        protected override void RefreshList()
        {
            try
            {
                list = servicio.GetAll(x => x.Visto == false && x.Estado == true && x.Usuario.ID_Usuario == AppData.CurrentUser.ID_Usuario)
                    .OrderByDescending(x => x.FechaEmision)
                    .ThenBy(x => x.Informacion).ToList();

                base.RefreshList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
        void SetupAll()
        {
            but_Visto = new DarkButton() { Text = "Visto", Anchor = AnchorStyles.Right };
            but_Visto.Click += But_Visto_Click;
            flow_Buttons.Controls.Add(but_Visto, 2, 0);

            but_VistoTodos = new DarkButton() { Text = "Visto (Todos)", Anchor = AnchorStyles.Right };
            but_VistoTodos.Click += But_VistoTodos_Click;
            flow_Buttons.Controls.Add(but_VistoTodos, 3, 0);
        }
        private void But_Visto_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid_Main.SelectedCells.Count == 0)
                {
                    MessageBox.Show("No se seleccionó ningún elemento.".Translate());
                    return;
                }

                if (MessageBox.Show("¿Está seguro que desea marcar la notificación seleccionada como vista?\nEste proceso no es reversible.".Translate(), "Advertencia".Translate(), MessageBoxButtons.OKCancel) != DialogResult.OK) return;

                var notif = filtered_list[grid_Main.CurrentRow.Index];

                notif.Visto = true;

                servicio.Update(notif);

                new Thread(() => { Forms.f_Main.Current.UpdateNotificacionesCount(); }).Start();

                RefreshList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
        private void But_VistoTodos_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Está seguro que desea marcar todas las notificaciones como vistas?\nEste proceso no es reversible.".Translate(), "Advertencia".Translate(), MessageBoxButtons.OKCancel) != DialogResult.OK) return;

                foreach (var notif in filtered_list)
                {
                    notif.Visto = true;
                    servicio.Update(notif);
                }

                new Thread(() => { Forms.f_Main.Current.UpdateNotificacionesCount(); }).Start();

                RefreshList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
    }
}
