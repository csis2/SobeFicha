using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SobeFicha
{
    class Cleanner
    // Exclui o arquivo "output.txt" que contem o resultado dos comandos enviados ao PostgeSQL.
    {
        public void cleanner()
        {
            Task task1 = Task.Run(() =>
            {
                File.Delete(@"c:\sobeficha\sobeficha\tmp\output.txt");
            });
            task1.Wait();
        }
    }
}