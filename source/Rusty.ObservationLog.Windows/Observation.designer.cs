using Rusty.ObservationLog.Windows.ViewModels;

namespace Rusty.ObservationLog.Windows
{
    partial class Observation 
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
            this.txtObservation = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblCurrentUser = new System.Windows.Forms.Label();
            this.lblTags = new System.Windows.Forms.Label();
            this.btnAddTag = new System.Windows.Forms.Button();
            this.cboTags = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtObservation
            // 
            this.txtObservation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtObservation.Location = new System.Drawing.Point(3, 41);
            this.txtObservation.Multiline = true;
            this.txtObservation.Name = "txtObservation";
            this.txtObservation.Size = new System.Drawing.Size(446, 65);
            this.txtObservation.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.ForeColor = System.Drawing.Color.Navy;
            this.btnSave.Location = new System.Drawing.Point(327, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(59, 31);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.ForeColor = System.Drawing.Color.Navy;
            this.btnCancel.Location = new System.Drawing.Point(390, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(59, 31);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblCurrentUser
            // 
            this.lblCurrentUser.AutoSize = true;
            this.lblCurrentUser.Location = new System.Drawing.Point(12, 13);
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Size = new System.Drawing.Size(72, 13);
            this.lblCurrentUser.TabIndex = 3;
            this.lblCurrentUser.Text = "[Current User]";
            // 
            // lblTags
            // 
            this.lblTags.AutoSize = true;
            this.lblTags.Location = new System.Drawing.Point(0, 123);
            this.lblTags.Name = "lblTags";
            this.lblTags.Size = new System.Drawing.Size(34, 13);
            this.lblTags.TabIndex = 5;
            this.lblTags.Text = "Tags:";
            // 
            // btnAddTag
            // 
            this.btnAddTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddTag.Location = new System.Drawing.Point(168, 141);
            this.btnAddTag.Name = "btnAddTag";
            this.btnAddTag.Size = new System.Drawing.Size(27, 23);
            this.btnAddTag.TabIndex = 7;
            this.btnAddTag.Text = "+";
            this.btnAddTag.UseVisualStyleBackColor = true;
            // 
            // cboTags
            // 
            this.cboTags.FormattingEnabled = true;
            this.cboTags.Location = new System.Drawing.Point(3, 141);
            this.cboTags.Name = "cboTags";
            this.cboTags.Size = new System.Drawing.Size(159, 21);
            this.cboTags.TabIndex = 8;
            // 
            // Observation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(455, 168);
            this.ControlBox = false;
            this.Controls.Add(this.cboTags);
            this.Controls.Add(this.btnAddTag);
            this.Controls.Add(this.lblTags);
            this.Controls.Add(this.lblCurrentUser);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtObservation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimizeBox = false;
            this.Name = "Observation";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Observation";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Activated += new System.EventHandler(this.Observation_Activated);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtObservation;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblCurrentUser;
        private System.Windows.Forms.Label lblTags;
        private System.Windows.Forms.Button btnAddTag;
        private System.Windows.Forms.ComboBox cboTags;
    }
}