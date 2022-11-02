using System;
using TravelPal.Models.Enums;

namespace TravelPal.Models.Travels
{
    public class Trip : Travel 
    {
        public TripType type { get; set; }

        public Trip(string destination, Country countries, int travellers, DateTime startDate, DateTime endDate, int travelDays, TripType type) : base(destination, countries, travellers, startDate, endDate, travelDays)
        {
            this.type = type;
        }

        public override string GetInfo() // base = används i basklassen "ifall man ärver eller inte"
        {
            return base.countries.ToString() + ", " + base.travellers + " travellers, Start date: " + startDate.ToString() + " , End date: " + endDate.ToString() + ", trip type: " + type;
        }
    }
}
