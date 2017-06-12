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
        public List<ArtworkVO> artworksVO { get; set; }
        public NationalityVO nationalityVO { get; set; }




        public static List<AuthorVO> GetAuthorsVO()
        {
            List<AuthorVO> l = new List<AuthorVO>();
            foreach (Author a in A_Login.u.AuthorsRep.GetAll())
            {
                l.Add(AuthorConverter.toVO(a));
            }
            return l;
        }

        public static List<AuthorVO> GetAuthorsVO(int ID, string field)
        {
            List<AuthorVO> l = new List<AuthorVO>();
            switch (field)
            {
                default:
                    break;
                case "Nationality":
                    foreach (Author a in A_Login.u.AuthorsRep.Get(c => c.Nationality.NationalityID == ID))
                    {
                        l.Add(AuthorConverter.toVO(a));
                    }
                    break;
            }

            return l;
        }

        //private static void addToList(Author a, List<AuthorVO> l)
        //{
        //    CargarDiccionarios cd = new CargarDiccionarios();
        //    string lang = cd.GetCurrentLanguage();

        //    AuthorVO autVO = new AuthorVO();
        //    autVO.AuthorID = a.AuthorID;
        //    autVO.artName = a.artName;
        //    autVO.description = A_Login.u.AuthorTranslationsRep.Single(c => c.AuthorID == a.AuthorID && c.lang == lang).description;
        //    autVO.realName = a.realName;
        //    l.Add(autVO);
        //}
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
            result.artworksVO = ArtworkVO.GetArtworksVO(data.AuthorID, "Author");
            result.nationalityVO = NationalityVO.GetNationalityVO(data.Nationality.NationalityID);
            return result;
        }

        public static Author fromVO(AuthorVO data)//Pasa de AuthorVO a Author
        {
            Author result = new Author();
            result.AuthorID = data.AuthorID;
            result.realName = data.realName;
            result.artName = data.artName;
            List<Artwork> artworks = new List<Artwork>();
            foreach (ArtworkVO item in data.artworksVO)
            {
                artworks.Add(ArtworkConverter.fromVO(item));
            }
            result.Artworks = artworks;
            result.Nationality = NationalityConverter.fromVO(data.nationalityVO);
            return result;
        }
    }
}
