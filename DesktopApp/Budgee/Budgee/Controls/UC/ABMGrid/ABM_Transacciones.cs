using Domain;
using Enums;
using SL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace UI.Controls.UC.ABMGrids
{
    public partial class ABM_Transacciones : ABM_GenericTransacciones<Transaccion>
    {
        protected Label lbl_cuenta;
        protected ComboBox combo_Cuenta;
        protected List<Cuenta> CuentasDisponibles = new List<Cuenta>();

        public ABM_Transacciones()
        {
            datasource_configuration = x => new
            {
                x.Fecha,
                x.Descripcion,
                x.Cuenta,
                x.Categoria,
                Etiquetas = String.Join(", ", x.Etiquetas),
                TipoOperacion = (x.TipoOperacion != null) ? ((Tipo_Operacion)x.TipoOperacion).GetDescription().Translate() : null,
                MontoExpresion = $"{x.MontoExpresion} {x.Cuenta.Divisa.GetDescription().Translate()}",
            };

            servicio = BLL.Services.TransaccionService.Current;
            InitializeComponent();
            SetupAll();
        }

        void SetupAll()
        {
            lbl_cuenta = new Label() { Text = "Cuenta:" };
            combo_Cuenta = new ComboBox()
            {
                //DataSource = /*Pegar a BLL de cuentas*/ new string[] { "Cuenta 1", "Cuenta 2" },
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            combo_Cuenta.SelectedIndexChanged += Combo_Cuenta_SelectedIndexChanged;
            combo_Cuenta.DropDown += Combo_cuenta_DropDown;

            flow_Filtros.Controls.Add(lbl_cuenta, 4, 0);
            flow_Filtros.Controls.Add(combo_Cuenta, 5, 0);
        }
        protected override void RefreshList()
        {
            CuentasDisponibles = BLL.Services.CuentaService.Current.GetAll(x => list.Select(y => y.Cuenta.ID_Cuenta).Contains(x.ID_Cuenta)).ToList();
            base.RefreshList();
        }
        private void Combo_cuenta_DropDown(object sender, EventArgs e)
        {
            combo_Cuenta.SelectedIndexChanged -= Combo_Cuenta_SelectedIndexChanged;
            int index = combo_Cuenta.SelectedIndex;
            int count = combo_Cuenta.Items.Count;
            combo_Cuenta.DataSource = null;
            combo_Cuenta.DataSource = CuentasDisponibles.Select(x => x.Nombre).ToList();
            combo_Cuenta.SelectedIndex = -1;
            if (combo_Cuenta.Items.Count == count) combo_Cuenta.SelectedIndex = index;
            combo_Cuenta.SelectedIndexChanged += Combo_Cuenta_SelectedIndexChanged;
        }
        private void Combo_Cuenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_Cuenta.SelectedIndex == -1) return;

            var id = CuentasDisponibles[combo_Cuenta.SelectedIndex].ID_Cuenta;

            SetFilter(combo_Cuenta, x =>
            x.Cuenta.ID_Cuenta == id);
        }
    }
}
