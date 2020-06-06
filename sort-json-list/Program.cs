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
            Example_ManagerIsClass();
            Console.WriteLine();
            Example_ManagerIsClassIsObject();

            // Pause
            Console.ReadKey();
        }

        private static void Example_ManagerIsClassIsObject()
        {
            var managers = JsonConvert.DeserializeObject<Dictionary<string,string>[]>(File.ReadAllText("repo.json"));

            managers.ToList().Sort((a, b) => a["name"].CompareTo(b["name"]));

            Console.WriteLine(
                string.Join(
                    Environment.NewLine,
                    managers.Select(manager => manager["id"] + "," + manager["name"] + "," + manager["mobile"]))
            );
        }

        private static void Example_ManagerIsClass()
        {
            var managers = JsonConvert.DeserializeObject<List<Manager>>(File.ReadAllText("repo.json"));

            managers.Sort((a, b) => a.name.CompareTo(b.name));

            Console.WriteLine(
                string.Join(
                    Environment.NewLine,
                    managers.Select(manager => manager.id + "," + manager.name + "," + manager.mobile))
            );

            File.WriteAllText("repoCopy.json", JsonConvert.SerializeObject(managers));
        }

        class Manager
        {
            public string id { get; set; }
            public string name { get; set; }
            public string mobile { get; set; }
        }
    }
}
