using System;
using System.Data.Common;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using WebApi1.Models;
using WebApi1.Interfaces;
using WebApi1.Data;

namespace WebApi1.Repositories
{
    public class ClientRepository : IClient
    {
        private readonly ClientPlanContext _context;

        public ClientRepository(ClientPlanContext context)
        {
            _context = context;
        }

        void IClient.DeleteClient(Client client)
        {
            _context.Clients.Remove(client);
        }

        Client IClient.GetClient(long id)
        {
            return _context.Clients.Find(id);
        }

        List<Client> IClient.GetClients()
        {
            return _context.Clients
                .Include(c => c.Plans)
                .ThenInclude(cp => cp.Plan)
                .ToList();
        }

        void IClient.PostClient(Client client)
        {
            client.RegisterDate = DateTime.UtcNow;

            if (client.isLegalPerson())
            {
                client.BornDate = DateTime.MinValue;
            }

            if (!client.isValidBornDate())
            {
                throw new ClientBornDateInvalidException("ClientBornDateInvalidException");
            }

            if (!client.isValidRg())
            {
                throw new ClientRgInvalidException("ClientRgInvalidException");
            }

            var plans = new List<ClientPlan>();

            foreach (var p in client.Plans)
            {
                var plan = _context.Plans.Find(p.PlanId);

                if (plan == null)
                {
                    throw new PlanNotFoundException("PlanNotFoundException");
                }

                if (!client.isValidPlanEndEffectiveDate(plan))
                {
                    throw new PlanEndEffectiveDateInvalidException("PlanEndEffectiveDateInvalidException");
                }

                plans.Add(
                    new ClientPlan
                    {
                        ClientId = client.Id,
                        Client = client,
                        PlanId = plan.Id,
                        Plan = plan,
                        BondDate = DateTime.UtcNow
                    }
                );
            }

            client.Plans = plans;

            _context.Clients.Add(client);
        }
    }
}
