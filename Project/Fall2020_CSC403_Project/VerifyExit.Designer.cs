
namespace Fall2020_CSC403_Project
{
    partial class VerifyExit
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VerifyExit));
            this.YesButton = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.NoButton = new System.Windows.Forms.Button();
            this.YouSure = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // YesButton
            // 
            this.YesButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.YesButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.YesButton.BackColor = System.Drawing.Color.Maroon;
            this.YesButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YesButton.ForeColor = System.Drawing.SystemColors.Control;
            this.YesButton.Location = new System.Drawing.Point(108, 324);
            this.YesButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.YesButton.Name = "YesButton";
            this.YesButton.Size = new System.Drawing.Size(316, 89);
            this.YesButton.TabIndex = 0;
            this.YesButton.Text = "YES";
            this.YesButton.UseVisualStyleBackColor = false;
            this.YesButton.Click += new System.EventHandler(this.YesButton_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Fruits_Of_The_Round_Title_Animation.gif");
            // 
            // NoButton
            // 
            this.NoButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NoButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.NoButton.BackColor = System.Drawing.Color.Maroon;
            this.NoButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoButton.ForeColor = System.Drawing.SystemColors.Control;
            this.NoButton.Location = new System.Drawing.Point(617, 324);
            this.NoButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.NoButton.Name = "NoButton";
            this.NoButton.Size = new System.Drawing.Size(307, 89);
            this.NoButton.TabIndex = 1;
            this.NoButton.Text = "NO";
            this.NoButton.UseVisualStyleBackColor = false;
            this.NoButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // YouSure
            // 
            this.YouSure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.YouSure.BackColor = System.Drawing.Color.Maroon;
            this.YouSure.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.YouSure.Font = new System.Drawing.Font("Times New Roman", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YouSure.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.YouSure.Location = new System.Drawing.Point(129, 117);
            this.YouSure.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.YouSure.Multiline = true;
            this.YouSure.Name = "YouSure";
            this.YouSure.Size = new System.Drawing.Size(781, 159);
            this.YouSure.TabIndex = 2;
            this.YouSure.Text = "ARE YOU SURE YOU WOULD LIKE TO EXIT?";
            this.YouSure.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // VerifyExit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Maroon;
            this.BackgroundImage = global::Fall2020_CSC403_Project.Properties.Resources.World_1;
            this.ClientSize = new System.Drawing.Size(1093, 554);
            this.Controls.Add(this.YouSure);
            this.Controls.Add(this.NoButton);
            this.Controls.Add(this.YesButton);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "VerifyExit";
            this.Text = "EXIT";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button YesButton;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button NoButton;
        private System.Windows.Forms.TextBox YouSure;
    }
}