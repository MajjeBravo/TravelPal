using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Models.Travel;

namespace TravelPal
{
    internal class TravelManager
    {
        List<Travel> travels = new();

        public void addTravel(Travel travelToAdd)
        {
            travels.Add(travelToAdd);
        }

        public void removeTravel(Travel travel)
        {
            //TODO
        }
    }
}
