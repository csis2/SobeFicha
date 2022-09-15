using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;

namespace SobeFicha
{
    class Verify
    {
        // Verifica se há inconsistência na entrada de dados do usuário antes de prosseguir com o processamento dos dados.
        Form1 form1 = (Form1)Application.OpenForms["Form1"];
        public void verify()
        {        
            // Testando se o banco de dados está ativo sem a intervenção do usuário.
            {
            Program.Erro = 0;
            EnableOff enableOff = new EnableOff();
            EnableOn enableOn = new EnableOn();
            enableOff.enableOff();

            Cleanner cleanner = new Cleanner();
            cleanner.cleanner();

            RunCommand runCommandX = new RunCommand();
            runCommandX.Command = "select ds_atualizacao from dbsinan.tb_configuracao;";
            runCommandX.runCommand();

            Test2 test2 = new Test2();
            test2.test2();

            if (Program.Erro != 0)
            {
            Program.Erro = 1;
            string cMessage2 = "Banco de dados do SINAN NET não foi encontrado." + Environment.NewLine + "Ou não está ativo.";
            string cTitle2 = "SobeFicha";
            MessageBox.Show(cMessage2, cTitle2, 0, MessageBoxIcon.Error);
            enableOn.enableOn();
            }

            // Procurando entrada inconsistente ou invalida nos campos de data.
            // Data inicial.
            if (Program.Erro == 0)
            {
            string date1 = form1.maskedTextBox1.Text;
            string[] split = date1.Split('/');
            string element1 = split[0];
            string element2 = split[1];
            string element3 = split[2];

            if (string.IsNullOrEmpty(element1) || string.IsNullOrEmpty(element2) || string.IsNullOrEmpty(element3))
            {
            Program.Erro = 1;
            string cTitle7 = "SobeFicha";
            string cMessage7 = "Dia, mês ou ano está nulo ou vazio no campo data inicial. "; //61 9 9696 3400
            MessageBox.Show(cMessage7, cTitle7, 0, MessageBoxIcon.Error);
            enableOn.enableOn();
            }
            }

            if (Program.Erro == 0)
            {
            string dt1 = form1.maskedTextBox1.Text;
            string[] split2 = dt1.Split('/');
            string element_day = split2[0];
            string element_month = split2[1];
            string element_year = split2[2];

            int day1 = Convert.ToInt32(element_day);
            int month1 = Convert.ToInt32(element_month);
            int year1 = Convert.ToInt32(element_year);

            if (day1 <= 0 || day1 > 31)
            {
                Program.Erro = 1;
                string cTitle6 = "SobeFicha";
                string cMessage6 = "O dia da data inicial é menor ou igual a zero ou maior que 31.";
                MessageBox.Show(cMessage6, cTitle6, 0, MessageBoxIcon.Error);
                enableOn.enableOn();
            }

            if (month1 <= 0 || month1 > 12)
            {
                Program.Erro = 1;
                string cTitle6 = "SobeFicha";
                string cMessage6 = "O mês da data inicial é menor ou igual a zero ou maior que 12.";
                MessageBox.Show(cMessage6, cTitle6, 0, MessageBoxIcon.Error);
                enableOn.enableOn();
            }

            if (year1 < 1980)
            {
                Program.Erro = 1;
                string cTitle6 = "SobeFicha";
                string cMessage6 = "O ano inicial não pode ser menor que 1980. ";
                MessageBox.Show(cMessage6, cTitle6, 0, MessageBoxIcon.Error);
                enableOn.enableOn();
            }
            }

            // Data final.
            if (Program.Erro == 0)
            {
                string date2 = form1.maskedTextBox2.Text;
                string[] split3 = date2.Split('/');
                string element4 = split3[0];
                string element5 = split3[1];
                string element6 = split3[2];

                if (string.IsNullOrEmpty(element4) || string.IsNullOrEmpty(element5) || string.IsNullOrEmpty(element6))
                {
                    Program.Erro = 1;
                    string cTitle7 = "SobeFicha";
                    string cMessage7 = "Dia, mês ou ano está nulo ou vazio no campo data final. ";
                    MessageBox.Show(cMessage7, cTitle7, 0, MessageBoxIcon.Error);
                    enableOn.enableOn();
                }
            }

            if (Program.Erro == 0)
            {
                string dt2 = form1.maskedTextBox2.Text;
                string[] split4 = dt2.Split('/');
                string element_day2 = split4[0];
                string element_month2 = split4[1];
                string element_year2 = split4[2];

                int day2 = Convert.ToInt32(element_day2);
                int month2 = Convert.ToInt32(element_month2);
                int year2 = Convert.ToInt32(element_year2);

                if (day2 <= 0 || day2 > 31)
                {
                    Program.Erro = 1;
                    string cTitle6 = "SobeFicha";
                    string cMessage6 = "O dia da data final é menor ou igual a zero ou maior que 31.";
                    MessageBox.Show(cMessage6, cTitle6, 0, MessageBoxIcon.Error);
                    enableOn.enableOn();
                }

                if (month2 <= 0 || month2 > 12)
                {
                    Program.Erro = 1;
                    string cTitle6 = "SobeFicha";
                    string cMessage6 = "O mês da data final é menor ou igual a zero ou maior que 12.";
                    MessageBox.Show(cMessage6, cTitle6, 0, MessageBoxIcon.Error);
                    enableOn.enableOn();
                }

                if (year2 < 1980)
                {
                    Program.Erro = 1;
                    string cTitle6 = "SobeFicha";
                    string cMessage6 = "O ano final não pode ser menor que 1980. ";
                    MessageBox.Show(cMessage6, cTitle6, 0, MessageBoxIcon.Error);
                    enableOn.enableOn();
                }
            }

            // Verificando se a data inicial é válida (se existe no calendário).
            if (Program.Erro == 0)
            {
                string date1 = form1.maskedTextBox1.Text;
                try
                {
                    DateTime dt1 = DateTime.Parse(date1);
                }
                catch (Exception)
                {
                    Program.Erro = 1;
                    string cTitle6 = "SobeFicha";
                    string cMessage6 = "A data inicial não existe no calendário.";
                    MessageBox.Show(cMessage6, cTitle6, 0, MessageBoxIcon.Error);
                    enableOn.enableOn();
                }
            }

            // Verificando se a data final é válida (se existe no calendário).
            if (Program.Erro == 0)
            {
                string date2 = form1.maskedTextBox2.Text;
                try
                {
                    DateTime dt2 = DateTime.Parse(date2);
                }
                catch (Exception)
                {
                    Program.Erro = 1;
                    string cTitle6a = "SobeFicha";
                    string cMessage6a = "A data final não existe no calendário.";
                    MessageBox.Show(cMessage6a, cTitle6a, 0, MessageBoxIcon.Error);
                    enableOn.enableOn();
                }
            }

             // Mais testes com os campos de data.
             if (Program.Erro == 0)
                {
                string date1 = form1.maskedTextBox1.Text;
                string date2 = form1.maskedTextBox2.Text;

                DateTime dt1 = DateTime.Parse(date1);
                DateTime dt2 = DateTime.Parse(date2);

                    if (dt2.Date < dt1.Date)
                        {
                        Program.Erro = 1;
                        string cMessage5 = "A data final não pode ser menor que a data inicial.";
                        string cTitle5 = "SobeFicha";
                        MessageBox.Show(cMessage5, cTitle5, 0, MessageBoxIcon.Error);
                        enableOn.enableOn();
                    }
                }

            if (Program.Erro == 0)
            {
                string date1 = form1.maskedTextBox1.Text;

                DateTime dt1 = DateTime.Parse(date1);
                DateTime dt3 = DateTime.Now;

                if (dt1.Date > dt3.Date)
                {
                    Program.Erro = 1;
                    string cMessage5 = "A data inicial não pode ser uma data futura.";
                    string cTitle5 = "SobeFicha";
                    MessageBox.Show(cMessage5, cTitle5, 0, MessageBoxIcon.Error);
                    enableOn.enableOn();
                }
            }

                if (Program.Erro == 0)
                {
                    string date2 = form1.maskedTextBox2.Text;

                    DateTime dt2 = DateTime.Parse(date2);
                    DateTime dt3 = DateTime.Now;

                    if (dt2.Date > dt3.Date)
                    {
                        Program.Erro = 1;
                        string cMessage5 = "A data final não pode ser uma data futura.";
                        string cTitle5 = "SobeFicha";
                        MessageBox.Show(cMessage5, cTitle5, 0, MessageBoxIcon.Error);
                        enableOn.enableOn();
                    }
                }

                // Testando se foi escolhido algum agravo.
                string option = form1.comboBox1.Text;
                if (string.IsNullOrEmpty(option) && Program.Erro == 0)
                {
                    Program.Erro = 1;
                    string cMessage12 = "Nenhum agravo foi escolhido" + option;
                    string cTitle12 = "SobeFicha";
                    MessageBox.Show(cMessage12, cTitle12, 0, MessageBoxIcon.Error);
                    enableOn.enableOn();
                }
                else
                {
				switch(option)
				{
                    case "Hanseniase":
                    Program.Agravo = "A30.9";
                    break;
                    case "Tuberculose":
					Program.Agravo = "A16.9";
					break;
                    case "Atendimento anti rabico humano ":
					Program.Agravo = "W64";
                    break;
                    case "Violencia domestica, sexual e/ou outras violencias":
                    Program.Agravo = "Y09";
                    break;
                    case "Acidente de trabalho com exposicao a material biologico":
                    Program.Agravo = "Z20.9";
                    break;
                    case "Intoxicacao exogena":
                    Program.Agravo = "T65.9";
                    break;
                    }
                }

                if (Program.Erro == 0)
                {
                    Program.Data_Inicial = form1.maskedTextBox1.Text;
                    Program.Data_Final = form1.maskedTextBox2.Text;
                }

                if (Program.Erro == 0)
                {
                    string cMessage13 = "Inicio do processamento dos registros." + "\n" + "\n" + "Aguarde até que o processamento seja concluído..." + "\n" + "\n" + "Clique no botão OK para iniciar." ;
                    string cTitle13 = "SobeFicha";
                    MessageBox.Show(cMessage13, cTitle13, 0, MessageBoxIcon.Error);
                }
            }
        }   
    }
}