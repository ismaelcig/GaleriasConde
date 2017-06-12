using Galeria.Dict;
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
        public List<ArtworkVO> artworksVO { get; set; }//Para cargar en datagrid, o acceder a ellos
    }

    public static class TypeConverter
    {
        public static TypeVO toVO(Model.Type data)//Pasa de Type a TypeVO
        {
            CargarDiccionarios cd = new CargarDiccionarios();
            string lang = cd.GetCurrentLanguage();
            TypeVO result = new TypeVO();
            result.TypeID = data.TypeID;
            result.codType = A_Login.u.TypeTranslationsRep.Single(c => c.TypeID == data.TypeID && c.lang == lang).codType;
            result.artworksVO = ArtworkVO.GetArtworksVO(result.TypeID, "Type");//VO de las obras que pertenecen a este tipo
            return result;
        }

        public static Model.Type fromVO(TypeVO data)//Pasa de TypeVO a Type
        {
            Model.Type result = new Model.Type();
            result.TypeID = data.TypeID;
            return result;
        }
    }
}
