using System;
using System.Collections.Generic;

#nullable disable

namespace MediatorExample.Models
{
    public partial class HeadLog
    {
        public string Guid { get; set; }
        public string OrderId { get; set; }
        public string OrderType { get; set; }
        public string OrderStatus { get; set; }
        public DateTime Tmstamp { get; set; }
    }
}
