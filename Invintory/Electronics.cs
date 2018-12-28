using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace Invintory
{
    public partial class Electronics
    {
        public long ElectronicsId { get; set; }
        public long ProductId { get; set; }
        public string Type { get; set; }
        public long? StorageGb { get; set; }
        public PhysicalAddress MacAddrs { get; set; }
        public string Accessories { get; set; }

        public Products Product { get; set; }
    }
}
