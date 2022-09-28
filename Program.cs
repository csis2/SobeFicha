using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SobeFicha
{
    static class Program
    {
        //[STAThread]
        private static int erro = 0;
        private static string agravo;
        private static string data_inicial;
        private static string data_final;
        private static string data_inicial_postgres;
        private static string data_final_postgres;
        private static string tabela;
        private static string postgres_path_type;
        private static string postgres_path;

        public static int Erro
        {
            get { return erro; }
            set { erro = value; }
        }
        public static string Agravo
        {
            get { return agravo; }
            set { agravo = value; }
        }
        public static string Data_Inicial
        {
            get { return data_inicial; }
            set { data_inicial = value; }
        }
        public static string Data_Final
        {
            get { return data_final; }
            set { data_final = value; }
        }
        public static string Data_Inicial_Postgres
        {
            get { return data_inicial_postgres; }
            set { data_inicial_postgres = value; }
        }
        public static string Data_Final_Postgres
        {
            get { return data_final_postgres; }
            set { data_final_postgres = value; }
        }
        public static string Tabela
        {
            get { return tabela; }
            set { tabela = value; }
        }
        public static string Postgres_Path_Type
        {
            get { return postgres_path_type; }
            set { postgres_path_type = value; }
        }
        public static string Postgres_Path
        {
            get { return postgres_path; }
            set { postgres_path = value; }
        }

        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}