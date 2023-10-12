namespace Ghoul_Shooter_Game
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.labelKills = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.progressHealthBar = new System.Windows.Forms.ProgressBar();
            this.pictureBoxPlayer = new System.Windows.Forms.PictureBox();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.labelAmmo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelKills
            // 
            this.labelKills.AutoSize = true;
            this.labelKills.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKills.ForeColor = System.Drawing.Color.White;
            this.labelKills.Location = new System.Drawing.Point(841, 12);
            this.labelKills.Name = "labelKills";
            this.labelKills.Size = new System.Drawing.Size(71, 24);
            this.labelKills.TabIndex = 1;
            this.labelKills.Text = "Kills: 0";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.ForeColor = System.Drawing.Color.White;
            this.label.Location = new System.Drawing.Point(12, 9);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(70, 24);
            this.label.TabIndex = 2;
            this.label.Text = "Health";
            // 
            // progressHealthBar
            // 
            this.progressHealthBar.Location = new System.Drawing.Point(88, 12);
            this.progressHealthBar.Name = "progressHealthBar";
            this.progressHealthBar.Size = new System.Drawing.Size(158, 23);
            this.progressHealthBar.TabIndex = 3;
            this.progressHealthBar.Value = 100;
            // 
            // pictureBoxPlayer
            // 
            this.pictureBoxPlayer.Image = global::Ghoul_Shooter_Game.Properties.Resources.top;
            this.pictureBoxPlayer.Location = new System.Drawing.Point(598, 530);
            this.pictureBoxPlayer.Name = "pictureBoxPlayer";
            this.pictureBoxPlayer.Size = new System.Drawing.Size(71, 108);
            this.pictureBoxPlayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxPlayer.TabIndex = 4;
            this.pictureBoxPlayer.TabStop = false;
            // 
            // Timer
            // 
            this.Timer.Enabled = true;
            this.Timer.Interval = 20;
            this.Timer.Tick += new System.EventHandler(this.GameLoad);
            // 
            // labelAmmo
            // 
            this.labelAmmo.AutoSize = true;
            this.labelAmmo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAmmo.ForeColor = System.Drawing.Color.White;
            this.labelAmmo.Location = new System.Drawing.Point(688, 11);
            this.labelAmmo.Name = "labelAmmo";
            this.labelAmmo.Size = new System.Drawing.Size(93, 24);
            this.labelAmmo.TabIndex = 5;
            this.labelAmmo.Text = "Ammo: 0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(345, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(229, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "OBJECTIVE : SURVIVE";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(823, 50);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(89, 54);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.ClientSize = new System.Drawing.Size(924, 661);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelAmmo);
            this.Controls.Add(this.pictureBoxPlayer);
            this.Controls.Add(this.progressHealthBar);
            this.Controls.Add(this.label);
            this.Controls.Add(this.labelKills);
            this.Name = "Form1";
            this.Text = "Ghoul Shooter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelKills;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.ProgressBar progressHealthBar;
        private System.Windows.Forms.PictureBox pictureBoxPlayer;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Label labelAmmo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

