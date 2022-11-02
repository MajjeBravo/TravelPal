using System;

using System.Threading.Tasks;
using TravelPal.Models.Enums;

namespace TravelPal.Models.Travels
{
    internal class Vacation : Travel
    {

        public bool AllInclusive { get; set; }
        public Vacation(string destination, Country countries, int travellers, DateTime startDate, DateTime endDate, int travelDays, bool AllInclusive) : base(destination, countries, travellers, startDate, endDate, travelDays)
        {
            this.AllInclusive = AllInclusive;
        }

        public override string GetInfo() 
        {
            return this.countries.ToString() + ", " + this.travellers + " travellers, Start date: " + startDate.ToString() + " , End date: " + endDate.ToString() + (AllInclusive ? " is All inclusive" : "");
        }
    }
}

