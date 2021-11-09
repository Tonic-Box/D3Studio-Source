namespace D3Studio.ui.account
{
    partial class stashes
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
            this.stashTabs = new System.Windows.Forms.TabControl();
            this.SuspendLayout();
            // 
            // stashTabs
            // 
            this.stashTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stashTabs.Location = new System.Drawing.Point(0, 0);
            this.stashTabs.Name = "stashTabs";
            this.stashTabs.SelectedIndex = 0;
            this.stashTabs.Size = new System.Drawing.Size(899, 683);
            this.stashTabs.TabIndex = 0;
            // 
            // stashes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.stashTabs);
            this.Name = "stashes";
            this.Size = new System.Drawing.Size(899, 683);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl stashTabs;
    }
}
