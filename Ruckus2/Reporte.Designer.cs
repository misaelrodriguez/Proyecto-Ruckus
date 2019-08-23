namespace Ruckus2
{
    partial class Reporte
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
            this.fechaI = new System.Windows.Forms.DateTimePicker();
            this.fechaF = new System.Windows.Forms.DateTimePicker();
            this.dgv_Registros = new System.Windows.Forms.DataGridView();
            this.btnConsulta = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Registros)).BeginInit();
            this.SuspendLayout();
            // 
            // fechaI
            // 
            this.fechaI.CalendarFont = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaI.Location = new System.Drawing.Point(105, 31);
            this.fechaI.Name = "fechaI";
            this.fechaI.Size = new System.Drawing.Size(200, 20);
            this.fechaI.TabIndex = 0;
            // 
            // fechaF
            // 
            this.fechaF.CalendarFont = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaF.Location = new System.Drawing.Point(544, 31);
            this.fechaF.Name = "fechaF";
            this.fechaF.Size = new System.Drawing.Size(200, 20);
            this.fechaF.TabIndex = 1;
            // 
            // dgv_Registros
            // 
            this.dgv_Registros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Registros.Location = new System.Drawing.Point(105, 160);
            this.dgv_Registros.Name = "dgv_Registros";
            this.dgv_Registros.Size = new System.Drawing.Size(639, 253);
            this.dgv_Registros.TabIndex = 2;
            // 
            // btnConsulta
            // 
            this.btnConsulta.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsulta.Location = new System.Drawing.Point(345, 88);
            this.btnConsulta.Name = "btnConsulta";
            this.btnConsulta.Size = new System.Drawing.Size(163, 38);
            this.btnConsulta.TabIndex = 3;
            this.btnConsulta.Text = "Consultar";
            this.btnConsulta.UseVisualStyleBackColor = true;
            this.btnConsulta.Click += new System.EventHandler(this.btnConsulta_Click);
            // 
            // Reporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 475);
            this.Controls.Add(this.btnConsulta);
            this.Controls.Add(this.dgv_Registros);
            this.Controls.Add(this.fechaF);
            this.Controls.Add(this.fechaI);
            this.Name = "Reporte";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Registros)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker fechaI;
        private System.Windows.Forms.DateTimePicker fechaF;
        private System.Windows.Forms.DataGridView dgv_Registros;
        private System.Windows.Forms.Button btnConsulta;
    }
}