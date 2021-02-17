using System.Collections.Generic;
using WebApi1.Models;
using WebApi1.Interfaces;
using WebApi1.Data;

namespace WebApi1.Repositories
{
    public class PlanRepository : IPlan
    {
        private readonly ClientPlanContext _context;

        public PlanRepository(ClientPlanContext context)
        {
            _context = context;
        }
        void IPlan.DeletePlan(Plan plan)
        {
            throw new System.NotImplementedException();
        }

        Plan IPlan.GetPlan(long id)
        {
            throw new System.NotImplementedException();
        }

        List<Plan> IPlan.GetPlans()
        {
            throw new System.NotImplementedException();
        }

        void IPlan.PostPlan(Plan plan)
        {
            throw new System.NotImplementedException();
        }
    }
}
