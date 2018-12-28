using System;
using System.Collections.Generic;

namespace Invintory
{
    public partial class Books
    {
        public long BookId { get; set; }
        public long ProductId { get; set; }
        public string Isbn { get; set; }
        public string Author { get; set; }
        public DateTime? CopyRightDate { get; set; }
        public string Publisher { get; set; }

        public Products Product { get; set; }
    }
}
