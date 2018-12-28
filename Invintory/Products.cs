using System;
using System.Collections.Generic;

namespace Invintory
{
    public partial class Products
    {
        public Products()
        {
            Books = new HashSet<Books>();
            Electronics = new HashSet<Electronics>();
            Movies = new HashSet<Movies>();
            Vehicles = new HashSet<Vehicles>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime? DatePurchased { get; set; }
        public int? Quantity { get; set; }
        public string Type { get; set; }
        public byte[] Photo { get; set; }
        public string Color { get; set; }
        public string Company { get; set; }

        public ICollection<Books> Books { get; set; }
        public ICollection<Electronics> Electronics { get; set; }
        public ICollection<Movies> Movies { get; set; }
        public ICollection<Vehicles> Vehicles { get; set; }
    }
}
