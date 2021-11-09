namespace D3Studio.ui.account
{
    partial class rolloverItems
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
            this.rolloverTabs = new System.Windows.Forms.TabControl();
            this.SuspendLayout();
            // 
            // rolloverTabs
            // 
            this.rolloverTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rolloverTabs.Location = new System.Drawing.Point(0, 0);
            this.rolloverTabs.Name = "rolloverTabs";
            this.rolloverTabs.SelectedIndex = 0;
            this.rolloverTabs.Size = new System.Drawing.Size(910, 654);
            this.rolloverTabs.TabIndex = 0;
            // 
            // rolloverItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rolloverTabs);
            this.Name = "rolloverItems";
            this.Size = new System.Drawing.Size(910, 654);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl rolloverTabs;
    }
}
