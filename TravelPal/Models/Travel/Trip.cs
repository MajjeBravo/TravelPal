using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Models.Enums;

namespace TravelPal.Models.Travel
{
    internal class Trip : Travel 

    {
        public TripType type { get; set; }
        public Trip(string destination, Country countries, int travellers, DateTime startDate, DateTime endDate, int travelDays, TripType type) : base(destination, countries, travellers, startDate, endDate, travelDays)
        {
            this.type = type;
        }

        public override string GetInfo() // Varför till vad?
        {
            return this.countries.ToString() + ", " + this.travellers + " travellers, Start date: " + startDate.ToString() + " , End date: " + endDate.ToString() + ", trip type: " + type;
        }
    }
}
