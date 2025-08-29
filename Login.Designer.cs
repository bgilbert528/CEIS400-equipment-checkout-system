using MySql.Data.MySqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CEIS400_ECS
{
    partial class Login
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxUN = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.maskedTextBoxPass = new System.Windows.Forms.MaskedTextBox();
            this.mySqlCommand1 = new MySqlConnector.MySqlCommand();
            this.employeeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // textBoxUN
            // 
            this.textBoxUN.Location = new System.Drawing.Point(120, 22);
            this.textBoxUN.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxUN.Name = "textBoxUN";
            this.textBoxUN.Size = new System.Drawing.Size(163, 22);
            this.textBoxUN.TabIndex = 2;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(151, 126);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(94, 29);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.button1_Click);
            // 
            // maskedTextBoxPass
            // 
            this.maskedTextBoxPass.Location = new System.Drawing.Point(120, 72);
            this.maskedTextBoxPass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.maskedTextBoxPass.Name = "maskedTextBoxPass";
            this.maskedTextBoxPass.PasswordChar = '*';
            this.maskedTextBoxPass.Size = new System.Drawing.Size(163, 22);
            this.maskedTextBoxPass.TabIndex = 5;
            // 
            // mySqlCommand1
            // 
            this.mySqlCommand1.CommandTimeout = 0;
            this.mySqlCommand1.Connection = null;
            this.mySqlCommand1.Transaction = null;
            this.mySqlCommand1.UpdatedRowSource = System.Data.UpdateRowSource.None;
            // 
            // employeeBindingSource
            // 
            this.employeeBindingSource.DataSource = typeof(CEIS400_ECS.Employee);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 180);
            this.Controls.Add(this.maskedTextBoxPass);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.textBoxUN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Login";
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        public TextBox textBoxUN;
        public Button btnLogin;
        public MaskedTextBox maskedTextBoxPass;
        private BindingSource employeeBindingSource;
        private MySqlConnector.MySqlCommand mySqlCommand1;
    }
}