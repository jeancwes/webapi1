using System.Collections.Generic;
using WebApi1.Models;

namespace WebApi1.Interfaces
{
    public interface IPlan
    {
        List<Plan> GetPlans();
        Plan GetPlan(long id);
        void PostPlan(Plan plan);
        void DeletePlan(Plan plan);
    }
}
