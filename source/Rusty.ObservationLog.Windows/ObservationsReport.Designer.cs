namespace Rusty.ObservationLog.Windows
{
    partial class ObservationsReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gvObservations = new System.Windows.Forms.DataGridView();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ObservationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ObservationText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gvObservations)).BeginInit();
            this.SuspendLayout();
            // 
            // gvObservations
            // 
            this.gvObservations.AllowUserToAddRows = false;
            this.gvObservations.AllowUserToDeleteRows = false;
            this.gvObservations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvObservations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserName,
            this.ObservationDate,
            this.ObservationText});
            this.gvObservations.Location = new System.Drawing.Point(-1, 74);
            this.gvObservations.Name = "gvObservations";
            this.gvObservations.ReadOnly = true;
            this.gvObservations.Size = new System.Drawing.Size(1103, 397);
            this.gvObservations.TabIndex = 0;
            // 
            // UserName
            // 
            this.UserName.DataPropertyName = "UserName";
            this.UserName.HeaderText = "User Name";
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            this.UserName.Width = 200;
            // 
            // ObservationDate
            // 
            this.ObservationDate.DataPropertyName = "ObservationDate";
            this.ObservationDate.HeaderText = "Observation Date";
            this.ObservationDate.Name = "ObservationDate";
            this.ObservationDate.ReadOnly = true;
            this.ObservationDate.Width = 200;
            // 
            // ObservationText
            // 
            this.ObservationText.DataPropertyName = "ObservationText";
            this.ObservationText.HeaderText = "Observation Text";
            this.ObservationText.Name = "ObservationText";
            this.ObservationText.ReadOnly = true;
            this.ObservationText.Width = 600;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(125, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // ObservationsReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 468);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gvObservations);
            this.Name = "ObservationsReport";
            this.Text = "ObservationsReport";
            this.Load += new System.EventHandler(this.ObservationsReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvObservations)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gvObservations;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ObservationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ObservationText;
        private System.Windows.Forms.Label label1;
    }
}