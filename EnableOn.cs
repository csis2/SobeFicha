using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SobeFicha
{
    class EnableOn
    {
        Form1 form1 = (Form1)Application.OpenForms["Form1"];
        public void enableOn()
        {
            form1.button1.Enabled = true;
            form1.button2.Enabled = true;
            form1.button3.Enabled = true;
            form1.button4.Enabled = true;
            form1.comboBox1.Enabled = true;
            form1.maskedTextBox1.Enabled = true;
            form1.maskedTextBox2.Enabled = true;
        }
    }
}