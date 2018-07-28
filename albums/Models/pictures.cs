using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace albums.Models
{
    public class Picture
    {
        public string picturename { get; set; }
        public string picturepath { get; set; }
        public void emptypivture()
        {
            picturename = "";
            picturepath = "";
        }
    }

    public class somepictrues
    {
        public static List<Picture> Getpictures()
        {
            var pictures = new List<Picture>();
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
