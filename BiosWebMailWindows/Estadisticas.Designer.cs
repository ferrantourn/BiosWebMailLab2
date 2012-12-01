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
            this.DREstadisticas = new Microsoft.VisualBasic.PowerPacks.DataRepeater();
            this.DREstadisticas.SuspendLayout();
            this.SuspendLayout();
            // 
            // DREstadisticas
            // 
            // 
            // DREstadisticas.ItemTemplate
            // 
            this.DREstadisticas.ItemTemplate.Size = new System.Drawing.Size(617, 100);
            this.DREstadisticas.Location = new System.Drawing.Point(12, 12);
            this.DREstadisticas.Name = "DREstadisticas";
            this.DREstadisticas.Size = new System.Drawing.Size(625, 309);
            this.DREstadisticas.TabIndex = 0;
            this.DREstadisticas.Text = "Estadisticas";
            // 
            // Estadisticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 333);
            this.Controls.Add(this.DREstadisticas);
            this.Name = "Estadisticas";
            this.Text = "Estadisticas";
            this.DREstadisticas.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.VisualBasic.PowerPacks.DataRepeater DREstadisticas;
    }
}