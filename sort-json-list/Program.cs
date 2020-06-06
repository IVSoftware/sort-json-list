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
            Example_ListOfDictionary();
            Console.WriteLine();
            Example_ListOfManager();
            Console.WriteLine();
            Example_ArrayOfManager();
            Console.WriteLine();

            // Pause
            Console.ReadKey();
        }

        private static void Example_ListOfDictionary()
        {
            var managers = JsonConvert.DeserializeObject<List<Dictionary<string,string>>>(File.ReadAllText("repo.json"));

            var sorted = managers.ToList();
            sorted.Sort((a, b) => a["name"].CompareTo(b["name"]));

            Console.WriteLine(
                string.Join(
                    Environment.NewLine,
                    sorted.Select(manager => manager["id"] + "," + manager["name"] + "," + manager["mobile"]))
            );
        }

        private static void Example_ListOfManager()
        {
            var managers = JsonConvert.DeserializeObject<List<Manager>>(File.ReadAllText("repo.json"));

            managers.Sort((a, b) => a.name.CompareTo(b.name));

            Console.WriteLine(
                string.Join(
                    Environment.NewLine,
                    managers.Select(manager => manager.id + "," + manager.name + "," + manager.mobile))
            );

            bool isManagerEnumerable = managers is IEnumerable<Manager>;

            // Prove that the serialization is identical
            File.WriteAllText("serializeList.json", JsonConvert.SerializeObject(managers));

            // NOTE: But what if it's an array?
            var managersA = JsonConvert.DeserializeObject<Manager[]>(File.ReadAllText("repo.json"));
            // Then we must cast ToList() first before it will compile:
            managersA.ToList().Sort((a, b) => a.name.CompareTo(b.name));
        }

        private static void Example_ArrayOfManager()
        {
            // NOTE: But what if it's an array?
            var managers = JsonConvert.DeserializeObject<Manager[]>(File.ReadAllText("repo.json"));

            var sorted = managers.ToList();
            sorted.Sort((a, b) => a.name.CompareTo(b.name));

            Console.WriteLine(
                string.Join(
                    Environment.NewLine,
                    sorted.Select(manager => manager.id + "," + manager.name + "," + manager.mobile))
            );

            bool isManagerEnumerable = sorted is IEnumerable<Manager>;

            // Prove that the serialization is identical
            File.WriteAllText("serializeArray.json", JsonConvert.SerializeObject(sorted));
        }

        class Manager
        {
            public string id { get; set; }
            public string name { get; set; }
            public string mobile { get; set; }
        }
    }
}
