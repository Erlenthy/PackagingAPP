namespace PackagingAPP
{
    partial class FileCompresser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileCompresser));
            this.przegladajButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.factLabel = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.generateFactButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // przegladajButton
            // 
            this.przegladajButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.przegladajButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(106)))), ((int)(((byte)(103)))));
            this.przegladajButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(200)))), ((int)(((byte)(196)))));
            this.przegladajButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.przegladajButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.przegladajButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(7)))), ((int)(((byte)(12)))));
            this.przegladajButton.Location = new System.Drawing.Point(12, 186);
            this.przegladajButton.Name = "przegladajButton";
            this.przegladajButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.przegladajButton.Size = new System.Drawing.Size(205, 72);
            this.przegladajButton.TabIndex = 0;
            this.przegladajButton.Text = "Compress to one archive";
            this.przegladajButton.UseVisualStyleBackColor = false;
            this.przegladajButton.Click += new System.EventHandler(this.przegladajButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // factLabel
            // 
            this.factLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.factLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.factLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(7)))), ((int)(((byte)(12)))));
            this.factLabel.Location = new System.Drawing.Point(92, 50);
            this.factLabel.Name = "factLabel";
            this.factLabel.Size = new System.Drawing.Size(290, 100);
            this.factLabel.TabIndex = 1;
            this.factLabel.Text = "Miło Cię widzieć :)";
            this.factLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.factLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(53, 325);
            this.progressBar1.Maximum = 10;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(372, 25);
            this.progressBar1.TabIndex = 2;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // generateFactButton
            // 
            this.generateFactButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.generateFactButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(106)))), ((int)(((byte)(103)))));
            this.generateFactButton.FlatAppearance.BorderSize = 0;
            this.generateFactButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.generateFactButton.Location = new System.Drawing.Point(181, 296);
            this.generateFactButton.Name = "generateFactButton";
            this.generateFactButton.Size = new System.Drawing.Size(116, 23);
            this.generateFactButton.TabIndex = 3;
            this.generateFactButton.Text = "New Random Fact";
            this.generateFactButton.UseVisualStyleBackColor = false;
            this.generateFactButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(106)))), ((int)(((byte)(103)))));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(200)))), ((int)(((byte)(196)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.button1.Location = new System.Drawing.Point(263, 186);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(205, 72);
            this.button1.TabIndex = 4;
            this.button1.Text = "Compress to separate archives";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // FileCompresser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(77)))), ((int)(((byte)(87)))));
            this.ClientSize = new System.Drawing.Size(480, 362);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.generateFactButton);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.factLabel);
            this.Controls.Add(this.przegladajButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FileCompresser";
            this.Text = "Ziplock";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button przegladajButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label factLabel;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button generateFactButton;
        private System.Windows.Forms.Button button1;
    }
}

