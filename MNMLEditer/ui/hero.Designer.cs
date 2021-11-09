namespace D3Studio.ui
{
    partial class heroBase
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
            this.heroTabControl = new System.Windows.Forms.TabControl();
            this.SuspendLayout();
            // 
            // heroTabControl
            // 
            this.heroTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.heroTabControl.Location = new System.Drawing.Point(0, 0);
            this.heroTabControl.Name = "heroTabControl";
            this.heroTabControl.SelectedIndex = 0;
            this.heroTabControl.Size = new System.Drawing.Size(1037, 641);
            this.heroTabControl.TabIndex = 0;
            // 
            // hero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.heroTabControl);
            this.Name = "hero";
            this.Size = new System.Drawing.Size(1037, 641);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl heroTabControl;
    }
}
