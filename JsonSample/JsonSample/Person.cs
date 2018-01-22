using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonSample
{
    // DT001010
    public class Person
    {
        public string Name { get; set; }
        public string Natianality { get; set; }
        public int BirthYear { get; set; }

        // DT001011
        [JsonIgnore]
        public int Age
        {
            get
            {
                var age = DateTime.Now.Year - this.BirthYear;
                return age;
            }
        }
    }
}
