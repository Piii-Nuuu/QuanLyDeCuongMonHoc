namespace QuanLyDeCuongProject
{
    partial class QuanLyPhanQuyen
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
            this.comboxPermission = new System.Windows.Forms.ComboBox();
            this.listPermission = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.comboBoxQuyen = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboxPermission
            // 
            this.comboxPermission.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.comboxPermission.FormattingEnabled = true;
            this.comboxPermission.ItemHeight = 25;
            this.comboxPermission.Location = new System.Drawing.Point(1577, 232);
            this.comboxPermission.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboxPermission.Name = "comboxPermission";
            this.comboxPermission.Size = new System.Drawing.Size(300, 33);
            this.comboxPermission.TabIndex = 0;
            this.comboxPermission.SelectedIndexChanged += new System.EventHandler(this.comboxPermission_SelectedIndexChanged);
            // 
            // listPermission
            // 
            this.listPermission.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listPermission.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.listPermission.FullRowSelect = true;
            this.listPermission.GridLines = true;
            this.listPermission.HideSelection = false;
            this.listPermission.Location = new System.Drawing.Point(12, 253);
            this.listPermission.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listPermission.Name = "listPermission";
            this.listPermission.Size = new System.Drawing.Size(400, 389);
            this.listPermission.TabIndex = 1;
            this.listPermission.UseCompatibleStateImageBehavior = false;
            this.listPermission.View = System.Windows.Forms.View.Details;
            this.listPermission.SelectedIndexChanged += new System.EventHandler(this.listPermission_SelectedIndexChanged);
            this.listPermission.Click += new System.EventHandler(this.listPermission_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "MaPermission";
            this.columnHeader1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader1.Width = 151;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Actions";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 245;
            // 
            // comboBoxQuyen
            // 
            this.comboBoxQuyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.comboBoxQuyen.FormattingEnabled = true;
            this.comboBoxQuyen.Location = new System.Drawing.Point(12, 157);
            this.comboBoxQuyen.Name = "comboBoxQuyen";
            this.comboBoxQuyen.Size = new System.Drawing.Size(454, 33);
            this.comboBoxQuyen.TabIndex = 2;
            this.comboBoxQuyen.SelectedIndexChanged += new System.EventHandler(this.comboBoxQuyen_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SteelBlue;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(1640, 288);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(172, 46);
            this.button1.TabIndex = 3;
            this.button1.Text = "Thêm";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.SteelBlue;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(1639, 358);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(172, 46);
            this.button2.TabIndex = 3;
            this.button2.Text = "Sửa";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.SteelBlue;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(1639, 433);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(172, 46);
            this.button3.TabIndex = 3;
            this.button3.Text = "Xóa";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(1572, 198);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "Action";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(16, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(270, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "Danh sách permission";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label3.Location = new System.Drawing.Point(16, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(211, 29);
            this.label3.TabIndex = 4;
            this.label3.Text = "Danh sách quyền";
            // 
            // QuanLyPhanQuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1017);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBoxQuyen);
            this.Controls.Add(this.listPermission);
            this.Controls.Add(this.comboxPermission);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "QuanLyPhanQuyen";
            this.Text = "QuanLyPhanQuyen";
            this.Load += new System.EventHandler(this.QuanLyPhanQuyen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboxPermission;
        private System.Windows.Forms.ListView listPermission;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ComboBox comboBoxQuyen;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}