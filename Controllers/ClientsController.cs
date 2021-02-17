using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi1.Models;
using WebApi1.Data;
using WebApi1.Interfaces;
using WebApi1.Repositories;

namespace WebApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientPlan _clientPlan;

        public ClientsController(IClientPlan clientPlan)
        {
            _clientPlan = clientPlan;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Client>> GetClients()
        {
            return _clientPlan.Client.GetClients();
        }

        [HttpGet("{id}")]
        public ActionResult<Client> GetClient(long id)
        {
            var client = _clientPlan.Client.GetClient(id);

            if (client == null)
            {
                return NotFound();
            }

            return client;
        }

        [HttpPut("{id}")]
        public IActionResult PutClient(long id, Client client)
        {
            return NoContent();
        }

        [HttpPost]
        public ActionResult<Client> PostClient(Client client)
        {
            try
            {
                _clientPlan.Client.PostClient(client);

                _clientPlan.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(
                    new HttpResponseMessage(HttpStatusCode.BadRequest) { 
                        ReasonPhrase = e.Message
                    }
                );
            }

            return CreatedAtAction("GetClient", new { id = client.Id }, client);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteClient(long id)
        {
            var client = _clientPlan.Client.GetClient(id);

            if (client == null)
            {
                return NotFound();
            }

            _clientPlan.Client.DeleteClient(client);

            _clientPlan.SaveChanges();

            return NoContent();
        }
    }
}
