namespace LetJetFlyOnLine
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnStartFlight = new System.Windows.Forms.Button();
            this.pnlAAgun = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(27, 54);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(153, 110);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnStartFlight
            // 
            this.btnStartFlight.Location = new System.Drawing.Point(135, 282);
            this.btnStartFlight.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnStartFlight.Name = "btnStartFlight";
            this.btnStartFlight.Size = new System.Drawing.Size(75, 33);
            this.btnStartFlight.TabIndex = 1;
            this.btnStartFlight.Text = "Start Flight";
            this.btnStartFlight.UseVisualStyleBackColor = true;
            this.btnStartFlight.Click += new System.EventHandler(this.btnStartFlight_Click);
            // 
            // pnlAAgun
            // 
            this.pnlAAgun.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlAAgun.BackgroundImage")));
            this.pnlAAgun.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlAAgun.Location = new System.Drawing.Point(977, 610);
            this.pnlAAgun.Name = "pnlAAgun";
            this.pnlAAgun.Size = new System.Drawing.Size(93, 68);
            this.pnlAAgun.TabIndex = 2;
            this.pnlAAgun.Click += new System.EventHandler(this.panel1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1082, 690);
            this.Controls.Add(this.pnlAAgun);
            this.Controls.Add(this.btnStartFlight);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnStartFlight;
        private System.Windows.Forms.Panel pnlAAgun;
    }
}

