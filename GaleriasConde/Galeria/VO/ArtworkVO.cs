﻿using Galeria.Dict;
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
        public AuthorVO authorVO { get; set; }
        public TypeVO typeVO { get; set; }

        public static List<ArtworkVO> GetArtworksVO()
        {
            List<ArtworkVO> l = new List<ArtworkVO>();
            foreach (Artwork a in A_Login.u.ArtworksRep.GetAll())
            {
                l.Add(ArtworkConverter.toVO(a));
            }
            return l;
        }

        public static List<ArtworkVO> GetArtworksVO(int ID, string field)
        {
            List<ArtworkVO> l = new List<ArtworkVO>();
            switch (field)
            {
                default:
                    break;
                case "Type":
                    foreach (Artwork a in A_Login.u.ArtworksRep.Get(c => c.Type.TypeID == ID))
                    {
                        l.Add(ArtworkConverter.toVO(a));
                    }
                    break;
                case "Author":
                    foreach (Artwork a in A_Login.u.ArtworksRep.Get(c => c.Author.AuthorID == ID))
                    {
                        l.Add(ArtworkConverter.toVO(a));
                    }
                    break;
            }
            
            return l;
        }

        //private static void addToList(Artwork a, List<ArtworkVO> l)
        //{
        //    CargarDiccionarios cd = new CargarDiccionarios();
        //    string lang = cd.GetCurrentLanguage();

        //    ArtworkVO artVO = new ArtworkVO();
        //    artVO.ArtworkID = a.ArtworkID;
        //    artVO.date = a.date;
        //    artVO.dimensions = a.dimensions;
        //    artVO.img = a.img;
        //    artVO.info = A_Login.u.ArtworkTranslationsRep.Single(c => c.ArtworkID == a.ArtworkID && c.lang == lang).info;
        //    artVO.onStock = a.onStock;
        //    artVO.title = A_Login.u.ArtworkTranslationsRep.Single(c => c.ArtworkID == a.ArtworkID && c.lang == lang).title;
        //    l.Add(artVO);
        //}

    }

    public static class ArtworkConverter
    {
        public static ArtworkVO toVO(Artwork data)//Pasa de Artwork a ArtworkVO
        {
            CargarDiccionarios cd = new CargarDiccionarios();
            string lang = cd.GetCurrentLanguage();
            ArtworkVO result = new ArtworkVO();
            result.ArtworkID = data.ArtworkID;
            result.onStock = data.onStock;
            result.img = data.img;
            result.date = data.date;
            result.dimensions = data.dimensions;
            result.title = A_Login.u.ArtworkTranslationsRep.Single(c => c.ArtworkID == data.ArtworkID && c.lang == lang).title;
            result.info = A_Login.u.ArtworkTranslationsRep.Single(c => c.ArtworkID == data.ArtworkID && c.lang == lang).info;
            result.authorVO = AuthorConverter.toVO(data.Author);
            result.typeVO = TypeConverter.toVO(data.Type);
            return result;
        }

        public static Artwork fromVO(ArtworkVO data)//Pasa de ArtworkVO a Artwork
        {
            Artwork result = new Artwork();
            result.ArtworkID = data.ArtworkID;
            result.onStock = data.onStock;
            result.img = data.img;
            result.date = data.date;
            result.dimensions = data.dimensions;
            result.Author = AuthorConverter.fromVO(data.authorVO);
            result.Type = TypeConverter.fromVO(data.typeVO);
            return result;
        }
    }
}
