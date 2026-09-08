using Domain;
using SL.Services;
using SL.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using UI.Controls.Buttons;
using UI.Controls.ComboBoxs;
using UI.Controls.Labels;
using UI.Forms.Talonarios;

namespace UI.Forms.SeleccionarElems
{
    public partial class SeleccionarElem_Planificacion : f_SeleccionarElem<Planificacion>
    {
        private Guid? ExceptObject { get; set; }
        public SeleccionarElem_Planificacion(IEnumerable<Planificacion> not_in = null, Guid? except = null) : base(not_in)
        {
            datasource_configuration = x => new
            {
                x.Descripcion,
                FrecuenciaInicio = (x.FrecuenciaInicio == null) ? null : SL.BLL.Services.FrecuenciaInicioService.Current.GetDescription(x.FrecuenciaInicio),
                x.Cuenta,
                x.Categoria,
                Etiquetas = String.Join(", ", x.Etiquetas),
                x.TipoOperacion,
                MontoExpresion = $"{x.MontoExpresion} {x.Cuenta.Divisa}",
                x.Habilitado
            };

            ExceptObject = except;

            InitializeComponent();
            this.Text = "Seleccionar Planificación";
            talonario = new Talonario_Planificacion();
            servicio = BLL.Services.PlanificacionService.Current;
        }
        protected override void RefreshList()
        {
            try
            {
                list = servicio.GetAll(x => x.Estado == true && x.Habilitado == true && x.Cuenta.Habilitada == true && x.Cuenta.Estado == true && x.Cuenta.Usuario.ID_Usuario == AppData.CurrentUser.ID_Usuario).ToList();
                list = list.Where(x => !not_in.Select(y => y.ID_Planificacion).Contains(x.ID_Planificacion)).ToList();
                if (ExceptObject != null) list = list.Where(x => x.ID_Planificacion != (Guid)ExceptObject).ToList();
                base.RefreshList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
        void SetupAll()
        {
            int WidthOffset = 0;
            int HeightOffset = 90;

            this.ClientSize = new Size(ClientSize.Width + WidthOffset, ClientSize.Height + HeightOffset);

            foreach (var control in Controls.Cast<Control>())
                control.Location = new Point(control.Location.X + WidthOffset / 2, control.Location.Y + HeightOffset);

            SetupFiltros(WidthOffset, HeightOffset);
        }
        void SetupFiltros(int WidthOffset, int HeightOffset)
        {
            int flow_Height = HeightOffset / 2;
            var flow_Filtros = new TableLayoutPanel() { Size = new Size(this.ClientSize.Width, flow_Height), Location = new Point(0, 0), ColumnCount = 4, RowCount = 2 };
            flow_Filtros.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            flow_Filtros.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            flow_Filtros.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            flow_Filtros.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            flow_Filtros.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            Controls.Add(flow_Filtros);

            var lbl_Cuenta = new DarkLabel() { Text = "Cuenta: ", Anchor = AnchorStyles.Right, Margin = new Padding(5, 5, 0, 5) };
            var combo_Cuenta = new DefaultComboBox() { DataSource = /*Pegar a BLL de cuentas*/new string[] { "Cuenta 1", "Cuenta 2" }, Anchor = AnchorStyles.None, Margin = new Padding(5), Size = new Size(200, 30) };
            combo_Cuenta.SelectedIndexChanged += Combo_Cuenta_SelectedIndexChanged;

            flow_Filtros.Controls.Add(lbl_Cuenta, 1, 0);
            flow_Filtros.Controls.Add(combo_Cuenta, 2, 0);

            var but_AplicarFiltros = new DarkButton() { Text = "Aplicar", Size = but_Seleccionar.Size, Location = new Point(but_Seleccionar.Location.X, flow_Filtros.Height + 10) };
            but_AplicarFiltros.Click += But_AplicarFiltros_Click;
            var but_ResetFiltros = new DarkButton() { Text = "Resetear", Size = but_Cancelar.Size, Location = new Point(but_Cancelar.Location.X, flow_Filtros.Height + 10) };
            but_ResetFiltros.Click += But_ResetFiltros_Click;
            Controls.Add(but_AplicarFiltros);
            Controls.Add(but_ResetFiltros);

            combo_Cuenta.SelectedIndex = -1;
        }
        private void But_ResetFiltros_Click(object sender, EventArgs e)
        {
        }
        private void But_AplicarFiltros_Click(object sender, EventArgs e)
        {
        }
        private void Combo_Cuenta_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void SeleccionarElem_Planificacion_Load(object sender, System.EventArgs e)
        {
            SetupAll();
        }
    }
}
