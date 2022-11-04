using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelPal.Models.Enums;
using TravelPal.Models.PackingListItems;

namespace TravelPal.Models.Travels
{
    public class Vacation : Travel
    {

        public bool AllInclusive { get; set; }
        public Vacation(string destination, Country countries, int travellers, DateTime startDate, DateTime endDate, List<PackingListItem> packingList, bool AllInclusive) : base(destination, countries, travellers, startDate, endDate,packingList)
        {
            this.AllInclusive = AllInclusive;
        }

        public override string GetInfo() 
        {
            return base.destination + ", " + this.countries.ToString() + ", " + this.travellers + " travellers, Start date: " + startDate.ToString() + " , End date: " + endDate.ToString() + (AllInclusive ? " is All inclusive" : "");
        }
    }
}

