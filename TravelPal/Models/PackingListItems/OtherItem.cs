using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Models.Enums;

namespace TravelPal.Models.PackingListItems
{
    public class OtherItem : PackingListItem
    {
        public OtherItem(string name, int quantity)
        {
            this.Name = name;
            this.Quantity = quantity;
        }


        public string Name { get; set; }
        public int Quantity { get; set; }

        public string GetInfo()
        {
            return Quantity + " of " + Name;
        }

        public override string ToString()
        {
            return GetInfo();
        }
    }
}
