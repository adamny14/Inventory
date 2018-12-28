using System;
using System.Collections.Generic;

namespace Invintory
{
    public partial class Movies
    {
        public long MovieId { get; set; }
        public long ProductId { get; set; }
        public string Director { get; set; }
        public string Medium { get; set; }
        public string Serial { get; set; }
        public int? RunTimeMin { get; set; }

        public Products Product { get; set; }
    }
}
