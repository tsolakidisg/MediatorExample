using System;
using System.Collections.Generic;

#nullable disable

namespace MediatorExample.Models
{
    public partial class Step
    {
        public string OrderType { get; set; }
        public int StepId { get; set; }
        public string StepDescription { get; set; }
        public object Payload { get; set; }
    }
}
