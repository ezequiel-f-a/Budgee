
namespace UI.Forms.Talonarios
{
    partial class Talonario_Recordatorio
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txt_Descripcion = new UI.Controls.TextBoxs.DefaultTextBox();
            this.lbl_Descripcion = new UI.Controls.Labels.DarkLabel();
            this.but_FrecuenciaInicio = new UI.Controls.Buttons.DarkButton();
            this.txt_FrecuenciaInicio = new UI.Controls.TextBoxs.DefaultTextBox();
            this.lbl_FrecuenciaInicio = new UI.Controls.Labels.DarkLabel();
            this.check_QuitarAlConcluir = new UI.Controls.Labels.DarkCheckbox();
            this.check_NotificacionWindows = new UI.Controls.Labels.DarkCheckbox();
            this.check_AlarmaWindows = new UI.Controls.Labels.DarkCheckbox();
            this.lbl_LigadoAPlanificacion = new UI.Controls.Labels.DarkLabel();
            this.SuspendLayout();
            // 
            // but_Aceptar
            // 
            this.but_Aceptar.FlatAppearance.BorderSize = 0;
            this.but_Aceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(92)))), ((int)(((byte)(25)))));
            this.but_Aceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(75)))), ((int)(((byte)(13)))));
            this.but_Aceptar.Location = new System.Drawing.Point(67, 345);
            this.but_Aceptar.Click += new System.EventHandler(this.but_Aceptar_Click);
            // 
            // but_Cancelar
            // 
            this.but_Cancelar.FlatAppearance.BorderSize = 0;
            this.but_Cancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(92)))), ((int)(((byte)(25)))));
            this.but_Cancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(75)))), ((int)(((byte)(13)))));
            this.but_Cancelar.Location = new System.Drawing.Point(208, 345);
            // 
            // txt_Descripcion
            // 
            this.txt_Descripcion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_Descripcion.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Descripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Descripcion.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(120)))), ((int)(((byte)(58)))));
            this.txt_Descripcion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txt_Descripcion.Location = new System.Drawing.Point(27, 79);
            this.txt_Descripcion.MaxLength = 150;
            this.txt_Descripcion.Name = "txt_Descripcion";
            this.txt_Descripcion.Size = new System.Drawing.Size(342, 29);
            this.txt_Descripcion.TabIndex = 48;
            // 
            // lbl_Descripcion
            // 
            this.lbl_Descripcion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_Descripcion.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Descripcion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Descripcion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_Descripcion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_Descripcion.Location = new System.Drawing.Point(27, 47);
            this.lbl_Descripcion.Name = "lbl_Descripcion";
            this.lbl_Descripcion.Size = new System.Drawing.Size(342, 29);
            this.lbl_Descripcion.TabIndex = 47;
            this.lbl_Descripcion.Text = "Descripción:";
            this.lbl_Descripcion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // but_FrecuenciaInicio
            // 
            this.but_FrecuenciaInicio.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.but_FrecuenciaInicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.but_FrecuenciaInicio.FlatAppearance.BorderSize = 0;
            this.but_FrecuenciaInicio.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(92)))), ((int)(((byte)(25)))));
            this.but_FrecuenciaInicio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(75)))), ((int)(((byte)(13)))));
            this.but_FrecuenciaInicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.but_FrecuenciaInicio.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.but_FrecuenciaInicio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(138)))), ((int)(((byte)(79)))));
            this.but_FrecuenciaInicio.Location = new System.Drawing.Point(337, 153);
            this.but_FrecuenciaInicio.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.but_FrecuenciaInicio.Name = "but_FrecuenciaInicio";
            this.but_FrecuenciaInicio.Size = new System.Drawing.Size(32, 29);
            this.but_FrecuenciaInicio.TabIndex = 52;
            this.but_FrecuenciaInicio.Text = "...";
            this.but_FrecuenciaInicio.UseVisualStyleBackColor = false;
            this.but_FrecuenciaInicio.Click += new System.EventHandler(this.but_FrecuenciaInicio_Click);
            // 
            // txt_FrecuenciaInicio
            // 
            this.txt_FrecuenciaInicio.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_FrecuenciaInicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(120)))), ((int)(((byte)(58)))));
            this.txt_FrecuenciaInicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_FrecuenciaInicio.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(120)))), ((int)(((byte)(58)))));
            this.txt_FrecuenciaInicio.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txt_FrecuenciaInicio.Location = new System.Drawing.Point(27, 153);
            this.txt_FrecuenciaInicio.Name = "txt_FrecuenciaInicio";
            this.txt_FrecuenciaInicio.ReadOnly = true;
            this.txt_FrecuenciaInicio.Size = new System.Drawing.Size(311, 29);
            this.txt_FrecuenciaInicio.TabIndex = 51;
            // 
            // lbl_FrecuenciaInicio
            // 
            this.lbl_FrecuenciaInicio.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_FrecuenciaInicio.BackColor = System.Drawing.Color.Transparent;
            this.lbl_FrecuenciaInicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_FrecuenciaInicio.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_FrecuenciaInicio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_FrecuenciaInicio.Location = new System.Drawing.Point(90, 121);
            this.lbl_FrecuenciaInicio.Name = "lbl_FrecuenciaInicio";
            this.lbl_FrecuenciaInicio.Size = new System.Drawing.Size(216, 29);
            this.lbl_FrecuenciaInicio.TabIndex = 50;
            this.lbl_FrecuenciaInicio.Text = "Frecuencia e Inicio:";
            this.lbl_FrecuenciaInicio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // check_QuitarAlConcluir
            // 
            this.check_QuitarAlConcluir.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.check_QuitarAlConcluir.AutoSize = true;
            this.check_QuitarAlConcluir.BackColor = System.Drawing.Color.Transparent;
            this.check_QuitarAlConcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.check_QuitarAlConcluir.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_QuitarAlConcluir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.check_QuitarAlConcluir.Location = new System.Drawing.Point(31, 204);
            this.check_QuitarAlConcluir.Name = "check_QuitarAlConcluir";
            this.check_QuitarAlConcluir.Size = new System.Drawing.Size(160, 25);
            this.check_QuitarAlConcluir.TabIndex = 53;
            this.check_QuitarAlConcluir.Text = "Quitar al Concluir";
            this.check_QuitarAlConcluir.UseVisualStyleBackColor = false;
            // 
            // check_NotificacionWindows
            // 
            this.check_NotificacionWindows.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.check_NotificacionWindows.AutoSize = true;
            this.check_NotificacionWindows.BackColor = System.Drawing.Color.Transparent;
            this.check_NotificacionWindows.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.check_NotificacionWindows.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_NotificacionWindows.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.check_NotificacionWindows.Location = new System.Drawing.Point(31, 244);
            this.check_NotificacionWindows.Name = "check_NotificacionWindows";
            this.check_NotificacionWindows.Size = new System.Drawing.Size(301, 25);
            this.check_NotificacionWindows.TabIndex = 54;
            this.check_NotificacionWindows.Text = "Establecer Notificación de Windows";
            this.check_NotificacionWindows.UseVisualStyleBackColor = false;
            // 
            // check_AlarmaWindows
            // 
            this.check_AlarmaWindows.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.check_AlarmaWindows.AutoSize = true;
            this.check_AlarmaWindows.BackColor = System.Drawing.Color.Transparent;
            this.check_AlarmaWindows.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.check_AlarmaWindows.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_AlarmaWindows.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.check_AlarmaWindows.Location = new System.Drawing.Point(31, 284);
            this.check_AlarmaWindows.Name = "check_AlarmaWindows";
            this.check_AlarmaWindows.Size = new System.Drawing.Size(261, 25);
            this.check_AlarmaWindows.TabIndex = 55;
            this.check_AlarmaWindows.Text = "Establecer Alarma de Windows";
            this.check_AlarmaWindows.UseVisualStyleBackColor = false;
            // 
            // lbl_LigadoAPlanificacion
            // 
            this.lbl_LigadoAPlanificacion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_LigadoAPlanificacion.BackColor = System.Drawing.Color.Transparent;
            this.lbl_LigadoAPlanificacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_LigadoAPlanificacion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_LigadoAPlanificacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(61)))), ((int)(((byte)(8)))));
            this.lbl_LigadoAPlanificacion.Location = new System.Drawing.Point(-45, 9);
            this.lbl_LigadoAPlanificacion.Name = "lbl_LigadoAPlanificacion";
            this.lbl_LigadoAPlanificacion.Size = new System.Drawing.Size(488, 29);
            this.lbl_LigadoAPlanificacion.TabIndex = 49;
            this.lbl_LigadoAPlanificacion.Text = "Ligado a Planificación: N/A";
            this.lbl_LigadoAPlanificacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Talonario_Recordatorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 396);
            this.Controls.Add(this.check_AlarmaWindows);
            this.Controls.Add(this.check_NotificacionWindows);
            this.Controls.Add(this.check_QuitarAlConcluir);
            this.Controls.Add(this.but_FrecuenciaInicio);
            this.Controls.Add(this.txt_FrecuenciaInicio);
            this.Controls.Add(this.lbl_FrecuenciaInicio);
            this.Controls.Add(this.lbl_LigadoAPlanificacion);
            this.Controls.Add(this.txt_Descripcion);
            this.Controls.Add(this.lbl_Descripcion);
            this.Name = "Talonario_Recordatorio";
            this.Text = "Talonario_Recordatorios";
            this.Shown += new System.EventHandler(this.Talonario_Recordatorio_Shown);
            this.Controls.SetChildIndex(this.lbl_Descripcion, 0);
            this.Controls.SetChildIndex(this.txt_Descripcion, 0);
            this.Controls.SetChildIndex(this.lbl_LigadoAPlanificacion, 0);
            this.Controls.SetChildIndex(this.lbl_FrecuenciaInicio, 0);
            this.Controls.SetChildIndex(this.txt_FrecuenciaInicio, 0);
            this.Controls.SetChildIndex(this.but_FrecuenciaInicio, 0);
            this.Controls.SetChildIndex(this.check_QuitarAlConcluir, 0);
            this.Controls.SetChildIndex(this.check_NotificacionWindows, 0);
            this.Controls.SetChildIndex(this.check_AlarmaWindows, 0);
            this.Controls.SetChildIndex(this.but_Aceptar, 0);
            this.Controls.SetChildIndex(this.but_Cancelar, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.TextBoxs.DefaultTextBox txt_Descripcion;
        private Controls.Labels.DarkLabel lbl_Descripcion;
        private Controls.Buttons.DarkButton but_FrecuenciaInicio;
        private Controls.TextBoxs.DefaultTextBox txt_FrecuenciaInicio;
        private Controls.Labels.DarkLabel lbl_FrecuenciaInicio;
        private Controls.Labels.DarkCheckbox check_QuitarAlConcluir;
        private Controls.Labels.DarkCheckbox check_NotificacionWindows;
        private Controls.Labels.DarkCheckbox check_AlarmaWindows;
        private Controls.Labels.DarkLabel lbl_LigadoAPlanificacion;
    }
}