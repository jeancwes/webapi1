using System.Collections.Generic;
using WebApi1.Models;
using WebApi1.Interfaces;
using WebApi1.Data;

namespace WebApi1.Repositories
{
    public class ClientPlanRepository : IClientPlan
    {
        private readonly ClientPlanContext _context;
        private ClientRepository _clientRepository;
        private PlanRepository _planRepository;

        public ClientPlanRepository(ClientPlanContext context)
        {
            _context = context;
        }
        IClient IClientPlan.Client { 
            get {
                return _clientRepository = 
                    _clientRepository ?? new ClientRepository(_context);
            }
        }
        IPlan IClientPlan.Plan { 
            get {
                return _planRepository = 
                    _planRepository ?? new PlanRepository(_context);
            }
        }

        void IClientPlan.SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
