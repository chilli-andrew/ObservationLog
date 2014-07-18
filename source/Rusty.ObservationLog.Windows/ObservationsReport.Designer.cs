namespace Rusty.ObservationLog.WinForms
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
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.btnToCsv = new System.Windows.Forms.Button();
            this.lblRowsCount = new System.Windows.Forms.Label();
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
            this.gvObservations.Size = new System.Drawing.Size(1103, 359);
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
            // dtFrom
            // 
            this.dtFrom.Location = new System.Drawing.Point(98, 12);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(200, 20);
            this.dtFrom.TabIndex = 1;
            // 
            // dtTo
            // 
            this.dtTo.Location = new System.Drawing.Point(98, 38);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(200, 20);
            this.dtTo.TabIndex = 2;
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(62, 18);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(30, 13);
            this.lblFrom.TabIndex = 3;
            this.lblFrom.Text = "From";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(62, 44);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(20, 13);
            this.lblTo.TabIndex = 4;
            this.lblTo.Text = "To";
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(319, 34);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 5;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // btnToCsv
            // 
            this.btnToCsv.Location = new System.Drawing.Point(980, 35);
            this.btnToCsv.Name = "btnToCsv";
            this.btnToCsv.Size = new System.Drawing.Size(99, 23);
            this.btnToCsv.TabIndex = 6;
            this.btnToCsv.Text = "Export To CSV";
            this.btnToCsv.UseVisualStyleBackColor = true;
            this.btnToCsv.Click += new System.EventHandler(this.btnToCsv_Click);
            // 
            // lblRowsCount
            // 
            this.lblRowsCount.AutoSize = true;
            this.lblRowsCount.Location = new System.Drawing.Point(998, 446);
            this.lblRowsCount.Name = "lblRowsCount";
            this.lblRowsCount.Size = new System.Drawing.Size(91, 13);
            this.lblRowsCount.TabIndex = 7;
            this.lblRowsCount.Text = "# Rows Returned";
            // 
            // ObservationsReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 468);
            this.Controls.Add(this.lblRowsCount);
            this.Controls.Add(this.btnToCsv);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.dtTo);
            this.Controls.Add(this.dtFrom);
            this.Controls.Add(this.gvObservations);
            this.Name = "ObservationsReport";
            this.Text = "ObservationsReport";
            ((System.ComponentModel.ISupportInitialize)(this.gvObservations)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gvObservations;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ObservationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ObservationText;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Button btnToCsv;
        private System.Windows.Forms.Label lblRowsCount;
    }
}