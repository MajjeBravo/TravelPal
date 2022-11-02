using System.Collections.Generic;


namespace TravelPal
{
    public class TravelManager
    {
        List<Models.Travels.Travel> travels = new();

        public void addTravel(Models.Travels.Travel travelToAdd)
        {
            travels.Add(travelToAdd);
        }

        public void removeTravel(Models.Travels.Travel travelToRemove)
        {
            travels.Remove(travelToRemove);
        }
    }
}
