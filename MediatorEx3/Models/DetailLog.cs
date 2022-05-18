using System;
using System.Collections.Generic;

#nullable disable

namespace MediatorExample.Models
{
    public partial class DetailLog
    {
        public string Guid { get; set; }
        public string OrderType { get; set; }
        public string Uuid { get; set; }
        public string Service { get; set; }
        public string EndSystem { get; set; }
        public string State { get; set; }
        public string Payload { get; set; }
        public DateTime Tmstamp { get; set; }
        public string LevelType { get; set; }
        public string Exception { get; set; }
        public string StackTrace { get; set; }

        public virtual HeadLog Gu { get; set; }
    }
}
