using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using static System.Windows.Forms.Control;

namespace SL.Services
{
    /// <summary>
    /// Brinda una amplia gama de herramientas útiles para la gestión de UI.
    /// </summary>
    public static class UIManager
    {
        public static bool Check_TextOverflows(string text, Font font, int width)
        {
            return (TextRenderer.MeasureText(text, font).Width > width);
        }
        public static int Get_MaximumCharacters(string text, Font font, int width)
        {
            string temp_text = text;
            
            for(int i = text.Length; i > 0; i--)
            {
                if (Check_TextOverflows(temp_text, font, width))
                    temp_text = temp_text.Remove(i - 1);
                else break;
            }

            return temp_text.Length;
        }
        public static int Get_MinimumWidth(string text, Font font)
        {
            return TextRenderer.MeasureText(text, font).Width;
        }
        public static string Format_OverflowText(string text, Font font, int width, bool AgregarPuntosSuspensivos = true)
        {
            string temp_text = text;

            if (Check_TextOverflows(temp_text, font, width))
            {
                int max_chars = UIManager.Get_MaximumCharacters(temp_text, font, width);
                temp_text = temp_text.Remove(max_chars, (temp_text.Length - max_chars));

                if (AgregarPuntosSuspensivos)
                {
                    //Ahora le quito 3 para los puntitos
                    temp_text = temp_text.Remove(temp_text.Length - 3, 3);
                    temp_text += "...";
                }
            }

            return temp_text;
        }
        public static T Clone<T>(this T controlToClone) where T : Control
        {
            PropertyInfo[] controlProperties =
              typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            //T instance = Activator.CreateInstance<T>();
            Control instance = (Control)Activator.CreateInstance(controlToClone.GetType());

            foreach (PropertyInfo propInfo in controlProperties)
            {
                if (propInfo.CanWrite)
                {
                    if (propInfo.Name != "WindowTarget")
                        propInfo.SetValue(instance,
                                          propInfo.GetValue(controlToClone, null), null);
                }
            }

            foreach (Control ctl in controlToClone.Controls)
            {
                instance.Controls.Add(ctl.Clone());
            }
            return (T)instance;
        }
        public static void SetupLanguageForContainer(this ContainerControl container)
        {
            container.Text = container.Text.Translate();
            RecursiveSetter(container.Controls);
        }
        public static void SetupLanguageForDataGridView(this DataGridView grid)
        {
            foreach (var column in grid.Columns.Cast<DataGridViewColumn>())
                column.HeaderText = column.HeaderText.Translate();
        }
        public static bool Check_FilledFields(IEnumerable<Control> controls)
        {
            bool empty_fields = false;

            foreach (var control in controls.Where(x => x.Enabled == true))
            {
                if (control is TextBox && string.IsNullOrEmpty((control as TextBox).Text)) empty_fields = true;

                else if (control is ComboBox && (control as ComboBox).SelectedIndex == -1) empty_fields = true;
            }

            return !empty_fields;
        }
        static void RecursiveSetter(ControlCollection controls)
        {
            foreach (var control in controls.Cast<Control>())
            {
                control.Text = control.Text.Translate();

                if(control is TabControl)
                {
                    foreach (var item in (control as TabControl).TabPages.Cast<TabPage>())
                    {
                        item.Text = item.Text.Translate();
                    }
                }
                else if (control is MenuStrip)
                {
                    foreach (var item in (control as MenuStrip).Items.Cast<ToolStripItem>())
                    {
                        item.Text = item.Text.Translate();

                        if (item is ToolStripDropDownItem &&
                            (item as ToolStripDropDownItem).HasDropDownItems)
                        {
                            RecursiveSetter((item as ToolStripDropDownItem));
                        }
                    }
                }

                if (control.Controls.Count > 0)
                    RecursiveSetter(control.Controls);
            }
        }
        static void RecursiveSetter(ToolStripDropDownItem item)
        {
            foreach (var subItem in item.DropDownItems.Cast<ToolStripDropDownItem>())
            {
                subItem.Text = subItem.Text.Translate();

                if (subItem.HasDropDownItems)
                    RecursiveSetter(subItem);
            }
        }
    }
}
