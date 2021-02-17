using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi1.Models
{
    public class RangeBondDate : ValidationAttribute
    {
        public string GetErrorMessage() => "Data de vínculo deve ser menor que data final do plano.";

        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            var clientPlan = (ClientPlan)validationContext.ObjectInstance;

            Console.WriteLine(clientPlan.Plan);
            // Console.WriteLine(clientPlan.BondDate);
            // Console.WriteLine(value.ToString());
            
            // if (DateTime.Compare(
            //         clientPlan.Plan.EndEffectiveDate, 
            //         clientPlan.BondDate
            //     ) < 0) 
            // {
            //     return new ValidationResult(GetErrorMessage());
            // }
            return ValidationResult.Success;
        }
    }

    public class ClientPlan
    {
        public long ClientId { get; set; }
        public Client Client { get; set; }
        public long PlanId { get; set; }
        public Plan Plan { get; set; }
        [RangeBondDate]
        public DateTime BondDate { get; set; }
    }
}
