using DemoDapperApi.Models;
using DemoDapperApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoDapperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        
         // GET: api/<ClienteController>
         [HttpGet]
        public ActionResult<IEnumerable<Cliente>> Get()
        {
            var clienteService = new ClientServices();
            {
                var cliente = clienteService.GetClients();
                if (cliente != null)
                {
                    return Ok(cliente);
                }
                return NotFound("Mensaje: There is not clients");
            }
        } 
        [HttpGet]
        [Route("ASYNC")]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetAsync()
        {
            var clienteService = new ClientServices();
            {
                var cliente = await clienteService.GetClientsAsync();
                if (cliente != null)
                {
                    return Ok(cliente);
                }
                return NotFound("Mensaje: There is not clients");
            }
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public ActionResult<Cliente> Get(int id)
        {
            var clienteService = new ClientServices();
            {
                var cliente = clienteService.GetClientById(id);
                if (cliente != null)
                {
                    return Ok(cliente);
                }
                return NotFound("Mensaje: There is not client with id:" + id);
            }
         }

        // POST api/<ClienteController>
        [HttpPost]
        public void Post([FromBody] Cliente cliente)
        {
            var clienteService = new ClientServices();
            {
                clienteService.AddClientWithSavePointManyContext(cliente);

            }
        }

        // POST api/cliente/async
        [HttpPost]
        [Route("ASYNC")]
        public async Task PostAsync([FromBody] Cliente cliente)
        {
            try
            {
                var clienteServices = new ClientServices();
                {
                    cliente.id = 0;
                    await clienteServices.AddClientAsync(cliente);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Cliente cliente)
        {
            try
            {
                var clienteService = new ClientServices();
                {
                    cliente.id = id;
                    clienteService.UpdateClient(cliente, true);
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        // PUT api/cliente/id
        [HttpPut("Update/{id}")]
        public void UpdateClient(int id, [FromBody] Cliente cliente)
        {
            try
            {
                var clienteService = new ClientServices();
                {
                    cliente.id = id;
                    clienteService.UpdateClientDML(cliente);
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
