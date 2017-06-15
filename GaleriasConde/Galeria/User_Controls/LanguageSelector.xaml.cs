using Galeria.Dict;
using Galeria.Model;
using Galeria.Other_Classes;
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
        //List<Lang> languages = new List<Lang>();

        public LanguageSelector()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                ErrorLog.SilentLog("LangSel1", ex);
            }
            //languages = A_Login.u.LangsRep.GetAll();
            #region Idiomas
            /*Añadidos*/
            //LangID = 1, codLang = "en-US", display = "English" });//Inglés EEUU
            //LangID = 2, codLang = "es-ES", display = "Español" });//Español España
            /*Aún no añadidos*/
            //LangID = 3, codLang = "gl-ES", display = "Galego" });//Gallego
            //LangID = 4, codLang = "fr-CA", display = "Français" });//Francés Canadá
            #endregion

            Loaders.LoadLangs(comboBox);
            //Por defecto, se selecciona el idioma establecido
            int i = 0;
            try
            {
                foreach (Lang l in comboBox.ItemsSource)
                {
                    if (l.codLang == cd.GetCurrentLanguage())
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
            catch (Exception ex)
            {
                ErrorLog.SilentLog("LangSel2", ex);
            }
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
                    foreach (Window w in A_Login.windows)
                    {
                        w.Resources.MergedDictionaries.Remove(A_Login.dict);
                        A_Login.dict = cd.LanguageSelector((string)comboBox.SelectedValue);
                        w.Resources.MergedDictionaries.Add(A_Login.dict);
                        switch (w.Name)
                        {
                            default:
                                break;
                            case "B_Registro":
                                B_Registro.br.OnLangChange();
                                break;
                            case "C_Galeria":
                                C_Galeria.cg.OnLangChange();
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErrorLog.SilentLog("LangSel3", ex);
                }
            }
        }

    }
}
