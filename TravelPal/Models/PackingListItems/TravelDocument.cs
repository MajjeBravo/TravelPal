using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Models.Enums;

namespace TravelPal.Models.PackingListItems
{
    public class TravelDocument : PackingListItem
    {
        public TravelDocument(string name, bool required)
        {
            this.Name = name;
            this.Required = required;
        }


        public string Name { get; set; }
        public bool Required { get; set; }

        public string GetInfo()
        {
            return Name + " " + (Required ? "(Required)" : "(Not Required)");
        }

        public override string ToString()
        {
            return GetInfo();
        }
    }
}
