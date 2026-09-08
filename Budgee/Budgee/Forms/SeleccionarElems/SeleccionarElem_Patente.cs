using SL.Domain.Security;
using SL.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace UI.Forms.SeleccionarElems
{
    public partial class SeleccionarElem_Patente : f_SeleccionarElem<Patente>
    {
        public SeleccionarElem_Patente(IEnumerable<Patente> not_in = null) : base(not_in: not_in, tieneVerDetalle: false, tieneCrear: false)
        {
            InitializeComponent();
            this.Text = "Seleccionar Permiso";
            talonario = null; //NO SE PUEDE CREAR UNA PATENTE
            servicio = SL.BLL.Services.PatenteService.Current;
        }
        protected override void RefreshList()
        {
            try
            {
                list = servicio.GetAll().ToList();
                list = list.Where(x => !not_in.Select(y => y.ID_Patente).Contains(x.ID_Patente)).ToList();
                base.RefreshList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
    }
}
