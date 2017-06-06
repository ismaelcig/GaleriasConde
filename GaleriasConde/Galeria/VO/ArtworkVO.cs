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
    public class ArtworkVO
    {
        public int ArtworkID { get; set; }
        public bool onStock { get; set; }
        public byte[] img { get; set; }
        public string date { get; set; }
        public string dimensions { get; set; }
        public string title { get; set; }
        public string info { get; set; }
        
        public static List<ArtworkVO> GetArtworksVO()
        {
            List<ArtworkVO> l = new List<ArtworkVO>();
            foreach (Artwork a in A_Login.u.ArtworksRep.GetAll())
            {
                addToList(a, l);
            }
            return l;
        }

        public static List<ArtworkVO> GetArtworksVO(int typeID)
        {
            List<ArtworkVO> l = new List<ArtworkVO>();
            foreach (Artwork a in A_Login.u.ArtworksRep.Get(c=>c.Type.TypeID == typeID))
            {
                addToList(a, l);
            }
            return l;
        }

        private static void addToList(Artwork a, List<ArtworkVO> l)
        {
            CargarDiccionarios cd = new CargarDiccionarios();
            string lang = cd.GetCurrentLanguage();

            ArtworkVO artVO = new ArtworkVO();
            artVO.ArtworkID = a.ArtworkID;
            artVO.date = a.date;
            artVO.dimensions = a.dimensions;
            artVO.img = a.img;
            artVO.info = A_Login.u.ArtworkTranslationsRep.Single(c => c.ArtworkID == a.ArtworkID && c.lang == lang).info;
            artVO.onStock = a.onStock;
            artVO.title = A_Login.u.ArtworkTranslationsRep.Single(c => c.ArtworkID == a.ArtworkID && c.lang == lang).title;
            l.Add(artVO);
        }

    }
}
