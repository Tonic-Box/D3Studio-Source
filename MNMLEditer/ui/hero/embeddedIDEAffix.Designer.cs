namespace D3Studio.ui.hero.inventoryControls
{
    partial class embeddedIDEAffix
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(embeddedIDEAffix));
            this.ide = new D3Studio.ide.IDEAffix();
            this.SuspendLayout();
            // 
            // ide
            // 
            this.ide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ide.Location = new System.Drawing.Point(0, 0);
            this.ide.Name = "ide";
            this.ide.Size = new System.Drawing.Size(800, 143);
            this.ide.TabIndex = 0;
            // 
            // embeddedIDEAffix
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 143);
            this.Controls.Add(this.ide);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "embeddedIDEAffix";
            this.Text = "Edit Affix";
            this.ResumeLayout(false);

        }

        #endregion

        private ide.IDEAffix ide;
    }
}