using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace SobeFicha
{
    class Test2
    {
    // Testa se o PostgreSQL está ativo e com acesso ao banco de dados do SINAN NET sem a intervenção do usuário.

        public void test2()
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
                }
                else
                {
                    Program.Erro = 1;
                }
                file.Close();
            });
            task2.Wait();
        }
    }
}