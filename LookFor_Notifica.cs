using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace SobeFicha
{
    class LookFor_Notifica
    {
        // Procura os registros na tabela de notificação que satisfaçam os parâmetros escolhidos pelo usuário para que estes
        // sejam selecionados e enviados para o próximo nivel no próximo lote.

        public void lookFor_Notifica()
        {
            if (Program.Erro == 0)
            {
                Cleanner cleanner = new Cleanner();
                cleanner.cleanner();

                string dt_inicial = Program.Data_Inicial;
                string[] split_dt_ini= dt_inicial.Split('/');
                string element_day_dt_ini = split_dt_ini[0];
                string element_month_dt_ini = split_dt_ini[1];
                string element_year_dt_ini = split_dt_ini[2];

                string dt_final = Program.Data_Final;
                string[] split_dt_fin = dt_final.Split('/');
                string element_day_dt_fin = split_dt_fin[0];
                string element_month_dt_fin = split_dt_fin[1];
                string element_year_dt_fin = split_dt_fin[2];

                Program.Data_Inicial_Postgres = element_year_dt_ini + "-" + element_month_dt_ini + "-" + element_day_dt_ini;
                Program.Data_Final_Postgres = element_year_dt_fin + "-" + element_month_dt_fin + "-" + element_day_dt_fin;

                RunCommand runCommandX = new RunCommand();
                runCommandX.Command = String.Format( "update dbsinan.tb_notificacao set nu_lote_vertical = '' where co_cid = '{0}' and (dt_notificacao >= '{1}' and dt_notificacao <= '{2}');", (Program.Agravo), (Program.Data_Inicial_Postgres), (Program.Data_Final_Postgres) );
                runCommandX.runCommand();

                Task task9 = Task.Run(() =>
                {
                    int found = 0;
                    int counter = 0;
                    string line;
                    var text = "UPDATE";
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
                task9.Wait();
            }
        }
    }
}