using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS2_FrizerskiSalon.Configuration
{
    public class AppSettings
    {
        #nullable enable
        public string? Secret { get; set; }
        public string? Issuer { get; set; }
        public int TokenDuration { get; set; }
    }
}
