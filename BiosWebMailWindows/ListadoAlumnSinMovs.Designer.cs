namespace BiosWebMailWindows
{
    partial class ListadoAlumnSinMovs
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
            this.components = new System.ComponentModel.Container();
            this.lblHeader = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumDias = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.UsersListRepeater = new System.Windows.Forms.DataGridView();
            this.lblInfo = new System.Windows.Forms.Label();
            this.errorProviderDias = new System.Windows.Forms.ErrorProvider(this.components);
            this.ColumnIdAlumno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDesactivar = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ColumnNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnApellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.UsersListRepeater)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderDias)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(13, 13);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(210, 20);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Alumnos sin movimientos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Dias sin movimientos";
            // 
            // txtNumDias
            // 
            this.txtNumDias.Location = new System.Drawing.Point(151, 49);
            this.txtNumDias.Name = "txtNumDias";
            this.txtNumDias.Size = new System.Drawing.Size(96, 20);
            this.txtNumDias.TabIndex = 2;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(262, 46);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // UsersListRepeater
            // 
            this.UsersListRepeater.AllowUserToAddRows = false;
            this.UsersListRepeater.AllowUserToDeleteRows = false;
            this.UsersListRepeater.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UsersListRepeater.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnIdAlumno,
            this.ColumnDesactivar,
            this.ColumnNombre,
            this.ColumnApellido,
            this.ColumnStatus});
            this.UsersListRepeater.Location = new System.Drawing.Point(151, 95);
            this.UsersListRepeater.Name = "UsersListRepeater";
            this.UsersListRepeater.Size = new System.Drawing.Size(444, 150);
            this.UsersListRepeater.TabIndex = 4;
            this.UsersListRepeater.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.UsersListRepeater_CellClick);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(17, 304);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(0, 13);
            this.lblInfo.TabIndex = 5;
            // 
            // errorProviderDias
            // 
            this.errorProviderDias.ContainerControl = this;
            // 
            // ColumnIdAlumno
            // 
            this.ColumnIdAlumno.HeaderText = "ColumnIdAlumno";
            this.ColumnIdAlumno.Name = "ColumnIdAlumno";
            this.ColumnIdAlumno.Visible = false;
            // 
            // ColumnDesactivar
            // 
            this.ColumnDesactivar.HeaderText = "Desactivar";
            this.ColumnDesactivar.Name = "ColumnDesactivar";
            // 
            // ColumnNombre
            // 
            this.ColumnNombre.HeaderText = "Nombre";
            this.ColumnNombre.Name = "ColumnNombre";
            // 
            // ColumnApellido
            // 
            this.ColumnApellido.HeaderText = "Apellido";
            this.ColumnApellido.Name = "ColumnApellido";
            // 
            // ColumnStatus
            // 
            this.ColumnStatus.HeaderText = "Estado";
            this.ColumnStatus.Name = "ColumnStatus";
            // 
            // ListadoAlumnSinMovs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 330);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.UsersListRepeater);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtNumDias);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblHeader);
            this.Name = "ListadoAlumnSinMovs";
            this.Text = "Listado";
            ((System.ComponentModel.ISupportInitialize)(this.UsersListRepeater)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderDias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumDias;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView UsersListRepeater;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.ErrorProvider errorProviderDias;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIdAlumno;
        private System.Windows.Forms.DataGridViewLinkColumn ColumnDesactivar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnApellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStatus;


    }
}