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
    public partial class UC_AdministracionUsuarios : UserControl
    {
        IGenericBusinessLogic<Usuario> servicio = SL.BLL.Services.UsuarioService.Current;
        Talonario_Usuario talonario = new Talonario_Usuario();
        SeleccionarElem_Familia seleccionarFamilia;
        SeleccionarElem_Patente seleccionarPatente;
        List<Usuario> list = new List<Usuario>();
        Func<Usuario, bool> filter = null;
        public UC_AdministracionUsuarios()
        {
            InitializeComponent();
            BackColor = UI_Config.BackColor_Tab;
        }
        void RefreshListPoseedor()
        {
            try
            {
                list = servicio.GetAll(x => x.Estado == true).ToList();

                if (filter != null)
                    list = list.Where(filter).ToList();

                lbox_Poseedor.DataSource = list.Select(x => x.Username).ToList();
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
                talonario = new Talonario_Usuario();
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

                if (MessageBox.Show("¿Está seguro que desea borrar el usuario?\nEsta acción no se puede revertir.".Translate(), "Advertencia".Translate(), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    list[lbox_Poseedor.SelectedIndex].Estado = false;
                    servicio.Update(list[lbox_Poseedor.SelectedIndex]);
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

                talonario = new Talonario_Usuario();

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

                seleccionarFamilia = new SeleccionarElem_Familia(
                    list[lbox_Poseedor.SelectedIndex].Privilegios.Where(x => x is Familia).Cast<Familia>());

                if (seleccionarFamilia.ShowDialog() == DialogResult.OK)
                {
                    list[lbox_Poseedor.SelectedIndex].Privilegios.Add(seleccionarFamilia.ReturnedObject);
                    servicio.Update(list[lbox_Poseedor.SelectedIndex]);
                    RefreshListPoseedor();
                }

                lbox_Poseedor.SelectedIndex = temp_index;

                if (list[lbox_Poseedor.SelectedIndex].ID_Usuario == AppData.CurrentUser.ID_Usuario) SL.BLL.Services.UsuarioService.Current.SetPrivilegios(AppData.CurrentUser);
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

                if (list[lbox_Poseedor.SelectedIndex].ID_Usuario == AppData.CurrentUser.ID_Usuario) SL.BLL.Services.UsuarioService.Current.SetPrivilegios(AppData.CurrentUser);
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

                if (MessageBox.Show("¿Está seguro que desea remover el perfil/permiso del usuario?".Translate(), "Advertencia".Translate(), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    list[lbox_Poseedor.SelectedIndex].Privilegios.Remove(list[lbox_Poseedor.SelectedIndex].Privilegios[lbox_Componentes.SelectedIndex]);
                    servicio.Update(list[lbox_Poseedor.SelectedIndex]);
                    RefreshListPoseedor();
                }

                lbox_Poseedor.SelectedIndex = temp_index;

                if (list[lbox_Poseedor.SelectedIndex].ID_Usuario == AppData.CurrentUser.ID_Usuario) SL.BLL.Services.UsuarioService.Current.SetPrivilegios(AppData.CurrentUser);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
        private void but_Buscar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_Nombre.Text))
                filter = x => x.Username.Contains(txt_Nombre.Text);
            else
                filter = null;

            RefreshListPoseedor();
        }
        private void lbox_Poseedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lbox_Poseedor.SelectedIndex == -1)
                {
                    lbox_Componentes.DataSource = null;
                    return;
                }

                SL.BLL.Services.UsuarioService.Current.SetPrivilegios(list[lbox_Poseedor.SelectedIndex]);

                lbox_Componentes.DataSource = list[lbox_Poseedor.SelectedIndex].Privilegios.Select(x => x.Nombre).ToList();
                lbox_Componentes.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }
        }
        private void UC_AdministracionUsuarios_Load(object sender, EventArgs e)
        {
            RefreshListPoseedor();
            lbox_Poseedor.ClearSelected();
        }
    }
}