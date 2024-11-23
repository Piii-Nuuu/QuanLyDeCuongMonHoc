namespace QuanLyDeCuongProject
{
    partial class DangNhap
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
            this.grB = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grB.SuspendLayout();
            this.SuspendLayout();
            // 
            // btSIGNIn
            // 
            this.btSIGNIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btSIGNIn.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btSIGNIn.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btSIGNIn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Cyan;
            this.btSIGNIn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btSIGNIn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btSIGNIn.ForeColor = System.Drawing.Color.White;
            this.btSIGNIn.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btSIGNIn.Location = new System.Drawing.Point(161, 382);
            this.btSIGNIn.Margin = new System.Windows.Forms.Padding(2);
            this.btSIGNIn.Name = "btSIGNIn";
            this.btSIGNIn.Size = new System.Drawing.Size(161, 50);
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
            this.txtEmail.Location = new System.Drawing.Point(92, 199);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(278, 19);
            this.txtEmail.TabIndex = 1;
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtPassword.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtPassword.Location = new System.Drawing.Point(92, 288);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(11, 12, 11, 12);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(278, 19);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(110, 99);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "THÔNG TIN ĐĂNG NHẬP";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ckHienMatKhau
            // 
            this.ckHienMatKhau.AutoSize = true;
            this.ckHienMatKhau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ckHienMatKhau.Font = new System.Drawing.Font("Tahoma", 7.8F);
            this.ckHienMatKhau.Location = new System.Drawing.Point(114, 333);
            this.ckHienMatKhau.Margin = new System.Windows.Forms.Padding(2);
            this.ckHienMatKhau.Name = "ckHienMatKhau";
            this.ckHienMatKhau.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ckHienMatKhau.Size = new System.Drawing.Size(91, 17);
            this.ckHienMatKhau.TabIndex = 3;
            this.ckHienMatKhau.Text = "Hiện mật khẩu";
            this.ckHienMatKhau.UseVisualStyleBackColor = true;
            this.ckHienMatKhau.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // grB
            // 
            this.grB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grB.AutoSize = true;
            this.grB.Controls.Add(this.label3);
            this.grB.Controls.Add(this.label2);
            this.grB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.grB.Location = new System.Drawing.Point(447, 70);
            this.grB.Margin = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.grB.Name = "grB";
            this.grB.Padding = new System.Windows.Forms.Padding(4, 0, 4, 4);
            this.grB.Size = new System.Drawing.Size(938, 466);
            this.grB.TabIndex = 4;
            this.grB.TabStop = false;
            this.grB.Enter += new System.EventHandler(this.grB_Enter);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(293, 414);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(309, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "119 Ấp Bắc - Phường 05 - Thành phố Mỹ Tho - Tỉnh Tiền Giang";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoEllipsis = true;
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label2.Location = new System.Drawing.Point(317, 37);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(4, 0, 4, 4);
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(245, 27);
            this.label2.TabIndex = 0;
            this.label2.Text = "THÔNG BÁO MỚI NHẤT";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // DangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1444, 592);
            this.Controls.Add(this.grB);
            this.Controls.Add(this.ckHienMatKhau);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.btSIGNIn);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "DangNhap";
            this.Padding = new System.Windows.Forms.Padding(8, 4, 4, 8);
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RightToLeftLayout = true;
            this.Text = "Sign_in";
            this.Load += new System.EventHandler(this.Sign_in_Load);
            this.grB.ResumeLayout(false);
            this.grB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btSIGNIn;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ckHienMatKhau;
        private System.Windows.Forms.GroupBox grB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}