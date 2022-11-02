using System;
using TravelPal.Models.Enums;

namespace TravelPal.Models.Travels
{
     public class Travel
    {
        public string destination { get; set; }

        public Country countries { get; set; }

        public int travellers { get; set; }

        // packinglist item

        public DateTime startDate { get; set; }

        public DateTime endDate { get; set; }

        public int travelDays { get; set; }

        public Travel(string destination, Country countries, int travellers, DateTime startDate, DateTime endDate, int travelDays)
        {
            this.destination = destination;
            this.countries = countries;
            this.travellers = travellers;
            this.startDate = startDate;
            this.endDate = endDate;
            this.travelDays = travelDays;
        }

        public virtual string GetInfo() // TODO Virtual get info VG
        {
            return this.destination + ", " + this.countries.ToString() + ", " + this.travellers + " travellers, Start date: " + startDate.ToString() + ", End date: " + endDate.ToString();
        }

        private int calculateTravelDays()
        {
            return (int)(endDate - startDate).TotalDays;

        }


    }
}
