using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sort_json_list
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Manager> managers = JsonConvert.DeserializeObject<List<Manager>>(File.ReadAllText("repo.json"));

            managers.Sort((a, b) => a.name.CompareTo(b.name));

            Console.WriteLine(
                Environment.NewLine,
                managers.Select(manager=> "id: " + manager.id + ", name: " + manager.name + ", mobile: " + manager.mobile)
            );

            // Pause
            Console.ReadKey();
        }
        class Manager
        {
            public string id { get; set; }
            public string name { get; set; }
            public string mobile { get; set; }
        }
    }
}
