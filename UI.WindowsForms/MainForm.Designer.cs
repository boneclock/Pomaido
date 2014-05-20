namespace UI.WindowsForms
{
    partial class MainForm
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
            if (disposing && (components != null)) {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.CloseLabel = new System.Windows.Forms.Label();
            this.ChronoLabel = new System.Windows.Forms.Label();
            this.ChronoTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // CloseLabel
            // 
            this.CloseLabel.AutoSize = true;
            this.CloseLabel.BackColor = System.Drawing.Color.Transparent;
            this.CloseLabel.ForeColor = System.Drawing.Color.White;
            this.CloseLabel.Location = new System.Drawing.Point(276, 6);
            this.CloseLabel.Name = "CloseLabel";
            this.CloseLabel.Size = new System.Drawing.Size(15, 15);
            this.CloseLabel.TabIndex = 0;
            this.CloseLabel.Text = "X";
            this.CloseLabel.Click += new System.EventHandler(this.CloseLabel_Click);
            // 
            // ChronoLabel
            // 
            this.ChronoLabel.BackColor = System.Drawing.Color.Transparent;
            this.ChronoLabel.Font = new System.Drawing.Font("Meiryo UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChronoLabel.ForeColor = System.Drawing.Color.White;
            this.ChronoLabel.Location = new System.Drawing.Point(-1, 34);
            this.ChronoLabel.Name = "ChronoLabel";
            this.ChronoLabel.Size = new System.Drawing.Size(300, 46);
            this.ChronoLabel.TabIndex = 1;
            this.ChronoLabel.Text = "25:00";
            this.ChronoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ChronoTimer
            // 
            this.ChronoTimer.Interval = 1000;
            this.ChronoTimer.Tick += new System.EventHandler(this.ChronoTimer_Tick);
            // 
            // MainForm
            // 
            this.BackgroundImage = global::UI.WindowsForms.Properties.Resources.back;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(300, 261);
            this.Controls.Add(this.ChronoLabel);
            this.Controls.Add(this.CloseLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CloseLabel;
        private System.Windows.Forms.Label ChronoLabel;
        private System.Windows.Forms.Timer ChronoTimer;
    }
}

