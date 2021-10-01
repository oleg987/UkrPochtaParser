using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UkrPochtaParser
{
    class Country
    {
        public string Name { get; }
        public List<string> Tariffs { get; } = new List<string>();

        public Country(string name)
        {
            this.Name = name;
        }
    }
}