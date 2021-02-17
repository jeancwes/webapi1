using System;

namespace WebApi1.Models 
{
    class PlanNotFoundException : Exception
    {
        public PlanNotFoundException(string message)
        {
        }
    }
}
