﻿namespace Fall2020_CSC403_Project
{
    partial class FrmLevel1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLevel1));
            this.lblInGameTime = new System.Windows.Forms.Label();
            this.tmrUpdateInGameTime = new System.Windows.Forms.Timer(this.components);
            this.tmrPlayerMove = new System.Windows.Forms.Timer(this.components);
            this.picWall2 = new System.Windows.Forms.PictureBox();
            this.picWall8 = new System.Windows.Forms.PictureBox();
            this.picWall7 = new System.Windows.Forms.PictureBox();
            this.picWall1 = new System.Windows.Forms.PictureBox();
            this.picWall0 = new System.Windows.Forms.PictureBox();
            this.picWall10 = new System.Windows.Forms.PictureBox();
            this.picWall9 = new System.Windows.Forms.PictureBox();
            this.picWall6 = new System.Windows.Forms.PictureBox();
            this.picWall4 = new System.Windows.Forms.PictureBox();
            this.picWall5 = new System.Windows.Forms.PictureBox();
            this.batastropheSprite = new System.Windows.Forms.PictureBox();
            this.stalkerSprite = new System.Windows.Forms.PictureBox();
            this.picWall3 = new System.Windows.Forms.PictureBox();
            this.picPlayer = new System.Windows.Forms.PictureBox();
            this.Music_restarter = new System.Windows.Forms.Timer(this.components);
            this.Enemy_Movement = new System.Windows.Forms.Timer(this.components);
            this.picDoor = new System.Windows.Forms.PictureBox();
            this.picHealth = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picWall2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWall8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWall7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWall1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWall0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWall10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWall9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWall6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWall4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWall5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.batastropheSprite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stalkerSprite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWall3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDoor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHealth)).BeginInit();
            this.SuspendLayout();
            // 
            // lblInGameTime
            // 
            this.lblInGameTime.AutoSize = true;
            this.lblInGameTime.BackColor = System.Drawing.Color.Black;
            this.lblInGameTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInGameTime.ForeColor = System.Drawing.Color.White;
            this.lblInGameTime.Location = new System.Drawing.Point(16, 11);
            this.lblInGameTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInGameTime.Name = "lblInGameTime";
            this.lblInGameTime.Size = new System.Drawing.Size(60, 24);
            this.lblInGameTime.TabIndex = 2;
            this.lblInGameTime.Text = "label1";
            this.lblInGameTime.Click += new System.EventHandler(this.lblInGameTime_Click);
            // 
            // tmrUpdateInGameTime
            // 
            this.tmrUpdateInGameTime.Enabled = true;
            this.tmrUpdateInGameTime.Tick += new System.EventHandler(this.tmrUpdateInGameTime_Tick);
            // 
            // tmrPlayerMove
            // 
            this.tmrPlayerMove.Enabled = true;
            this.tmrPlayerMove.Interval = 10;
            this.tmrPlayerMove.Tick += new System.EventHandler(this.tmrPlayerMove_Tick);
            // 
            // picWall2
            // 
            this.picWall2.BackColor = System.Drawing.Color.Transparent;
            this.picWall2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picWall2.BackgroundImage")));
            this.picWall2.Location = new System.Drawing.Point(735, 1);
            this.picWall2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picWall2.Name = "picWall2";
            this.picWall2.Size = new System.Drawing.Size(840, 82);
            this.picWall2.TabIndex = 16;
            this.picWall2.TabStop = false;
            // 
            // picWall8
            // 
            this.picWall8.BackColor = System.Drawing.Color.Transparent;
            this.picWall8.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picWall8.BackgroundImage")));
            this.picWall8.Location = new System.Drawing.Point(1573, 1);
            this.picWall8.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picWall8.Name = "picWall8";
            this.picWall8.Size = new System.Drawing.Size(109, 906);
            this.picWall8.TabIndex = 15;
            this.picWall8.TabStop = false;
            // 
            // picWall7
            // 
            this.picWall7.BackColor = System.Drawing.Color.Transparent;
            this.picWall7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picWall7.BackgroundImage")));
            this.picWall7.Location = new System.Drawing.Point(952, 807);
            this.picWall7.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picWall7.Name = "picWall7";
            this.picWall7.Size = new System.Drawing.Size(623, 82);
            this.picWall7.TabIndex = 14;
            this.picWall7.TabStop = false;
            // 
            // picWall1
            // 
            this.picWall1.BackColor = System.Drawing.Color.Transparent;
            this.picWall1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picWall1.BackgroundImage")));
            this.picWall1.Location = new System.Drawing.Point(111, 1);
            this.picWall1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picWall1.Name = "picWall1";
            this.picWall1.Size = new System.Drawing.Size(625, 82);
            this.picWall1.TabIndex = 13;
            this.picWall1.TabStop = false;
            // 
            // picWall0
            // 
            this.picWall0.BackColor = System.Drawing.Color.Transparent;
            this.picWall0.BackgroundImage = global::Fall2020_CSC403_Project.Properties.Resources.Worlds_1;
            this.picWall0.Location = new System.Drawing.Point(3, 1);
            this.picWall0.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picWall0.Name = "picWall0";
            this.picWall0.Size = new System.Drawing.Size(109, 812);
            this.picWall0.TabIndex = 12;
            this.picWall0.TabStop = false;
            this.picWall0.Click += new System.EventHandler(this.picWall0_Click);
            // 
            // picWall10
            // 
            this.picWall10.BackColor = System.Drawing.Color.Transparent;
            this.picWall10.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picWall10.BackgroundImage")));
            this.picWall10.Location = new System.Drawing.Point(715, 242);
            this.picWall10.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picWall10.Name = "picWall10";
            this.picWall10.Size = new System.Drawing.Size(623, 74);
            this.picWall10.TabIndex = 11;
            this.picWall10.TabStop = false;
            this.picWall10.Click += new System.EventHandler(this.picWall10_Click);
            // 
            // picWall9
            // 
            this.picWall9.BackColor = System.Drawing.Color.Transparent;
            this.picWall9.BackgroundImage = global::Fall2020_CSC403_Project.Properties.Resources.Worlds_1;
            this.picWall9.Location = new System.Drawing.Point(347, 81);
            this.picWall9.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picWall9.Name = "picWall9";
            this.picWall9.Size = new System.Drawing.Size(88, 535);
            this.picWall9.TabIndex = 10;
            this.picWall9.TabStop = false;
            // 
            // picWall6
            // 
            this.picWall6.BackColor = System.Drawing.Color.Transparent;
            this.picWall6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picWall6.BackgroundImage")));
            this.picWall6.Location = new System.Drawing.Point(476, 807);
            this.picWall6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picWall6.Name = "picWall6";
            this.picWall6.Size = new System.Drawing.Size(477, 82);
            this.picWall6.TabIndex = 9;
            this.picWall6.TabStop = false;
            // 
            // picWall4
            // 
            this.picWall4.BackColor = System.Drawing.Color.Transparent;
            this.picWall4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picWall4.BackgroundImage")));
            this.picWall4.Location = new System.Drawing.Point(673, 498);
            this.picWall4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picWall4.Name = "picWall4";
            this.picWall4.Size = new System.Drawing.Size(109, 315);
            this.picWall4.TabIndex = 7;
            this.picWall4.TabStop = false;
            // 
            // picWall5
            // 
            this.picWall5.BackColor = System.Drawing.Color.Transparent;
            this.picWall5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picWall5.BackgroundImage")));
            this.picWall5.Location = new System.Drawing.Point(3, 807);
            this.picWall5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picWall5.Name = "picWall5";
            this.picWall5.Size = new System.Drawing.Size(477, 82);
            this.picWall5.TabIndex = 6;
            this.picWall5.TabStop = false;
            // 
            // batastropheSprite
            // 
            this.batastropheSprite.BackColor = System.Drawing.Color.Transparent;
            this.batastropheSprite.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.batastropheSprite.Image = global::Fall2020_CSC403_Project.Properties.Resources.spriteBat_negX;
            this.batastropheSprite.Location = new System.Drawing.Point(1307, 656);
            this.batastropheSprite.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.batastropheSprite.Name = "batastropheSprite";
            this.batastropheSprite.Size = new System.Drawing.Size(116, 126);
            this.batastropheSprite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.batastropheSprite.TabIndex = 5;
            this.batastropheSprite.TabStop = false;
            this.batastropheSprite.Click += new System.EventHandler(this.picEnemyCheeto_Click);
            // 
            // stalkerSprite
            // 
            this.stalkerSprite.BackColor = System.Drawing.Color.Transparent;
            this.stalkerSprite.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.stalkerSprite.Image = global::Fall2020_CSC403_Project.Properties.Resources.spriteSnail_negX;
            this.stalkerSprite.Location = new System.Drawing.Point(715, 352);
            this.stalkerSprite.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.stalkerSprite.Name = "stalkerSprite";
            this.stalkerSprite.Size = new System.Drawing.Size(109, 123);
            this.stalkerSprite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.stalkerSprite.TabIndex = 4;
            this.stalkerSprite.TabStop = false;
            this.stalkerSprite.Click += new System.EventHandler(this.picEnemyPoisonPacket_Click);
            // 
            // picWall3
            // 
            this.picWall3.BackColor = System.Drawing.Color.Transparent;
            this.picWall3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picWall3.BackgroundImage")));
            this.picWall3.Location = new System.Drawing.Point(1051, 524);
            this.picWall3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picWall3.Name = "picWall3";
            this.picWall3.Size = new System.Drawing.Size(524, 110);
            this.picWall3.TabIndex = 3;
            this.picWall3.TabStop = false;
            // 
            // picPlayer
            // 
            this.picPlayer.AccessibleName = "";
            this.picPlayer.BackColor = System.Drawing.Color.Transparent;
            this.picPlayer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picPlayer.Image = global::Fall2020_CSC403_Project.Properties.Resources.AM_D;
            this.picPlayer.Location = new System.Drawing.Point(188, 126);
            this.picPlayer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picPlayer.Name = "picPlayer";
            this.picPlayer.Size = new System.Drawing.Size(72, 130);
            this.picPlayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPlayer.TabIndex = 0;
            this.picPlayer.TabStop = false;
            this.picPlayer.Click += new System.EventHandler(this.picPlayer_Click);
            // 
            // Music_restarter
            // 
            this.Music_restarter.Enabled = true;
            this.Music_restarter.Interval = 86050;
            this.Music_restarter.Tick += new System.EventHandler(this.Music_restarter_Tick);
            // 
            // Enemy_Movement
            // 
            this.Enemy_Movement.Enabled = true;
            this.Enemy_Movement.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // picDoor
            // 
            this.picDoor.BackColor = System.Drawing.Color.Transparent;
            this.picDoor.BackgroundImage = global::Fall2020_CSC403_Project.Properties.Resources.Door;
            this.picDoor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picDoor.Location = new System.Drawing.Point(1447, 642);
            this.picDoor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picDoor.Name = "picDoor";
            this.picDoor.Size = new System.Drawing.Size(128, 166);
            this.picDoor.TabIndex = 17;
            this.picDoor.TabStop = false;
            // 
            // picHealth
            // 
            this.picHealth.BackColor = System.Drawing.Color.Transparent;
            this.picHealth.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picHealth.Image = global::Fall2020_CSC403_Project.Properties.Resources.Heart_Pickup;
            this.picHealth.Location = new System.Drawing.Point(952, 126);
            this.picHealth.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.picHealth.Name = "picHealth";
            this.picHealth.Size = new System.Drawing.Size(77, 80);
            this.picHealth.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picHealth.TabIndex = 18;
            this.picHealth.TabStop = false;
            // 
            // FrmLevel1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BackgroundImage = global::Fall2020_CSC403_Project.Properties.Resources.World_1_1;
            this.ClientSize = new System.Drawing.Size(1680, 890);
            this.Controls.Add(this.picHealth);
            this.Controls.Add(this.picDoor);
            this.Controls.Add(this.picWall2);
            this.Controls.Add(this.picWall8);
            this.Controls.Add(this.picWall7);
            this.Controls.Add(this.lblInGameTime);
            this.Controls.Add(this.picWall1);
            this.Controls.Add(this.picWall0);
            this.Controls.Add(this.picWall10);
            this.Controls.Add(this.picWall9);
            this.Controls.Add(this.picWall6);
            this.Controls.Add(this.picWall4);
            this.Controls.Add(this.picWall5);
            this.Controls.Add(this.batastropheSprite);
            this.Controls.Add(this.stalkerSprite);
            this.Controls.Add(this.picWall3);
            this.Controls.Add(this.picPlayer);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximumSize = new System.Drawing.Size(1698, 937);
            this.MinimumSize = new System.Drawing.Size(1698, 937);
            this.Name = "FrmLevel1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Fruits O\' The Round";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmLevel_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmLevel_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmLevel_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.picWall2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWall8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWall7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWall1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWall0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWall10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWall9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWall6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWall4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWall5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.batastropheSprite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stalkerSprite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWall3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDoor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHealth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picPlayer;
        private System.Windows.Forms.Label lblInGameTime;
        private System.Windows.Forms.Timer tmrUpdateInGameTime;
        private System.Windows.Forms.Timer tmrPlayerMove;
        private System.Windows.Forms.PictureBox picWall3;
        private System.Windows.Forms.PictureBox stalkerSprite;
        private System.Windows.Forms.PictureBox batastropheSprite;
        private System.Windows.Forms.PictureBox picWall5;
        private System.Windows.Forms.PictureBox picWall4;
        private System.Windows.Forms.PictureBox picWall6;
        private System.Windows.Forms.PictureBox picWall9;
        private System.Windows.Forms.PictureBox picWall10;
        private System.Windows.Forms.PictureBox picWall0;
        private System.Windows.Forms.PictureBox picWall7;
        private System.Windows.Forms.PictureBox picWall8;
        private System.Windows.Forms.PictureBox picWall1;
        private System.Windows.Forms.PictureBox picWall2;
        private System.Windows.Forms.Timer Music_restarter;
        private System.Windows.Forms.Timer Enemy_Movement;
        private System.Windows.Forms.PictureBox picDoor;
        private System.Windows.Forms.PictureBox picHealth;
    }
}

