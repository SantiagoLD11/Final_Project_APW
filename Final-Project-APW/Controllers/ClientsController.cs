using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using Final_Project_APW.DAL.Entities;
using Final_Project_APW.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace Final_Project_APW.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class ClientsController : Controller
    {
        private readonly IClientService _clientService;
        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet, ActionName("Get")]
        [Route("Get")] //Aquí concateno la URL inicial: URL = api/hotels/get
        public async Task<ActionResult<IEnumerable<Client>>> GetClientsAsync()
        {
            var clients = await _clientService.GetClientsAsync(); 

            if (clients == null || !clients.Any())
            {
                return NotFound(); //NotFound = 404 Http Status Code
            }

            return Ok(clients); //Ok = 200 Http Status Code
        }

        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult> CreateClientAsync(Client client)
        {
            try
            {
                var createdClient = await _clientService.CreateClientAsync(client);

                if (createdClient == null)
                {
                    return NotFound(); //NotFound = 404 Http Status Code
                }

                return Ok(createdClient); //Retorne un 200 y el objeto Country
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                {
                    return Conflict(String.Format("El Client {0} ya existe.", client.NumDoc)); //Confilct = 409 Http Status Code Error
                }

                return Conflict(ex.Message);
            }
        }

        [HttpGet, ActionName("Get")]
        [Route("GetById/{id}")] //URL
        public async Task<ActionResult<Client>> GetClientByIdAsync(Guid id)
        {
            if (id == null) return BadRequest("Id es requerido!");

            var client = await _clientService.GetClientByIdAsync(id);

            if (client == null) return NotFound(); // 404

            return Ok(client); // 200
        }

        [HttpPut, ActionName("Edit")]
        [Route("Edit")]
        public async Task<ActionResult<Client>> EditHotelStarsByIdAsync(Client client)
        {
            try
            {
              var editedClient = await _clientService.EditClientAsync(client);

                if (editedClient == null) return NotFound(); // 404

                return Ok(editedClient);

            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpDelete, ActionName("Delete")]
        [Route("Delete")]
        public async Task<ActionResult<Client>> DeleteCountryAsync(Guid id)
        {
            if (id == null) return BadRequest("Id es requerido!");

            var deletedClient = await _clientService.DeleteClientByIdAsync(id);

            if (deletedClient == null) return NotFound("Cliente no encontrado!");

            return Ok(deletedClient);
        }
    }
}