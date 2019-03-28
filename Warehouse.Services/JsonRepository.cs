using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Warehouse.Models;
using Warehouse.Services.Abstract;

namespace Warehouse.Services
{
    public delegate void SendMessageDelegate(string message);

    public class JsonRepository<T> : IRepository<T>
    {
        public event SendMessageDelegate ReportEvent;

        public void Add(T entity)
        {
            var data = GetAll();
            data.Add(entity);

            using (var stream = File.Open("AllProducts.json", FileMode.OpenOrCreate))
            {
                string json = JsonConvert.SerializeObject(data);
                StreamWriter sw = new StreamWriter(stream);
                sw.Write(json);
                sw.Close();
                ReportEvent?.Invoke($"Товар добавлен");
            }
        }

        public void Delete(T entity)
        {
            var data = GetAll();
            data.Remove(entity);

            using (var stream = File.Open("AllProducts.json", FileMode.OpenOrCreate))
            {
                string json = JsonConvert.SerializeObject(data);
                StreamWriter sw = new StreamWriter(stream);
                sw.Write(json);
                sw.Close();
            }
        }

        public List<T> GetAll()
        {
            using (var stream = File.Open("AllProducts.json", FileMode.OpenOrCreate))
            {
                StreamReader sr = new StreamReader(stream);
                string json = sr.ReadToEnd();
               

                List<T> result = JsonConvert.DeserializeObject<List<T>>(json);
                if (stream.Length == 0)
                {
                    sr.Close();
                    return new List<T>();
                }
                sr.Close();
                return result;
            }
        }
    }
}
