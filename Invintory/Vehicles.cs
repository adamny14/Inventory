using System;
using System.Collections.Generic;

namespace Invintory
{
    public partial class Vehicles
    {
        public long VehicleId { get; set; }
        public long ProductId { get; set; }
        public string Vin { get; set; }
        public long? MillageAtPurchase { get; set; }
        public string Type { get; set; }

        public Products Product { get; set; }
    }
}
