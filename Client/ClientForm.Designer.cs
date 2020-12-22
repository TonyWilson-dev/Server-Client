
namespace Client
{
    partial class ClientForm
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
            System.Windows.Forms.Button SubmitButton;
            this.InputField = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.MessageWindow = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.introLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.joinButton = new System.Windows.Forms.Button();
            this.nicknameTextBox = new System.Windows.Forms.TextBox();
            this.errorLabel = new System.Windows.Forms.Label();
            this.DMIntro = new System.Windows.Forms.Label();
            this.DMbutton = new System.Windows.Forms.Button();
            SubmitButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // SubmitButton
            // 
            SubmitButton.Dock = System.Windows.Forms.DockStyle.Fill;
            SubmitButton.Location = new System.Drawing.Point(636, 3);
            SubmitButton.Name = "SubmitButton";
            SubmitButton.Size = new System.Drawing.Size(75, 28);
            SubmitButton.TabIndex = 2;
            SubmitButton.Text = "Submit";
            SubmitButton.UseVisualStyleBackColor = true;
            SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // InputField
            // 
            this.InputField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InputField.Location = new System.Drawing.Point(3, 3);
            this.InputField.Name = "InputField";
            this.InputField.Size = new System.Drawing.Size(627, 26);
            this.InputField.TabIndex = 1;
            this.InputField.TextChanged += new System.EventHandler(this.InputField_TextChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(SubmitButton, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.InputField, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 528);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(714, 34);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // MessageWindow
            // 
            this.MessageWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MessageWindow.Location = new System.Drawing.Point(3, 3);
            this.MessageWindow.Multiline = true;
            this.MessageWindow.Name = "MessageWindow";
            this.MessageWindow.Size = new System.Drawing.Size(493, 522);
            this.MessageWindow.TabIndex = 0;
            this.MessageWindow.TextChanged += new System.EventHandler(this.MessageWindow_TextChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.MessageWindow, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(714, 528);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(502, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(209, 522);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.introLabel, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.errorLabel, 0, 2);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(203, 516);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // introLabel
            // 
            this.introLabel.AutoSize = true;
            this.introLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.introLabel.Location = new System.Drawing.Point(3, 0);
            this.introLabel.Name = "introLabel";
            this.introLabel.Size = new System.Drawing.Size(197, 154);
            this.introLabel.TabIndex = 0;
            this.introLabel.Text = "Please set a nickname";
            this.introLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.introLabel.Click += new System.EventHandler(this.introLabel_Click);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel5.Controls.Add(this.nicknameTextBox, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.joinButton, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.DMIntro, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.DMbutton, 0, 2);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 157);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 3;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.60606F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.84848F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(197, 148);
            this.tableLayoutPanel5.TabIndex = 1;
            this.tableLayoutPanel5.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel5_Paint);
            // 
            // joinButton
            // 
            this.joinButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.joinButton.Location = new System.Drawing.Point(140, 54);
            this.joinButton.Name = "joinButton";
            this.joinButton.Size = new System.Drawing.Size(54, 24);
            this.joinButton.TabIndex = 0;
            this.joinButton.Text = "Join";
            this.joinButton.UseVisualStyleBackColor = true;
            this.joinButton.Click += new System.EventHandler(this.joinButton_Click);
            // 
            // nicknameTextBox
            // 
            this.nicknameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nicknameTextBox.Location = new System.Drawing.Point(3, 54);
            this.nicknameTextBox.Name = "nicknameTextBox";
            this.nicknameTextBox.Size = new System.Drawing.Size(131, 26);
            this.nicknameTextBox.TabIndex = 1;
            this.nicknameTextBox.Text = "User";
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.errorLabel.Location = new System.Drawing.Point(3, 308);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(197, 208);
            this.errorLabel.TabIndex = 2;
            // 
            // DMIntro
            // 
            this.DMIntro.AutoSize = true;
            this.DMIntro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DMIntro.Location = new System.Drawing.Point(3, 0);
            this.DMIntro.Name = "DMIntro";
            this.DMIntro.Size = new System.Drawing.Size(131, 51);
            this.DMIntro.TabIndex = 2;
            this.DMIntro.Text = "DM destination";
            this.DMIntro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.DMIntro.Visible = false;
            this.DMIntro.Click += new System.EventHandler(this.label1_Click);
            // 
            // DMbutton
            // 
            this.DMbutton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DMbutton.Location = new System.Drawing.Point(3, 84);
            this.DMbutton.Name = "DMbutton";
            this.DMbutton.Size = new System.Drawing.Size(131, 61);
            this.DMbutton.TabIndex = 3;
            this.DMbutton.Text = "Send DM";
            this.DMbutton.UseVisualStyleBackColor = true;
            this.DMbutton.Visible = false;
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 562);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ClientForm";
            this.Text = "ClientForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox InputField;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox MessageWindow;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label introLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TextBox nicknameTextBox;
        private System.Windows.Forms.Button joinButton;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Label DMIntro;
        private System.Windows.Forms.Button DMbutton;
    }
}