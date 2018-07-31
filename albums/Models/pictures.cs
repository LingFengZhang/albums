using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Windows.Storage;

namespace albums.Models
{
    /// <summary>
    /// Picture类，在gridview中显示的图片都属于一个Picture类
    /// 具有：图片名、路径两种属性
    /// 在XML文档中属于<Item.name>、<Item path = "picturepath">
    /// </summary>
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

    

    /// <summary>
    /// 用于gridview的数据绑定，为Picture的列表
    /// 通过Xmlfile的方法进行初始化，更新
    /// </summary>
    public class somepictrues
    {
        public static List<Picture> Getpictures()
        {
            var pictures = new List<Picture>();
            XmlDocument doc = new XmlDocument();
            doc.Load(ApplicationData.Current.LocalFolder.Path + "/Pictures.xml");
            XmlElement pictures_xml = doc.DocumentElement;
            XmlNodeList list_1 = pictures_xml.ChildNodes;
            foreach (XmlNode sd in list_1)//test1~test14
            {
                XmlNodeList list_2 = sd.ChildNodes;

                foreach (XmlNode aw in list_2)//Nothing  MIKU
                {
                    XmlNodeList list_3 = aw.ChildNodes;

                    foreach (XmlNode sw in list_3)//Item1 Item2
                    {
                        if(sw.Name == "Item1")
                        {
                            pictures.Add(new Picture { picturename = "nothing", picturepath = sw.Attributes["path"].Value } );
                        } 
                    }

                }
            }
            return pictures;
        }

    }

}
