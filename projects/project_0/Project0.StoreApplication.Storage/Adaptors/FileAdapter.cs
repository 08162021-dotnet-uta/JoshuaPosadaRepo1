using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Abstracts;

namespace Project0.StoreApplication.Storage
{
  public class FileAdapter
  {
    //  public List<Store> ReadFromFile()
    // public T ReadFromFile<T>(string path) where T : class
    // {
    //   if (!File.Exists(path))
    //   {
    //     return null;
    //   }

    //   // //file path
    //   // string path = @"/home/joshua/revature/fred_repo/data/project_0.xml";
    //   // //open file
    //   var file = new StreamReader(path);
    //   // //serialize object
    //   // var xml = new XmlSerializer(typeof(List<Store>));
    //   //var x= datatype.GetType();
    //   var xml = new XmlSerializer(typeof(T));
    //   // //write to file
    //   // var stores = xml.Deserialize(file) as List<Store>;
    //   //var result = xml.Deserialize(file) as List<F>;
    //   var result = xml.Deserialize(file) as T;
    //   //return data
    //   return result;
    // }
    public List<T> ReadFromFile<T>(string path) where T : class
    {
      if (!File.Exists(path))
      {
        return null;
      }

      var file = new StreamReader(path);
      var xml = new XmlSerializer(typeof(List<T>));
      var result = xml.Deserialize(file) as List<T>;

      return result;
    }
    public void WriteToFile<T>(string path, List<T> data) where T : class
    {
      var writer = new StreamWriter(path);
      var xml = new XmlSerializer(typeof(List<T>));
      xml.Serialize(writer, data);
    }
    //public void WriteToFile(List<Store> stores)
    // public F WriteToFile<F>(string path, F data) where F : class
    // {
    // var file = new StreamWriter(path);

    // var xml = new XmlSerializer(typeof(F));

    // var result = xml.Serialize(file, data) as F;
    // return result;


    // //file path 
    // string path = @"/home/joshua/revature/fred_repo/data/project_0.xml";
    // //open file
    // var file = new StreamWriter(path);
    // //serialize object
    // var xml = new XmlSerializer(typeof(List<Store>));
    // //write to file
    // xml.Serialize(file, stores);
    // }
  }
}