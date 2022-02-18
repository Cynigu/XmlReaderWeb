using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace Computing
{
    // var paths = Directory.EnumerateFiles(@PathFolder, "*.xml");

    public class XmlReader
    {
        /// <summary>
        /// Получить кол-во объектов каждого xml файла в папке
        /// </summary>
        /// <param name="paths"> Путь к папке </param>
        /// <returns></returns>
        public static int GetCountObjectForFolder(string[] paths)
        {
            int countObject = 0;
            foreach (string path in paths)
            {
                countObject += GetCountObjectForOneXmlFile(path);
            }
            return countObject;
        }
        /// <summary>
        /// Получить кол-во объектов в одном файле 
        /// </summary>
        /// <param name="filename"> Путь к xml файлу </param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static int GetCountObjectForOneXmlFile(string filename)
        {
            if (filename == null || filename == "")
            {
                throw new ArgumentException();
            }

            XDocument xdoc = XDocument.Load(filename);
            int countObject = 0;
            // получим корневой элемент
            var objects = xdoc.Element("annotation")?.Elements("object");
            if (objects == null)
            {
                return countObject;
            }

            foreach (XElement ob in objects)
            {
                countObject++;
            }

            return countObject;
        }
    }
}
