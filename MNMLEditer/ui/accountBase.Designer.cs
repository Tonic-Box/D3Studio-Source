namespace D3Studio.ui
{
    partial class accountBase
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
            this.generalTabControl = new System.Windows.Forms.TabControl();
            this.SuspendLayout();
            // 
            // generalTabControl
            // 
            this.generalTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.generalTabControl.Location = new System.Drawing.Point(0, 0);
            this.generalTabControl.Name = "generalTabControl";
            this.generalTabControl.SelectedIndex = 0;
            this.generalTabControl.Size = new System.Drawing.Size(880, 679);
            this.generalTabControl.TabIndex = 0;
            // 
            // generalBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.generalTabControl);
            this.Name = "generalBase";
            this.Size = new System.Drawing.Size(880, 679);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl generalTabControl;
    }
}
