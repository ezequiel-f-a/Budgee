using Domain;
using Enums;
using SL.Services;
using SL.Services.Extensions;
using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using UI.Controls.Buttons;
using UI.Controls.UC.Filterable;
using UI.Controls.UC.MenuTab;
using UI.Forms;
using UI.Forms.Talonarios;

namespace UI.Controls.UC.FilterGrid
{
    public partial class FilterGrid_Notificaciones : Filterable_FilterGrid<Notificacion>
    {
        protected Button but_Ir, but_Eliminar;
        protected TextBox txt_Informacion;
        protected ComboBox combo_Procedencia;
        public FilterGrid_Notificaciones() : base(true)
        {
            datasource_configuration = x => new
            {
                x.Informacion,
                x.FechaEmision,
                Procedencia = GetProcedencia(x)
            };

            servicio = BLL.Services.NotificacionService.Current;
            InitializeComponent();
            SetupAll();
        }
        protected override void RefreshList()
        {
            base.RefreshList();
        }
        void SetupAll()
        {
            SetupFilters();
            SetupButtons();
        }
        void SetupFilters()
        {
            var lbl_Informacion = new Label() { Text = "Información:" };
            txt_Informacion = new TextBox();
            txt_Informacion.TextChanged += Txt_Informacion_TextChanged;

            var lbl_Procedencia = new Label() { Text = "Procedencia:" };
            combo_Procedencia = new ComboBox()
            {
                DataSource = new Procedencia_Notificacion().GetDescriptions().Translate().ToList(),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            combo_Procedencia.SelectedIndexChanged += Combo_Procedencia_SelectedIndexChanged;

            //var lbl_Visto = new Label() { Text = "Visto:" };
            //var combo_Visto = new ComboBox()
            //{
            //    DataSource = new string[] { "No", "Sí" },
            //    DropDownStyle = ComboBoxStyle.DropDownList
            //};
            //combo_Visto.SelectedIndexChanged += Combo_Visto_SelectedIndexChanged;

            flow_Filtros.Controls.Add(lbl_Informacion, 0, 1);
            flow_Filtros.Controls.Add(txt_Informacion, 1, 1);
            flow_Filtros.Controls.Add(lbl_Procedencia, 2, 1);
            flow_Filtros.Controls.Add(combo_Procedencia, 3, 1);
            //flow_Filtros.Controls.Add(lbl_Visto, 4, 1);
            //flow_Filtros.Controls.Add(combo_Visto, 5, 1);
        }
        void SetupButtons()
        {
            but_Ir = new DarkButton() { Text = "Ir" };
            but_Ir.Click += But_Ir_Click;

            but_Eliminar = new DarkButton() { Text = "Eliminar" };
            but_Eliminar.Click += But_Eliminar_Click;

            flow_Buttons.Controls.Add(but_Ir, 0, 0);
            flow_Buttons.Controls.Add(but_Eliminar, 1, 0);
        }
        string GetProcedencia(Notificacion notif)
        {
            string tipo_estadistica = "";
            if (notif.Procedencia == Procedencia_Notificacion.Estadistica)
                tipo_estadistica = $" ({((Tipo_Estadistica)notif.Estadistica).GetDescription().Translate()})";

            return $"{notif.Procedencia.GetDescription().Translate()}{tipo_estadistica}";
        }

        private void But_Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid_Main.SelectedRows.Count == 0) return;

                var dialogResult = MessageBox.Show("¿Está seguro que desea eliminar el elemento seleccionado?".Translate(), "Advertencia".Translate(), MessageBoxButtons.OKCancel);

                if (dialogResult != DialogResult.OK) return;

                (filtered_list[grid_Main.CurrentRow.Index] as dynamic).Estado = false;

                try
                {
                    servicio.Update(filtered_list[grid_Main.CurrentRow.Index]);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.GetFullMessage());
                }

                RefreshList();

                new Thread(() => { Forms.f_Main.Current.UpdateNotificacionesCount(); }).Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
        private void But_Ir_Click(object sender, EventArgs e)
        {
            if (grid_Main.SelectedRows.Count == 0) return;

            var elem = filtered_list[grid_Main.CurrentRow.Index];

            switch (elem.Procedencia)
            {
                case Procedencia_Notificacion.Presupuesto:
                    if(elem.Presupuesto.Estado == false)
                    {
                        MessageBox.Show("El presupuesto que desea ver ya no existe.");
                        return;
                    }
                    f_Main.Current.SetTab(new MenuTab_Presupuestos());
                    new Talonario_Presupuesto() { ReferenceObject = elem.Presupuesto, ViewOnly = true }.ShowDialog();
                    break;
                case Procedencia_Notificacion.Recordatorio:
                    if (elem.Recordatorio.Estado == false)
                    {
                        MessageBox.Show("El recordatorio que desea ver ya no existe.");
                        return;
                    }
                    f_Main.Current.SetTab(new MenuTab_Recordatorios());
                    new Talonario_Recordatorio() { ReferenceObject = elem.Recordatorio, ViewOnly = true }.ShowDialog();
                    break;
                case Procedencia_Notificacion.Estadistica:
                    f_Main.Current.SetTab(new MenuTab_Estadisticas() { CurrentTab = (Tipo_Estadistica)elem.Estadistica});
                    break;
            }
        }
        private void Txt_Informacion_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_Informacion.Text))
            {
                RemoveFilter(txt_Informacion);
                return;
            }

            var txt = txt_Informacion.Text.Normalize().ToLower();

            SetFilter(txt_Informacion, x =>
            x.Informacion.Normalize().ToLower().Contains(txt));
        }
        private void Combo_Procedencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_Procedencia.SelectedIndex == -1) return;

            var enumValue = EnumHelper.GetEnumFromIndex<Procedencia_Notificacion>(combo_Procedencia.SelectedIndex);

            SetFilter(combo_Procedencia, x =>
            x.Procedencia == enumValue);
        }
    }
}
