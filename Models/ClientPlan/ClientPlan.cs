using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi1.Models
{
    public class ClientPlan
    {
        public long ClientId { get; set; }
        public Client Client { get; set; }
        public long PlanId { get; set; }
        public Plan Plan { get; set; }
        public DateTime BondDate { get; set; }
    }
}
