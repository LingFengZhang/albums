using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace albums.Models
{
    class Xmlfile
    {
        
        
            private void Newxml()
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
                original_painting.AppendChild(item2);
                 picture.AppendChild(my_painting);
                //确定XML文档结构

                doc.Save("Pictures.xml");
            }

        //添加图册成员
        public void append(Picture pictureA,Picture pictureB, string picturename)
        {
            XmlDocument doc = new XmlDocument();
            if (File.Exists("Knights.xml"))
            {
                Console.WriteLine("打开成功");
                doc.Load("Knights.xml");
            }
            else
            {
                XmlDeclaration dec = doc.CreateXmlDeclaration("1", "ufb - 8", null);
                doc.AppendChild(dec);
            }

            //创建根节点 pictures
            XmlElement pictures = doc.CreateElement("Pictures");
            doc.AppendChild(pictures);

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
            original_painting.AppendChild(item2);
            picture.AppendChild(my_painting);
            //确定XML文档结构

            doc.Save("Pictures.xml");

        }
        //删除图册成员
        public void remove(string picturename)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("Pictures.xml");
            XmlNode docnode = doc.SelectSingleNode("/Pictures/" + picturename);
            docnode.ParentNode.RemoveChild(docnode);
            doc.Save("Pictures.xml");
        }

    }
}
