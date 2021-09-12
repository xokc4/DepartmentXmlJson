using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DepartmentXmlJson
{
    public class WorkingFiles
    {

        /// <summary>
        /// В SerializeXml происходит сериализация в Xml
        /// </summary>
        /// <param name="сompany"> класс компании</param>
        /// <param name="path">путь к файлу</param>
        public static void SerializeXml(List<Сompany> сompany, string path)// сериализация в Xml
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Сompany>));// создания  сериализация в Xml

            Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write);// создания потока

            xmlSerializer.Serialize(stream, сompany);// запуск сериализации

            stream.Close();// закрытие потока
        }
        /// <summary>
        /// В DeserializeXml происходит десериализации Xml
        /// </summary>
        /// <param name="path">путь к файлу </param>
        /// <returns></returns>
        public static List<Сompany> DeserializeXml(string path)// десериализации Xml
        {

            List<Сompany> сompany = new List<Сompany>();

            // создания сериализации для листа
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Сompany>));

            Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read);// создания потока

            сompany = xmlSerializer.Deserialize(stream) as List<Сompany>;//десериализация

            stream.Close();// закрытие потока

            return сompany;


        }
        /// <summary>
        /// В serializeJson происходит  сериализации Json файла 
        /// </summary>
        /// <param name="psth">путь к файлу </param>
        /// <param name="сompany"> класс компании</param>
        public static void serializeJson(string psth, List<Сompany> сompany)// сериализации в Json
        {
            string json = JsonConvert.SerializeObject(сompany);// создания сериализации
            File.WriteAllText(@"C:\Новая папка\serealize.Json", json);// запись

        }
        /// <summary>
        /// В DeserializeJson происходит десериализации Json файла
        /// </summary>
        /// <param name="psth"> путь к файлу</param>
        /// <returns></returns>
        public static List<Сompany> DeserializeJson(string psth)//десериализации Json
        {
            List<Сompany> сompanies = new List<Сompany>();
            string json = File.ReadAllText(psth);// открытие папки
            сompanies = JsonConvert.DeserializeObject<List<Сompany>>(json);//десериализация
            return сompanies;// вывод листа
        }
    }
}
