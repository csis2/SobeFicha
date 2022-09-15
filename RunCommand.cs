using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;

namespace SobeFicha
{
    class RunCommand
    // Envia comandos pre estabelecidos e gerados em outras classes para o PostgreSQL.
    {
        private string command;

        public string Command
        {
            get { return command; }
            set { command = value; }
        }

        public void runCommand()
        {
            ProcessStartInfo startInfo1 = new ProcessStartInfo();
            startInfo1.CreateNoWindow = true;
            startInfo1.UseShellExecute = true;
            startInfo1.FileName = "cmd.exe";
            startInfo1.WorkingDirectory = @"c:\sobeficha\sobeficha\bin";
            String cFilex = @"""c:\program files (x86)\postgresql\9.0\bin""";
            String cCommando = String.Format(@"""{0}""", Command);
            startInfo1.Arguments = String.Format("/C run_psqlx {0} localhost 5445 postgres sinanpop62 {1}", (cFilex), (cCommando));
            startInfo1.WindowStyle = ProcessWindowStyle.Hidden;
            var process1 = Process.Start(startInfo1);
            process1.WaitForExit();
            var process2 = process1.ExitCode.ToString();
            var process3 = startInfo1.FileName;
            var process4 = startInfo1.Arguments;

            if (!File.Exists(@"c:\sobeficha\sobeficha\tmp\output.txt"))
            {
                string cMessage = "Erro! Falha ao criar arquivo de saida (output.txt).";
                string cTitle = "SobeFicha";
                MessageBox.Show(cMessage, cTitle, 0, MessageBoxIcon.Error);
                System.Windows.Forms.Application.Exit();
            }
        }
    }
}