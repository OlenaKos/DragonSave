using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DragonSave
{
    public class Person
    {
        [JsonProperty("login")]
        public string login { get; set; }

        [JsonProperty("password")]
        public string password { get; set; }


        public static void WritenFile(Person person)
        {
            person = File.Exists("person.json") ? JsonConvert.DeserializeObject<Person>(File.ReadAllText("person.json")) : new Person();
            File.WriteAllText("person.json", JsonConvert.SerializeObject(person));

            //string jsonDate = JsonConvert.SerializeObject(person);
            //var person2 = JsonConvert.DeserializeObject<Person>(jsonDate);

        }
    }
}
