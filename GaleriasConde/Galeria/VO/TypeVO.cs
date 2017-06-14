using Galeria.Dict;
using Galeria.Model.Translation;
using Galeria.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeria.VO
{
    public class TypeVO
    {
        public int TypeID { get; set; }
        public string codType { get; set; }
        public int nArts { get; set; }//Para cargar en datagrid

        public TypeVO()
        {

        }

        public TypeVO(int id)
        {
            CargarDiccionarios cd = new CargarDiccionarios();
            string lang = cd.GetCurrentLanguage();
            Model.Type t = A_Login.u.TypesRep.Single(c => c.TypeID == id);
            TypeTranslations tt = A_Login.u.TypeTranslationsRep.Single(c => c.TypeID == id);
            this.TypeID = t.TypeID;
            this.codType = tt.codType;
            this.nArts = A_Login.u.ArtworksRep.Get(c => c.Type.TypeID == id).Count;
        }
    }
}
