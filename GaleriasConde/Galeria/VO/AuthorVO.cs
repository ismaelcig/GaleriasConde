using Galeria.Dict;
using Galeria.Model;
using Galeria.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeria.VO
{
    public class AuthorVO
    {
        public int AuthorID { get; set; }
        public string realName { get; set; }
        public string artName { get; set; }
        public string description { get; set; }
        //Lista de Obras?
        public static List<AuthorVO> GetAuthorsVO()
        {
            List<AuthorVO> l = new List<AuthorVO>();
            foreach (Author a in A_Login.u.AuthorsRep.GetAll())
            {
                addToList(a, l);
            }
            return l;
        }

        //TODO: Modificar este método si se quiere buscar por algún campo

        //public static List<AuthorVO> GetAuthorsVO(int typeID)
        //{
        //    List<AuthorVO> l = new List<AuthorVO>();
        //    foreach (Author a in A_Login.u.AuthorsRep.Get(c => c.Type.TypeID == typeID))
        //    {
        //        addToList(a, l);
        //    }
        //    return l;
        //}

        private static void addToList(Author a, List<AuthorVO> l)
        {
            CargarDiccionarios cd = new CargarDiccionarios();
            string lang = cd.GetCurrentLanguage();

            AuthorVO autVO = new AuthorVO();
            autVO.AuthorID = a.AuthorID;
            autVO.artName = a.artName;
            autVO.description = A_Login.u.AuthorTranslationsRep.Single(c => c.AuthorID == a.AuthorID && c.lang == lang).description;
            autVO.realName = a.realName;
            l.Add(autVO);
        }
    }

    public static class AuthorConverter
    {
        public static AuthorVO toVO(Author data)//Pasa de Author a AuthorVO
        {
            CargarDiccionarios cd = new CargarDiccionarios();
            string lang = cd.GetCurrentLanguage();
            AuthorVO result = new AuthorVO();
            result.AuthorID = data.AuthorID;
            result.realName = data.realName;
            result.artName = data.artName;
            result.description = A_Login.u.AuthorTranslationsRep.Single(c => c.AuthorID == data.AuthorID && c.lang == lang).description;
            return result;
        }
    }
}
