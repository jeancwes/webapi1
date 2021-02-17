using System.Collections.Generic;
using WebApi1.Models;

namespace WebApi1.Interfaces
{
    public interface IClientPlan
    {
        IClient Client { get; }
        IPlan Plan { get; }
        void SaveChanges();
    }
}
