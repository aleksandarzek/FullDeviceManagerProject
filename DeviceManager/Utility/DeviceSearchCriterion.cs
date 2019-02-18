using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManager.Utility
{
    public class DeviceSearchCriterion
    {
        public DeviceSearchCriterion()
        {
            //default values
            Name = "";
            TypeDevice = "";
            PageNumRes = 1;
            DeviceNumOnThisPage = 10;
            DeviceValues = "";
            DateTimeGreatThan = DateTime.MinValue;
            DateTimeGreatOrEqThan = DateTime.MinValue;
            DateTimeLessThan = DateTime.MaxValue;
            DateTimeLessOrEqThan = DateTime.MaxValue;
            PriceGreatOrEqThan = Decimal.MinValue;
            PriceGreatThan = Decimal.MinValue;
            PriceLessOrEqThan = Decimal.MaxValue;
            PriceLessThan = Decimal.MaxValue;
        }
        public string Name { get; set; }

        public string TypeDevice { get; set; }

        public int PageNumRes { get; set; }

        public string DeviceValues { get; set; }

        public int DeviceNumOnThisPage { get; set; }

        public DateTime DateTimeGreatThan { get; set; }

        public DateTime DateTimeLessThan { get; set; }

        public DateTime DateTimeGreatOrEqThan { get; set; }

        public DateTime DateTimeLessOrEqThan { get; set; }

        public decimal PriceGreatThan { get; set;}

        public decimal PriceLessThan { get; set; }

        public decimal PriceGreatOrEqThan { get; set; }

        public decimal PriceLessOrEqThan { get; set; }

    }
}
