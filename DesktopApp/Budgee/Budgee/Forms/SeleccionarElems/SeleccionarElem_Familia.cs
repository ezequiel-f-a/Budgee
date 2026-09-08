using SL.Domain.Security;
using SL.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using UI.Forms.Talonarios;

namespace UI.Forms.SeleccionarElems
{
    public partial class SeleccionarElem_Familia : f_SeleccionarElem<Familia>
    {
        public SeleccionarElem_Familia(IEnumerable<Familia> not_in = null) : base(not_in: not_in, tieneVerDetalle: false, tieneCrear: false)
        {
            InitializeComponent();
            this.Text = "Seleccionar Perfil";
            talonario = new Talonario_Familia();
            servicio = SL.BLL.Services.FamiliaService.Current;
        }
        protected override void RefreshList()
        {
            try
            {
                list = servicio.GetAll().ToList();
                list = list.Where(x => !not_in.Select(y => y.ID_Familia).Contains(x.ID_Familia)).ToList();
                base.RefreshList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
    }
}
