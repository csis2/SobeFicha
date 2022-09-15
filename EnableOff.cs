using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SobeFicha
{
    class EnableOff
    {
        Form1 form1 = (Form1)Application.OpenForms["Form1"];
        public void enableOff()
        {
            form1.button1.Enabled = false;
            form1.button2.Enabled = false;
            form1.button3.Enabled = false;
            form1.button4.Enabled = false;
            form1.comboBox1.Enabled = false;
            form1.maskedTextBox1.Enabled = false;
            form1.maskedTextBox2.Enabled = false;
        }
    }
}