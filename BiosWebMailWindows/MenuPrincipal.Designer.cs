namespace BiosWebMailWindows
{
    partial class MenuPrincipal
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.alumnosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoAlumnosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alumnosSinMovimientosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estadisticasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.activarCuentaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.docentesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarDocenteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoDeDocentesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alumnosToolStripMenuItem,
            this.docentesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(532, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // alumnosToolStripMenuItem
            // 
            this.alumnosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listadoAlumnosToolStripMenuItem,
            this.alumnosSinMovimientosToolStripMenuItem,
            this.estadisticasToolStripMenuItem,
            this.activarCuentaToolStripMenuItem});
            this.alumnosToolStripMenuItem.Name = "alumnosToolStripMenuItem";
            this.alumnosToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.alumnosToolStripMenuItem.Text = "Alumnos";
            // 
            // listadoAlumnosToolStripMenuItem
            // 
            this.listadoAlumnosToolStripMenuItem.Name = "listadoAlumnosToolStripMenuItem";
            this.listadoAlumnosToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.listadoAlumnosToolStripMenuItem.Text = "Listado alumnos";
            this.listadoAlumnosToolStripMenuItem.Click += new System.EventHandler(this.listadoAlumnosToolStripMenuItem_Click);
            // 
            // alumnosSinMovimientosToolStripMenuItem
            // 
            this.alumnosSinMovimientosToolStripMenuItem.Name = "alumnosSinMovimientosToolStripMenuItem";
            this.alumnosSinMovimientosToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.alumnosSinMovimientosToolStripMenuItem.Text = "Alumnos sin movimientos";
            this.alumnosSinMovimientosToolStripMenuItem.Click += new System.EventHandler(this.alumnosSinMovimientosToolStripMenuItem_Click);
            // 
            // estadisticasToolStripMenuItem
            // 
            this.estadisticasToolStripMenuItem.Name = "estadisticasToolStripMenuItem";
            this.estadisticasToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.estadisticasToolStripMenuItem.Text = "Estadisticas";
            this.estadisticasToolStripMenuItem.Click += new System.EventHandler(this.estadisticasToolStripMenuItem_Click);
            // 
            // activarCuentaToolStripMenuItem
            // 
            this.activarCuentaToolStripMenuItem.Name = "activarCuentaToolStripMenuItem";
            this.activarCuentaToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.activarCuentaToolStripMenuItem.Text = "Activar Cuenta";
            this.activarCuentaToolStripMenuItem.Click += new System.EventHandler(this.activarCuentaToolStripMenuItem_Click);
            // 
            // docentesToolStripMenuItem
            // 
            this.docentesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registrarDocenteToolStripMenuItem,
            this.listadoDeDocentesToolStripMenuItem});
            this.docentesToolStripMenuItem.Name = "docentesToolStripMenuItem";
            this.docentesToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.docentesToolStripMenuItem.Text = "Docentes";
            // 
            // registrarDocenteToolStripMenuItem
            // 
            this.registrarDocenteToolStripMenuItem.Name = "registrarDocenteToolStripMenuItem";
            this.registrarDocenteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.registrarDocenteToolStripMenuItem.Text = "Registrar Docente";
            this.registrarDocenteToolStripMenuItem.Click += new System.EventHandler(this.registrarDocenteToolStripMenuItem_Click);
            // 
            // listadoDeDocentesToolStripMenuItem
            // 
            this.listadoDeDocentesToolStripMenuItem.Name = "listadoDeDocentesToolStripMenuItem";
            this.listadoDeDocentesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.listadoDeDocentesToolStripMenuItem.Text = "Listado de Docentes";
            this.listadoDeDocentesToolStripMenuItem.Click += new System.EventHandler(this.listadoDeDocentesToolStripMenuItem_Click);
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 259);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MenuPrincipal";
            this.Text = "Administracion Docente";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem alumnosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listadoAlumnosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alumnosSinMovimientosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estadisticasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem docentesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarDocenteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem activarCuentaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listadoDeDocentesToolStripMenuItem;
    }
}