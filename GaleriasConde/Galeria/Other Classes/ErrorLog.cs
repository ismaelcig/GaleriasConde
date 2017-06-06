using Galeria.Windows;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Galeria.Other_Classes
{
    class ErrorLog
    {
        public static void Log(string origin, Exception ex)
        {
            if (!File.Exists("Logs.txt"))
            {
                File.Create("Logs.txt");
            }
            string error =
                        "Log Entry : " +
                        DateTime.Now.ToLongTimeString() + ", " +
                        DateTime.Now.ToLongDateString() + " :: " +
                        "From " + origin + " :: " +
                        ex.Message + Environment.NewLine +
                        " :Inner Exception: " + ex.InnerException + Environment.NewLine +
                        "------------------------------------------------------------";
            StreamWriter sw;
            sw = File.AppendText("Logs.txt");
            sw.WriteLine(error);
            sw.Flush();
            sw.Close();
            MessageBox.Show((string)A_Login.dict["Error"]);//Muestra error genérico
        }
    }
}