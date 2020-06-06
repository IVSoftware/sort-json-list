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
            var managers = JsonConvert.DeserializeObject(File.ReadAllText("repo.json"));

            // We know from info given that 'managers' will 
            // cast to List of <KeyValuePair<string,string>>[] i.e. Array of KeyValuePair
            
            ((List<Dictionary<string, string>>)managers).Sort((a, b) => a["name"].CompareTo(b["name"]));



            string display = string.Join(
                Environment.NewLine,
                ((List<Dictionary<string, string>>)managers)
                .Select(manager =>
                    string.Join(
                        ",", 
                        ((KeyValuePair<string,string>[])manager).Select(kvp =>kvp.Value))
                );


            List<Manager> managerList = JsonConvert.DeserializeObject<List<Manager>>(File.ReadAllText("repo.json"));

            managerList.Sort((a, b) => a.name.CompareTo(b.name));

            Console.WriteLine(
                string.Join(
                    Environment.NewLine,
                    managerList.Select(manager => manager.id + "," + manager.name + "," + manager.mobile))
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
