using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPal.Models.PackingListItems
{
    public interface PackingListItem
    {
        string Name { get; set; }

        string GetInfo();
    }
}
