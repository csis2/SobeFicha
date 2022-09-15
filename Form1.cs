using System;
using System.IO;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;

namespace SobeFicha
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        // Testa se o banco de dados do SINAN NET está ativo.
        {
            Form1 form1 = (Form1)Application.OpenForms["Form1"];
            form1.button3.Enabled = false;
            form1.label2.Text = "Aguarde. Testando...";

            Cleanner cleanner = new Cleanner();
            cleanner.cleanner();

            RunCommand runCommandX = new RunCommand();
            runCommandX.Command = "select ds_atualizacao from dbsinan.tb_configuracao;";
            runCommandX.runCommand();

            Test test = new Test();
            test.test();
            form1.button3.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        // Processa a solicitação do usuário, se tudo estiver ok.
        {
            Verify verify = new Verify();
            verify.verify();

            if (Program.Erro == 0)
            {
                LookFor_Notifica lookFor_Notifica = new LookFor_Notifica();
                lookFor_Notifica.lookFor_Notifica();
            }

            if (Program.Erro == 0)
            {
                LookFor_Investiga lookFor_Investiga = new LookFor_Investiga();
                lookFor_Investiga.lookFor_Investiga();
            }

            if (Program.Erro == 0)
            {
                Final final = new Final();
                final.final();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Sobre sobre = new Sobre();
            sobre.StartPosition = FormStartPosition.CenterParent;
            sobre.Show();
        }
    }
}