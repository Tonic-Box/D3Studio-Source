namespace D3Studio.ide
{
    partial class IDEBase
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
            this.IDETabControl = new System.Windows.Forms.TabControl();
            this.SuspendLayout();
            // 
            // IDETabControl
            // 
            this.IDETabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IDETabControl.Location = new System.Drawing.Point(0, 0);
            this.IDETabControl.Name = "IDETabControl";
            this.IDETabControl.SelectedIndex = 0;
            this.IDETabControl.Size = new System.Drawing.Size(1063, 683);
            this.IDETabControl.TabIndex = 0;
            // 
            // IDEBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.IDETabControl);
            this.Name = "IDEBase";
            this.Size = new System.Drawing.Size(1063, 683);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl IDETabControl;
    }
}
