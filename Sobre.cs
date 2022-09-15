using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SobeFicha
{
    public partial class Sobre : Form
    {
        public Sobre()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 obj = (Form1)Application.OpenForms["Form1"];
            obj.Enabled = true;
            this.Close();
        }
    }
}