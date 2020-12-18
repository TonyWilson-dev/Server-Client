
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
            SubmitButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SubmitButton
            // 
            SubmitButton.Dock = System.Windows.Forms.DockStyle.Fill;
            SubmitButton.Location = new System.Drawing.Point(545, 3);
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
            this.InputField.Size = new System.Drawing.Size(536, 26);
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 491);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(623, 34);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // MessageWindow
            // 
            this.MessageWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MessageWindow.Location = new System.Drawing.Point(0, 0);
            this.MessageWindow.Multiline = true;
            this.MessageWindow.Name = "MessageWindow";
            this.MessageWindow.Size = new System.Drawing.Size(623, 525);
            this.MessageWindow.TabIndex = 0;
            this.MessageWindow.TextChanged += new System.EventHandler(this.MessageWindow_TextChanged);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 525);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.MessageWindow);
            this.Name = "ClientForm";
            this.Text = "ClientForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox InputField;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox MessageWindow;
    }
}