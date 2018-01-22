using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonSample
{
    class Program
    {
        static void Main(string[] args)
        {
            // DT001020
            var people = new List<Person>
            {
                new Person
                {
                    Name = "이순신",
                    Natianality = "조선",
                    BirthYear = 1598,
                },

                new Person
                {
                    Name = "김유신",
                    Natianality = "신라",
                    BirthYear = 595,
                },

                new Person
                {
                    Name = "왕건",
                    Natianality = "고려",
                    BirthYear = 877,
                },
            };

            // DT001021
            var jsonStr = JsonConvert.SerializeObject(people, Formatting.Indented);
            Console.WriteLine($"jsonStr : {jsonStr}");

            // DT001022
            var people2 = JsonConvert.DeserializeObject<List<Person>>(jsonStr);
            Console.WriteLine($"people2.Count : {people2.Count}");
            Console.WriteLine($"people2[0].Name : {people2[0].Name}");
            Console.WriteLine($"people2[0].Age : {people2[0].Age}");

            Console.ReadLine();
        }
    }
}
