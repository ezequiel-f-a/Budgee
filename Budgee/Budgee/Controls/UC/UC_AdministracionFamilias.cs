using SL.BLL.Contracts;
using SL.Domain.Security;
using SL.Services;
using SL.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using UI.Forms.SeleccionarElems;
using UI.Forms.Talonarios;

namespace UI.Controls.UC
{
    public partial class UC_AdministracionFamilias : UserControl
    {
        IGenericBusinessLogic<Familia> servicio = SL.BLL.Services.FamiliaService.Current;
        Talonario_Familia talonario = new Talonario_Familia();
        SeleccionarElem_Familia seleccionarFamilia;
        SeleccionarElem_Patente seleccionarPatente;
        List<Familia> list = new List<Familia>();
        Func<Familia, bool> filter = null;
        public UC_AdministracionFamilias()
        {
            InitializeComponent();
            BackColor = UI_Config.BackColor_Tab;
        }
        void RefreshListPoseedor()
        {
            try
            {
                list = servicio.GetAll().ToList();

                if (filter != null)
                    list = list.Where(filter).ToList();

                lbox_Poseedor.DataSource = list.Select(x => x.Nombre).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
        private void but_AgregarPoseedor_Click(object sender, EventArgs e)
        {
            try
            {
                talonario = new Talonario_Familia();
                if (talonario.ShowDialog() == DialogResult.OK)
                {
                    servicio.Add(talonario.ReturnedObject);
                    RefreshListPoseedor();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
        private void but_EliminarPoseedor_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbox_Poseedor.SelectedIndex == -1) return;

                talonario = new Talonario_Familia();

                if (MessageBox.Show("¿Está seguro que desea borrar el perfil?\nEsta acción no se puede revertir.".Translate(), "Advertencia".Translate(), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    servicio.Remove(list[lbox_Poseedor.SelectedIndex]);
                    RefreshListPoseedor();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
        private void but_ModificarPoseedor_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbox_Poseedor.SelectedIndex == -1) return;

                talonario = new Talonario_Familia();

                var temp_index = lbox_Poseedor.SelectedIndex;

                talonario.ReferenceObject = list[lbox_Poseedor.SelectedIndex];

                if (talonario.ShowDialog() == DialogResult.OK)
                {
                    servicio.Update(talonario.ReturnedObject);
                    RefreshListPoseedor();
                }

                lbox_Poseedor.SelectedIndex = temp_index;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
        private void but_AgregarFamilia_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbox_Poseedor.SelectedIndex == -1) return;

                var temp_index = lbox_Poseedor.SelectedIndex;

                var familias_excluidas = list[lbox_Poseedor.SelectedIndex].Privilegios.Where(x => x is Familia).Cast<Familia>().ToList();
                familias_excluidas.Add(list[lbox_Poseedor.SelectedIndex]);
                seleccionarFamilia = new SeleccionarElem_Familia(familias_excluidas);

                if (seleccionarFamilia.ShowDialog() == DialogResult.OK)
                {
                    list[lbox_Poseedor.SelectedIndex].Privilegios.Add(seleccionarFamilia.ReturnedObject);
                    servicio.Update(list[lbox_Poseedor.SelectedIndex]);
                    RefreshListPoseedor();
                }

                lbox_Poseedor.SelectedIndex = temp_index;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
        private void but_AgregarPatente_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbox_Poseedor.SelectedIndex == -1) return;

                var temp_index = lbox_Poseedor.SelectedIndex;

                seleccionarPatente = new SeleccionarElem_Patente(
                    list[lbox_Poseedor.SelectedIndex].Privilegios.Where(x => x is Patente).Cast<Patente>());

                if (seleccionarPatente.ShowDialog() == DialogResult.OK)
                {
                    list[lbox_Poseedor.SelectedIndex].Privilegios.Add(seleccionarPatente.ReturnedObject);
                    servicio.Update(list[lbox_Poseedor.SelectedIndex]);
                    RefreshListPoseedor();
                }

                lbox_Poseedor.SelectedIndex = temp_index;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
        private void but_EliminarComponente_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbox_Poseedor.SelectedIndex == -1) return;
                if (lbox_Componentes.SelectedIndex == -1) return;

                var temp_index = lbox_Poseedor.SelectedIndex;

                if (MessageBox.Show("¿Está seguro que desea remover el perfil/permiso del perfil?".Translate(), "Advertencia".Translate(), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    list[lbox_Poseedor.SelectedIndex].Privilegios.Remove(list[lbox_Poseedor.SelectedIndex].Privilegios[lbox_Componentes.SelectedIndex]);
                    servicio.Update(list[lbox_Poseedor.SelectedIndex]);
                    RefreshListPoseedor();
                }

                lbox_Poseedor.SelectedIndex = temp_index;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
        private void but_Buscar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_Nombre.Text))
                filter = x => x.Nombre.Contains(txt_Nombre.Text);
            else
                filter = null;

            RefreshListPoseedor();
        }
        private void lbox_Poseedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbox_Poseedor.SelectedIndex == -1)
            {
                lbox_Componentes.DataSource = null;
                return;
            }

            lbox_Componentes.DataSource = list[lbox_Poseedor.SelectedIndex].Privilegios.Select(x => x.Nombre).ToList();
            lbox_Componentes.SelectedIndex = -1;
        }
        private void UC_AdministracionFamilias_Load(object sender, EventArgs e)
        {
            RefreshListPoseedor();
            lbox_Poseedor.ClearSelected();
        }
    }
}
