﻿using Galeria.Dict;
using Galeria.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Galeria.User_Controls
{
    /// <summary>
    /// Interaction logic for LangSelector.xaml
    /// </summary>
    public partial class LanguageSelector : UserControl
    {
        CargarDiccionarios cd = new CargarDiccionarios();
        int cont = 0;
        List<Lang> languages = new List<Lang>();
        //public static Window parentWindow;//Al menos por ahora, es necesario settear esta variable desde la ventana donde se encuentra (problema, no se ve la variable)
        public LanguageSelector()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
            #region Idiomas
            languages.Add(new Lang { LangID = "en-US", display = "English" });//Inglés EEUU
            //languages.Add(new Lang { LangID = "fr-CA", display = "Français" });//Francés Canadá
            languages.Add(new Lang { LangID = "es-ES", display = "Español" });//Español España
            //languages.Add(new Lang { LangID = "gl-ES", display = "Galego" });//Gallego
            #endregion

            comboBox.ItemsSource = languages;
            comboBox.DisplayMemberPath = "display";
            comboBox.SelectedValuePath = "LangID";
            //Por defecto, se selecciona el idioma establecido
            int i = 0;
            foreach (Lang l in comboBox.ItemsSource)
            {
                if (l.LangID == cd.GetCurrentLanguage())
                {
                    break;
                }
                else
                {
                    i++;
                }
            }
            comboBox.SelectedIndex = i;
        }

        private class Lang
        {
            public Lang()
            {

            }
            public string LangID { get; set; }
            public string display { get; set; }
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cont < 3)
            {
                cont++;
            }
            else
            {
                try
                {
                    ResourceDictionary prevDict = A_Login.dict;//Diccionario previo, para hacer remove
                    A_Login.dict = cd.LanguageSelector((string)comboBox.SelectedValue);//Nuevo diccionario, para add
                    foreach (Window w in A_Login.windows)
                    {
                        w.Resources.MergedDictionaries.Remove(prevDict);
                        w.Resources.MergedDictionaries.Add(A_Login.dict);//Hasta aquí debería bastar, pero para los HintBox, como no tienen binding, necesito indicar a mano el cambio
                        if (w.Name == "A_Login")
                        {
                            A_Login.mw.LoadHints();
                        }
                        else if (w.Name == "B_Registro")
                        {
                            B_Registro.bregistro.LoadHints();
                        }
                        else if (w.Name == "C_Galeria")
                        {
                            C_Galeria.CGaleria.LoadHints();
                        }
                    }
                    //foreach (Ventana v in A_Login.ventanas)
                    //{
                    //    v.Window.Resources.MergedDictionaries.Remove(prevDict);
                    //    v.Window.Resources.MergedDictionaries.Add(A_Login.dict);
                    //    foreach (HintTextBox txt in v.Txts)
                    //    {
                    //        txt.hintTB.Text = (string)A_Login.dict["MWtxt"];
                    //    }
                    //}
                }
                catch (Exception ex)
                {
                    string error = ex.Message;
                }
            }
        }
    }
}
