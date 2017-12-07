using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AQACommute.Models
{
    public class TransportCommuteViewModel
    {
        public Commute commute { get; set; }
        public TransportMethod transportMethod { get; set; }

    }
}