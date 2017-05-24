using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Galeria.Dict
{//https://msdn.microsoft.com/es-es/library/ee825488(v=cs.20).aspx
    public class CargarDiccionarios
    {
        static string currentLanguage;
        //Se llama al iniciar la aplicación
        //Establece un idioma según el idioma del ordenador
        public string GetLanguageDictionary()
        {
            return System.Threading.Thread.CurrentThread.CurrentCulture.ToString();
        }
        //Permite seleccionar el idioma
        public ResourceDictionary LanguageSelector(string idioma)
        {
            currentLanguage = idioma;
            ResourceDictionary dict = new ResourceDictionary();
            switch (idioma)
            {
                case "en-US":
                    dict.Source = new Uri("..\\Dict\\DictionaryEN.xaml", UriKind.Relative);
                    break;
                //case "fr-CA":
                //    dict.Source = new Uri("..\\Dict\\DictionaryFR.xaml", UriKind.Relative);
                //    break;
                case "es-ES":
                    dict.Source = new Uri("..\\Dict\\DictionarySP.xaml", UriKind.Relative);
                    break;
                //case "gl-ES":
                //    dict.Source = new Uri("..\\Dict\\DictionaryGL.xaml", UriKind.Relative);
                //    break;
                default:
                    dict.Source = new Uri("..\\Dict\\DictionarySP.xaml", UriKind.Relative);
                    break;
            }
            return dict;
        }
        public string GetCurrentLanguage()
        {
            return currentLanguage;
        }
    }
}
