using SL.Services;
using SL.Services.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Controls.UC.FilterGrid
{
    public partial class FilterGrid_NotifVistas : FilterGrid_Notificaciones
    {
        public FilterGrid_NotifVistas()
        {
            InitializeComponent();
        }
        protected override void RefreshList()
        {
            try
            {
                list = servicio.GetAll(x => x.Visto == true && x.Estado == true && x.Usuario.ID_Usuario == AppData.CurrentUser.ID_Usuario)
                    .OrderByDescending(x => x.FechaEmision)
                    .ThenBy(x => x.Informacion).ToList();

                base.RefreshList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
    }
}
