using System;
using System.Collections.Generic;
using TravelPal.Models.Enums;
using TravelPal.Models.PackingListItems;
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
        public int travelDays
        {
            get => CalculateTravelDays();
        }

        public List<PackingListItem> PackingList { get; set; }

        public Travel(string destination, Country countries, int travellers, DateTime startDate, DateTime endDate, List<PackingListItem> packingList)
        {
            this.destination = destination;
            this.countries = countries;
            this.travellers = travellers;
            this.startDate = startDate;
            this.endDate = endDate;
            this.PackingList = packingList;
        }

        public virtual string GetInfo() 
        {
            return this.destination + ", " + this.countries.ToString() +" "+CalculateTravelDays()+" days";
        }

        private int CalculateTravelDays()
        {
            return (int)(endDate - startDate).TotalDays+1;

        }

    }
}
