namespace ATEKELT_TERA1
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
            this.UsrNamTxtBx = new System.Windows.Forms.TextBox();
            this.PassTxtBx = new System.Windows.Forms.TextBox();
            this.LoginLbl = new System.Windows.Forms.Label();
            this.UsrNamLbl = new System.Windows.Forms.Label();
            this.PassLbl = new System.Windows.Forms.Label();
            this.LoginButtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.RollCombo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // UsrNamTxtBx
            // 
            this.UsrNamTxtBx.Location = new System.Drawing.Point(180, 141);
            this.UsrNamTxtBx.Margin = new System.Windows.Forms.Padding(2);
            this.UsrNamTxtBx.Name = "UsrNamTxtBx";
            this.UsrNamTxtBx.Size = new System.Drawing.Size(153, 20);
            this.UsrNamTxtBx.TabIndex = 0;
            this.UsrNamTxtBx.TextChanged += new System.EventHandler(this.UsrNamTxtBx_TextChanged);
            // 
            // PassTxtBx
            // 
            this.PassTxtBx.Location = new System.Drawing.Point(180, 206);
            this.PassTxtBx.Margin = new System.Windows.Forms.Padding(2);
            this.PassTxtBx.Name = "PassTxtBx";
            this.PassTxtBx.PasswordChar = '*';
            this.PassTxtBx.Size = new System.Drawing.Size(153, 20);
            this.PassTxtBx.TabIndex = 1;
            // 
            // LoginLbl
            // 
            this.LoginLbl.AutoSize = true;
            this.LoginLbl.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold);
            this.LoginLbl.Location = new System.Drawing.Point(247, 46);
            this.LoginLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LoginLbl.Name = "LoginLbl";
            this.LoginLbl.Size = new System.Drawing.Size(89, 37);
            this.LoginLbl.TabIndex = 2;
            this.LoginLbl.Text = "Login";
            // 
            // UsrNamLbl
            // 
            this.UsrNamLbl.AutoSize = true;
            this.UsrNamLbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.UsrNamLbl.Location = new System.Drawing.Point(44, 141);
            this.UsrNamLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.UsrNamLbl.Name = "UsrNamLbl";
            this.UsrNamLbl.Size = new System.Drawing.Size(60, 15);
            this.UsrNamLbl.TabIndex = 3;
            this.UsrNamLbl.Text = "Username";
            // 
            // PassLbl
            // 
            this.PassLbl.AutoSize = true;
            this.PassLbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.PassLbl.Location = new System.Drawing.Point(45, 210);
            this.PassLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PassLbl.Name = "PassLbl";
            this.PassLbl.Size = new System.Drawing.Size(57, 15);
            this.PassLbl.TabIndex = 4;
            this.PassLbl.Text = "Password";
            // 
            // LoginButtn
            // 
            this.LoginButtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LoginButtn.Location = new System.Drawing.Point(319, 358);
            this.LoginButtn.Margin = new System.Windows.Forms.Padding(2);
            this.LoginButtn.Name = "LoginButtn";
            this.LoginButtn.Size = new System.Drawing.Size(56, 24);
            this.LoginButtn.TabIndex = 5;
            this.LoginButtn.Text = "Login";
            this.LoginButtn.UseVisualStyleBackColor = true;
            this.LoginButtn.Click += new System.EventHandler(this.LoginButtn_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.button1.Location = new System.Drawing.Point(149, 358);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 24);
            this.button1.TabIndex = 6;
            this.button1.Text = "Sign Up";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.Location = new System.Drawing.Point(44, 270);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Roll";
            // 
            // RollCombo
            // 
            this.RollCombo.FormattingEnabled = true;
            this.RollCombo.Items.AddRange(new object[] {
            "ADMIN",
            "USER"});
            this.RollCombo.Location = new System.Drawing.Point(180, 270);
            this.RollCombo.Name = "RollCombo";
            this.RollCombo.Size = new System.Drawing.Size(153, 21);
            this.RollCombo.TabIndex = 8;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(600, 492);
            this.Controls.Add(this.RollCombo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.LoginButtn);
            this.Controls.Add(this.PassLbl);
            this.Controls.Add(this.UsrNamLbl);
            this.Controls.Add(this.LoginLbl);
            this.Controls.Add(this.PassTxtBx);
            this.Controls.Add(this.UsrNamTxtBx);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UsrNamTxtBx;
        private System.Windows.Forms.TextBox PassTxtBx;
        private System.Windows.Forms.Label LoginLbl;
        private System.Windows.Forms.Label UsrNamLbl;
        private System.Windows.Forms.Label PassLbl;
        private System.Windows.Forms.Button LoginButtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox RollCombo;
    }
}