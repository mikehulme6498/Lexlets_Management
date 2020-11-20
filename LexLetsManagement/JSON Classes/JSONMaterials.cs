using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexLetsManagement
{
    class JSONMaterials
    {
        static private List<JSONMaterials> LowLevelStock = new List<JSONMaterials>();
        public int Id { get; set; }
        public string Category { get; set; }
        public string Colour { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int LowLevelAlarm { get; set; }
        public int UsedIn { get; set; }

        public JSONMaterials(int id, string category, string colour, string description, int quantity, int lowLevelAlarm, int usedIn)
        {
            Id = id;
            Category = category;
            Colour = colour;
            Description = description;
            Quantity = quantity;
            LowLevelAlarm = lowLevelAlarm;
            UsedIn = usedIn;
            LowLevelStock.Add(this);
        }

        static public List<JSONMaterials> GetAllLowLevelStock()
        {
            return LowLevelStock;
        }

    }
}
