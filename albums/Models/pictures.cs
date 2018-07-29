using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Windows.Storage;

namespace albums.Models
{
    public class Picture
    {
        public string picturename { get; set; }
        public string picturepath { get; set; }
        public void emptypivture()
        {
            picturename = "MIKU";
            picturepath = "/Assets/miku.gif";
        }
    }

    public class somepictrues
    {
        public static List<Picture> Getpictures()
        {
            var pictures = new List<Picture>();
            //Xmlfile xmlfile = new Xmlfile();
            //XmlDocument doc = new XmlDocument();
            //doc.Load(ApplicationData.Current.LocalFolder.Path + "//Pictures.xml");
            //XmlElement pictures_xml = doc.DocumentElement;

            //XmlNodeList doclist = pictures_xml.ChildNodes;
            //foreach (XmlNode sd in doclist)
            //{

            //    foreach(XmlNode aw in sd)
            //    {
            //        Picture picture = new Picture();
            //        if (aw.Name=="Item1")
            //        {
            //            picture.picturename = 
            //        }
            //        else if(aw.Name == "Item2")
            //        {

            //        }
            //        pictures.Add(picture);
            //    }
            //    pictures.Add(new Picture { picturename = "nothing", picturepath = "/Assets/miku.gif" });
            //}
            pictures.Add(new Picture { picturename = "nothing", picturepath = "/Assets/miku.gif"});
            pictures.Add(new Picture { picturename = "nothing", picturepath = "/Assets/NewFolder1/003B.png" });
            pictures.Add(new Picture { picturename = "nothing", picturepath = "/Assets/NewFolder1/003C.png" });
            pictures.Add(new Picture { picturename = "nothing", picturepath = "/Assets/NewFolder1/003D.png" });
            pictures.Add(new Picture { picturename = "nothing", picturepath = "/Assets/NewFolder1/008B.png" });
            pictures.Add(new Picture { picturename = "nothing", picturepath = "/Assets/NewFolder1/037A.png" });
            pictures.Add(new Picture { picturename = "nothing", picturepath = "/Assets/NewFolder1/037A.png" });
            pictures.Add(new Picture { picturename = "nothing", picturepath = "/Assets/NewFolder1/037C.png" });
            pictures.Add(new Picture { picturename = "nothing", picturepath = "/Assets/NewFolder1/070B.png" });
            pictures.Add(new Picture { picturename = "nothing", picturepath = "/Assets/NewFolder1/070D.png" });
            pictures.Add(new Picture { picturename = "nothing", picturepath = "/Assets/NewFolder1/106B.png" });
            pictures.Add(new Picture { picturename = "nothing", picturepath = "/Assets/NewFolder1/18.jpg" });
            pictures.Add(new Picture { picturename = "nothing", picturepath = "/Assets/NewFolder1/2.jpg" });
            pictures.Add(new Picture { picturename = "nothing", picturepath = "/Assets/NewFolder1/2017060554539253.jpg" });
            pictures.Add(new Picture { picturename = "nothing", picturepath = "/Assets/miku.gif" });
            pictures.Add(new Picture { picturename = "nothing", picturepath = "/Assets/miku.gif" });
            pictures.Add(new Picture { picturename = "nothing", picturepath = "/Assets/miku.gif" });
            pictures.Add(new Picture { picturename = "nothing", picturepath = "/Assets/miku.gif" });

            return pictures;
        }

    }

}
