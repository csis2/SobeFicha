using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace SobeFicha
{
    class LookFor_Investiga
    {
        // Procura os registros na tabela de investigação que satisfaçam os parâmetros escolhidos pelo usuário para que estes
        // sejam selecionados e enviados para o próximo nivel no próximo lote.

        public void lookFor_Investiga()
        {
            if (Program.Erro == 0)
            {
                Cleanner cleanner = new Cleanner();
                cleanner.cleanner();

                switch (Program.Agravo)
                {
                    case "A30.9":
                        Program.Tabela = "tb_investiga_hanseniase"; // Hanseniase
                        break;
                    case "A16.9":
                        Program.Tabela = "tb_investiga_tuberculose"; // Tuberculose
                        break;
                    case "W64":
                        Program.Tabela = "tb_investiga_atend_antirabico"; // Atendimento anti-rabico 
                        break;
                    case "Y09":
                        Program.Tabela = "tb_investiga_violencia_dom"; // Violencia domestica, sexual e/ou outras violencias
                        break;
                    case "Z20.9":
                        Program.Tabela = "tb_investiga_mat_biologico"; // Acidente de trabalho com exposição a material biologico
                        break;
                    case "T65.9":
                        Program.Tabela = "tb_investiga_intoxica_exogena"; // Intoxicação exógena
                        break;
                }

                RunCommand runCommandX = new RunCommand();
                //runCommandX.Command = String.Format( "update dbsinan.tb_investiga_hanseniase set nu_lote_vertical = '' where co_cid = '{0}' and (dt_notificacao >= '{1}' and dt_notificacao <= '{2}');", (Program.Agravo), (Program.Data_Inicial_Postgres), (Program.Data_Final_Postgres) );
                runCommandX.Command = String.Format( "update dbsinan.{0} set nu_lote_vertical = '' where co_cid = '{1}' and (dt_notificacao >= '{2}' and dt_notificacao <= '{3}');", (Program.Tabela), (Program.Agravo), ( Program.Data_Inicial_Postgres), (Program.Data_Final_Postgres)  );
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