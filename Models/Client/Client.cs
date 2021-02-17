using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi1.Models
{
    public class RequiredNaturalPersonRg : ValidationAttribute
    {
        public string GetErrorMessage() => "Pessoa física deve possuir RG.";

        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            var client = (Client)validationContext.ObjectInstance;
            
            if (
                client.CpfCnpj.Length == 11 && 
                (client.Rg == null || client.Rg.ToString() == "")
            ) 
            {
                return new ValidationResult(GetErrorMessage());
            }
            return ValidationResult.Success;
        }
    }

    public class RequiredNaturalPersonBornDate : ValidationAttribute
    {
        public string GetErrorMessage() => "Pessoa física deve possuir data de nascimento.";

        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            var client = (Client)validationContext.ObjectInstance;

            if (
                client.CpfCnpj.Length == 11 && 
                client.BornDate.ToString() == "01/01/0001 00:00:00"
            ) 
            {
                return new ValidationResult(GetErrorMessage());
            }
            return ValidationResult.Success;
        }
    }

    public class Client
    {
        public long Id { get; set; }
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        [Required]
        [MinLength(11)]
        [MaxLength(14)]
        public string CpfCnpj { get; set; }
        [RequiredNaturalPersonRg]
        public string Rg { get; set; }
        [RequiredNaturalPersonBornDate]
        public DateTime BornDate { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public DateTime RegisterDate { get; set; }
        public ICollection<ClientPlan> Plans { get; set; }

        public bool isLegalPerson() {
            if (CpfCnpj.Length == 14)
            {
                return true;
            }
            return false;
        }

        public bool isValidBornDate() 
        {
            if (isLegalPerson())
            {
                return true;
            }
            if (BornDate.Date < DateTime.UtcNow.Date)
            {
                return true;
            }
            return false;
        }

        public bool isValidPlanEndEffectiveDate(Plan plan) 
        {
            if (RegisterDate.Date <= plan.EndEffectiveDate.Date)
            {
                return true;
            }
            return false;
        }

        public bool isValidRg() 
        {
            if (isLegalPerson() && Rg == "")
            {
                return true;
            }
            if (!isLegalPerson() && Rg != "")
            {
                return true;
            }
            return false;
        }
    }
}
