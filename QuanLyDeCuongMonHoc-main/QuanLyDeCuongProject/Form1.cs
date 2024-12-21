
﻿using QuanLyDeCuongProject.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDeCuongProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        StreamReader read = null;

        private void Form1_Load(object sender, EventArgs e)
        {
            // Enter Your Server Name
            // Hello Aliens @@


            // test  github ac

            //  DataBase database = new DataBase(@"SerVer Name"); 
            if(read != null)
                textBox1.Text = read.ReadToEnd();
            else
            {
                this.Close();
            }
        }

        public void loadFile(string madc)
        {
            OpenFileDialog open = new OpenFileDialog();
            try
            {
                read = new StreamReader($"{madc}.txt");

            }catch(Exception ex)
            {
                MessageBox.Show("Lỗi mở file");
            }

        }
    }
}
