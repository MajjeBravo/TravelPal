using System;
using System.Collections.Generic;
using TravelPal.Models.Enums;
using TravelPal.Models.PackingListItems;

namespace TravelPal.Models.Travels
{
    public class Trip : Travel 
    {
        public TripType type { get; set; }

        public Trip(string destination, Country countries, int travellers, DateTime startDate, DateTime endDate, List<PackingListItem> packingList, TripType type) : base(destination, countries, travellers, startDate, endDate, packingList)
        {
            this.type = type;
        }

        public override string GetInfo() // base = används i basklassen "ifall man ärver eller inte"
        {
            return base.destination + ", " + base.countries.ToString() + ", " + base.travellers + " travellers, Start date: " + startDate.ToString("dd/MM/yyyy") + " , End date: " + endDate.ToString("dd/MM/yyyy") + ", trip type: " + type;
        }
    }
}
