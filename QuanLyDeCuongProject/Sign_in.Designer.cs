namespace QuanLyDeCuongProject
{
    partial class Sign_in
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
            this.btSIGNIn = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ckHienMatKhau = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btSIGNIn
            // 
            this.btSIGNIn.BackColor = System.Drawing.Color.RoyalBlue;
            this.btSIGNIn.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btSIGNIn.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btSIGNIn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Cyan;
            this.btSIGNIn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btSIGNIn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btSIGNIn.ForeColor = System.Drawing.Color.White;
            this.btSIGNIn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btSIGNIn.Location = new System.Drawing.Point(227, 470);
            this.btSIGNIn.Name = "btSIGNIn";
            this.btSIGNIn.Size = new System.Drawing.Size(200, 80);
            this.btSIGNIn.TabIndex = 0;
            this.btSIGNIn.Text = "Đăng Nhập";
            this.btSIGNIn.UseVisualStyleBackColor = false;
            this.btSIGNIn.Click += new System.EventHandler(this.btSIGNIn_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.txtEmail.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtEmail.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtEmail.Location = new System.Drawing.Point(122, 245);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(416, 22);
            this.txtEmail.TabIndex = 1;
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtPassword.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtPassword.Location = new System.Drawing.Point(122, 355);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(15);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(416, 22);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(152, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(358, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "THÔNG TIN ĐĂNG NHẬP";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ckHienMatKhau
            // 
            this.ckHienMatKhau.AutoSize = true;
            this.ckHienMatKhau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ckHienMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.ckHienMatKhau.Location = new System.Drawing.Point(152, 410);
            this.ckHienMatKhau.Name = "ckHienMatKhau";
            this.ckHienMatKhau.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ckHienMatKhau.Size = new System.Drawing.Size(110, 20);
            this.ckHienMatKhau.TabIndex = 3;
            this.ckHienMatKhau.Text = "Hiện mật khẩu";
            this.ckHienMatKhau.UseVisualStyleBackColor = true;
            this.ckHienMatKhau.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Sign_in
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(668, 730);
            this.Controls.Add(this.ckHienMatKhau);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.btSIGNIn);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Sign_in";
            this.Padding = new System.Windows.Forms.Padding(10, 5, 5, 10);
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RightToLeftLayout = true;
            this.Text = "Sign_in";
            this.Load += new System.EventHandler(this.Sign_in_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btSIGNIn;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ckHienMatKhau;
    }
}