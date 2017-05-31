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
        public static void Log(string origin, string logMessage)
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
                        logMessage + Environment.NewLine +
                        "------------------------------------------------------------";
            StreamWriter sw = new StreamWriter("Logs.txt");
            sw.WriteLine(error);
            sw.Close();
            MessageBox.Show((string)A_Login.dict["Error"]);//Muestra error genérico
        }
    }
}