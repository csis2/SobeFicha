using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SobeFicha
{
    class Postgresql
    {
        // Identificando o caminho (path) da instalação do PostgreSQL.
        public void postgresql()
        {
            if (File.Exists(@"c:\program files (x86)\postgresql\9.0\bin\psql.exe"))
            {
                Program.Postgres_Path_Type = "program_files_x86";
            }

            if (File.Exists(@"c:\program files\postgresql\9.0\bin\psql.exe"))
            {
                Program.Postgres_Path_Type = "program_files";
            }

            if (Program.Postgres_Path_Type != "program_files_x86" && Program.Postgres_Path_Type != "program_files")
            {
                Program.Postgres_Path_Type = "other";
            }
        }
    }
}