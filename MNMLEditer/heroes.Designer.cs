namespace D3Studio
{
    partial class heroes
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
            this.heroesControl = new System.Windows.Forms.TabControl();
            this.SuspendLayout();
            // 
            // heroesControl
            // 
            this.heroesControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.heroesControl.Location = new System.Drawing.Point(0, 0);
            this.heroesControl.Name = "heroesControl";
            this.heroesControl.SelectedIndex = 0;
            this.heroesControl.Size = new System.Drawing.Size(844, 668);
            this.heroesControl.TabIndex = 0;
            // 
            // heroes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.heroesControl);
            this.Name = "heroes";
            this.Size = new System.Drawing.Size(844, 668);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TabControl heroesControl;
    }
}
