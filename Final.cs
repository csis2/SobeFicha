using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SobeFicha
{
    class Final
    {
        // Essa classe dá um feedback ao usuário informando o resultado ao final de todo o processo.
        public void final()
        {
            {
                if (Program.Erro == 0)
                {
                    Task task12 = Task.Run(() =>
                    {
                        int found = 0;
                        int counter = 0;
                        string line;
                        string resultString;
                        var text = "UPDATE";
                        System.IO.StreamReader file = new System.IO.StreamReader(@"c:\sobeficha\sobeficha\tmp\output.txt");
                        while ((line = file.ReadLine()) != null)
                        {
                            if (line.Contains(text))
                            {
                                found++;
                                resultString = Regex.Match(line, @"\d+").Value;
                                if ( resultString == "0" )
                                {
                                    string cMessage2 = "Nenhuma notificação encontrada com os critérios indicados." + "\n" + "\n" + "Fim do programa.";
                                    string cTitle2 = "SobeFicha";
                                    MessageBox.Show(cMessage2, cTitle2, 0, MessageBoxIcon.Information);
                                    System.Windows.Forms.Application.Exit();
                                }
                                else
                                {
                                    string cMessage2 = String.Format( "{0} notificação(es) encontrada(s) com os critérios indicados." + "\n" + "\n" + "Essas notificações serão incluídas no próximo lote que for gerado." + "\n" + "\n" + "Fim do programa.", resultString );
                                    string cTitle2 = "SobeFicha";
                                    MessageBox.Show(cMessage2, cTitle2, 0, MessageBoxIcon.Information);
                                    System.Windows.Forms.Application.Exit();
                                }
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
                    task12.Wait();
                }
            }
        }
    }
}