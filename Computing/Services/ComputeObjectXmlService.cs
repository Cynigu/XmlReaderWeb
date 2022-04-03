using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using XmlReader.BLL.Models.Models;
using XmlReader.BLL.Service.Interfaces;

namespace XmlReader.BLL.Service.Services
{
    public class ComputeObjectXmlService: IComputeObjectXmlService
    {
        public FolderInfo GetFolderInfoXml(string pathFolder, float bet)
        {
            var paths = Directory.EnumerateFiles(@pathFolder, "*.xml");
            FolderInfo folderInfo = new FolderInfo
            {
                Bet = bet,
                FolderPath = pathFolder
            };
            var pathsArray = paths as string[] ?? paths.ToArray();

            if (!pathsArray.Any())
            {
                folderInfo.CountObject = 0;
                folderInfo.CountXmlFile = 0;
                folderInfo.Salary = 0;
                return folderInfo;
            }

            folderInfo.CountXmlFile = pathsArray.Count();
            folderInfo.CountObject = GetCountObjectForFolder(pathsArray);
            folderInfo.Salary = ComputeSalary(folderInfo.CountObject, bet);

            return folderInfo;
        }

        private static float ComputeSalary(int countObject, float betForObject)
        {
            return countObject * betForObject;
        }
        /// <summary>
        /// Получить кол-во объектов каждого xml файла в папке
        /// </summary>
        /// <param name="paths"> Путь к файлам </param>
        /// <returns></returns>
        private static int GetCountObjectForFolder(string[] paths)
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
        private static int GetCountObjectForOneXmlFile(string filename)
        {
            if (string.IsNullOrEmpty(filename))
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
