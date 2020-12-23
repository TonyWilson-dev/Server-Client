
namespace gameClient
{
    partial class GameClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameClient));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.clientPlayer = new System.Windows.Forms.PictureBox();
            this.GameTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.clientPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 16;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // clientPlayer
            // 
            this.clientPlayer.Image = ((System.Drawing.Image)(resources.GetObject("clientPlayer.Image")));
            this.clientPlayer.Location = new System.Drawing.Point(62, 142);
            this.clientPlayer.Name = "clientPlayer";
            this.clientPlayer.Size = new System.Drawing.Size(103, 92);
            this.clientPlayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.clientPlayer.TabIndex = 0;
            this.clientPlayer.TabStop = false;
            // 
            // GameTitle
            // 
            this.GameTitle.AutoSize = true;
            this.GameTitle.Font = new System.Drawing.Font("Impact", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameTitle.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.GameTitle.Location = new System.Drawing.Point(246, 34);
            this.GameTitle.Name = "GameTitle";
            this.GameTitle.Size = new System.Drawing.Size(270, 35);
            this.GameTitle.TabIndex = 1;
            this.GameTitle.Text = "Peach\'s Big Adventure";
            // 
            // GameClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkBlue;
            this.ClientSize = new System.Drawing.Size(785, 537);
            this.Controls.Add(this.GameTitle);
            this.Controls.Add(this.clientPlayer);
            this.Name = "GameClient";
            this.Text = "Game";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameClient_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.clientPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox clientPlayer;
        private System.Windows.Forms.Label GameTitle;
    }
}

