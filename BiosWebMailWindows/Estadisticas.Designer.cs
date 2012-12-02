namespace BiosWebMailWindows
{
    partial class Estadisticas
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
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.gridEstadistica = new System.Windows.Forms.DataGridView();
            this.ColumnNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRecibidos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEnviados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridEstadistica)).BeginInit();
            this.SuspendLayout();
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(38, 238);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(0, 13);
            this.lblInfo.TabIndex = 1;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(23, 22);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(172, 20);
            this.lblHeader.TabIndex = 2;
            this.lblHeader.Text = "Estadistica Alumnos";
            // 
            // gridEstadistica
            // 
            this.gridEstadistica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridEstadistica.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnNombre,
            this.ColumnRecibidos,
            this.ColumnEnviados});
            this.gridEstadistica.Location = new System.Drawing.Point(27, 66);
            this.gridEstadistica.Name = "gridEstadistica";
            this.gridEstadistica.Size = new System.Drawing.Size(494, 150);
            this.gridEstadistica.TabIndex = 3;
            // 
            // ColumnNombre
            // 
            this.ColumnNombre.HeaderText = "Nombre Usuario";
            this.ColumnNombre.Name = "ColumnNombre";
            this.ColumnNombre.Width = 150;
            // 
            // ColumnRecibidos
            // 
            this.ColumnRecibidos.HeaderText = "Mails Recibidos";
            this.ColumnRecibidos.Name = "ColumnRecibidos";
            this.ColumnRecibidos.Width = 150;
            // 
            // ColumnEnviados
            // 
            this.ColumnEnviados.HeaderText = "Mails Enviados";
            this.ColumnEnviados.Name = "ColumnEnviados";
            this.ColumnEnviados.Width = 150;
            // 
            // Estadisticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 333);
            this.Controls.Add(this.gridEstadistica);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.lblInfo);
            this.Name = "Estadisticas";
            this.Text = "Estadisticas";
            this.Load += new System.EventHandler(this.Estadisticas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridEstadistica)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.DataGridView gridEstadistica;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRecibidos;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEnviados;


    }
}