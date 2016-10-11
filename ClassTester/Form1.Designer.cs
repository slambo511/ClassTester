namespace ClassTester
{
    partial class frmTestingFrontEnd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTestingFrontEnd));
            this.lblSoftwareDescription = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblSoftwareDescription
            // 
            this.lblSoftwareDescription.AutoSize = true;
            this.lblSoftwareDescription.Location = new System.Drawing.Point(12, 9);
            this.lblSoftwareDescription.Name = "lblSoftwareDescription";
            this.lblSoftwareDescription.Size = new System.Drawing.Size(128, 13);
            this.lblSoftwareDescription.TabIndex = 0;
            this.lblSoftwareDescription.Text = "Front end for class testing";
            // 
            // frmTestingFrontEnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.lblSoftwareDescription);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTestingFrontEnd";
            this.Text = "Class Tester";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSoftwareDescription;
    }
}

