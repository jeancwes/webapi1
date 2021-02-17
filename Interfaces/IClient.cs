using System.Collections.Generic;
using WebApi1.Models;

namespace WebApi1.Interfaces
{
    public interface IClient
    {
        List<Client> GetClients();
        Client GetClient(long id);
        void PostClient(Client client);
        void DeleteClient(Client client);
    }
}
