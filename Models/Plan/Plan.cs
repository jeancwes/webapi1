using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi1.Models
{
    public class Plan
    {
        public long Id { get; set; }
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        [Required]
        public bool PermitLegalPerson { get; set; }
        [Required]
        public DateTime StartEffectiveDate { get; set; }
        [Required]
        public DateTime EndEffectiveDate { get; set; }
        [Required]
        public DateTime RegisterDate { get; set; }
        public ICollection<ClientPlan> Clients { get; set; }
    }
}
