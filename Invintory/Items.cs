using System;
using System.Collections.Generic;

namespace Invintory
{
    public partial class Items
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime? DatePurchased { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }
        public byte[] Photo { get; set; }
        public string Color { get; set; }
        public string Company { get; set; }
        public string Serial { get; set; }
        public string AdditionalData { get; set; }
    }
}
