namespace Rusty.ObservationLog.WinForms
{
    partial class TagItemView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTag = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTag
            // 
            this.lblTag.AutoSize = true;
            this.lblTag.Location = new System.Drawing.Point(0, 4);
            this.lblTag.Name = "lblTag";
            this.lblTag.Size = new System.Drawing.Size(66, 13);
            this.lblTag.TabIndex = 0;
            this.lblTag.Text = "[TAG TEXT]";
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(127, -3);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(20, 20);
            this.btnRemove.TabIndex = 1;
            this.btnRemove.Text = "x";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // TagItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.lblTag);
            this.Name = "TagItemView";
            this.Size = new System.Drawing.Size(150, 20);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTag;
        private System.Windows.Forms.Button btnRemove;
    }
}
