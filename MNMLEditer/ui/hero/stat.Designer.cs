namespace D3Studio.ui.hero
{
    partial class stat
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.statLabel = new System.Windows.Forms.Label();
            this.statValue = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statValue)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Controls.Add(this.statLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.statValue, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(638, 27);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // statLabel
            // 
            this.statLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.statLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statLabel.ForeColor = System.Drawing.Color.Black;
            this.statLabel.Location = new System.Drawing.Point(25, 2);
            this.statLabel.Name = "statLabel";
            this.statLabel.Size = new System.Drawing.Size(172, 23);
            this.statLabel.TabIndex = 0;
            this.statLabel.Text = "statLabel";
            this.statLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // statValue
            // 
            this.statValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statValue.Location = new System.Drawing.Point(203, 3);
            this.statValue.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.statValue.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.statValue.Name = "statValue";
            this.statValue.Size = new System.Drawing.Size(407, 20);
            this.statValue.TabIndex = 1;
            this.statValue.ValueChanged += new System.EventHandler(this.statValue_ValueChanged);
            this.statValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.statValue_KeyPress);
            this.statValue.KeyUp += new System.Windows.Forms.KeyEventHandler(this.statValue_KeyUp);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(616, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(19, 21);
            this.button1.TabIndex = 2;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // stat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "stat";
            this.Size = new System.Drawing.Size(638, 27);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.statValue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label statLabel;
        private System.Windows.Forms.NumericUpDown statValue;
        private System.Windows.Forms.Button button1;
    }
}
