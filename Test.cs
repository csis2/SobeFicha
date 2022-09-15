using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SobeFicha
{
    class Test
    // Testa se o PostgreSQL está ativo e com acesso ao banco de dados do SINAN NET.
    {
        public void test()
        {
            Task task2 = Task.Run(() =>
            {
                int found = 0;
                int counter = 0;
                string line;
                var text = "5.0.0.0 / Patch 5.3.0.0";
                System.IO.StreamReader file = new System.IO.StreamReader(@"c:\sobeficha\sobeficha\tmp\output.txt");
                while ((line = file.ReadLine()) != null)
                {
                    if (line.Contains(text))
                    {
                        found++;
                        break;
                    }
                    counter++;
                }
                if (found >= 1)
                {
                    Program.Erro = 0;
                    string cMessage = "Banco de dados do SINAN NET encontrado." + Environment.NewLine + "SINAN NET 5.0.0.0 / Patch 5.3.0.0.";
                    string cTitle = "SobeFicha";
                    MessageBox.Show(cMessage, cTitle, 0, MessageBoxIcon.Information);

                    Form1 form1 = (Form1)Application.OpenForms["Form1"];
                    form1.label2.BeginInvoke(
                                    new Action(() =>
                                    {
                                        form1.label2.Text = "Fim do teste. Banco de dados do SINAN NET, ok.";
                                    }
                                    ));
                }
                else
                {
                    Program.Erro = 1;
                    string cMessage = "Banco de dados do SINAN NET não foi encontrado." + Environment.NewLine + "Ou não está ativo.";
                    string cTitle = "SobeFicha";
                    MessageBox.Show(cMessage, cTitle, 0, MessageBoxIcon.Error);
                    Form1 form1 = (Form1)Application.OpenForms["Form1"];
                    form1.label2.BeginInvoke(
                                    new Action(() =>
                                    {
                                        form1.label2.Text = "Fim do teste. Banco de dados não encontrado.";
                                    }
                                    ));
                }
                file.Close();
            });
            task2.Wait();
        }
    }
}