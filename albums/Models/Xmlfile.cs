using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Windows.Storage;

namespace albums.Models
{
    class Xmlfile
    {

        /// <summary>
        /// 创建一个XML文件并确定数据结构
        /// 每个picture下有两个图片：原图(Original_painting)、临摹(My_painting)
        /// 图片下有item,item.name为图片文件名，item有属性path，为图片路径
        /// </summary>
        /// 
        public void Newxml()
            {
                //创建一个XML文档
                XmlDocument doc = new XmlDocument();
                XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "utf-8", null);//写第一行数据
                doc.AppendChild(dec);
                //创建根节点 pictures
                XmlElement pictures = doc.CreateElement("Pictures");
                doc.AppendChild(pictures);

                XmlElement picture = doc.CreateElement("Picture");
                pictures.AppendChild(picture);

                XmlElement original_painting = doc.CreateElement("Original_painting");
                picture.AppendChild(original_painting);
                XmlElement item1 = doc.CreateElement("Item1");
                item1.SetAttribute("path","");
                original_painting.AppendChild(item1);

                XmlElement my_painting = doc.CreateElement("My_painting");
                XmlElement item2 = doc.CreateElement("Item2");
                item2.SetAttribute("path", "");
                my_painting.AppendChild(item2);
                 picture.AppendChild(my_painting);
                //确定XML文档结构

                doc.Save(ApplicationData.Current.LocalFolder.Path + "/Pictures.xml");
            }

        //添加图册成员
        public void append(Picture pictureA,Picture pictureB, string picturename)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement pictures;
            if (File.Exists(ApplicationData.Current.LocalFolder.Path + "/Pictures.xml"))
            {
                
                doc.Load(ApplicationData.Current.LocalFolder.Path + "/Pictures.xml");
                 pictures= doc.DocumentElement;

            }
            else
            {
                Newxml();
                doc.Load(ApplicationData.Current.LocalFolder.Path + "/Pictures.xml");
                pictures = doc.CreateElement("Pictures");

            }

            //创建根节点 pictures

            XmlElement picture = doc.CreateElement(picturename);
            pictures.AppendChild(picture);

            XmlElement original_painting = doc.CreateElement(pictureA.picturename);
            picture.AppendChild(original_painting);
            XmlElement item1 = doc.CreateElement("Item1");
            item1.SetAttribute("path", pictureA.picturepath);
            original_painting.AppendChild(item1);

            XmlElement my_painting = doc.CreateElement(pictureB.picturename);
            XmlElement item2 = doc.CreateElement("Item2");
            item2.SetAttribute("path", pictureB.picturepath);
            my_painting.AppendChild(item2);
            picture.AppendChild(my_painting);
            //确定XML文档结构

            doc.Save(ApplicationData.Current.LocalFolder.Path + "/Pictures.xml");

        }
        //删除图册成员
        public void remove(string picturename)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(ApplicationData.Current.LocalFolder.Path + "/Pictures.xml");
            XmlNode docnode = doc.SelectSingleNode("/Pictures/" + picturename);
            docnode.ParentNode.RemoveChild(docnode);
            doc.Save(ApplicationData.Current.LocalFolder.Path + "/Pictures.xml");
        }

    }
}
