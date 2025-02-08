using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OticaCrista.Models;
using OticaCrista.Repositories;

namespace OticaCrista.Controllers
{
    [Route("api/clients")]
    [ApiController]
    [Authorize]
    public class ClientController : ControllerBase
    {
        private readonly ClientRepository _clientRepository;

        public ClientController(ClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int skip = 0, int take = 10)
        {
            var clients = await _clientRepository.GetAllAsync(skip, take);
            return Ok(clients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var client = await _clientRepository.GetByIdAsync(id);
            if (client == null)
                return NotFound(new { message = "Client not found" });

            return Ok(client);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ClientModel client)
        {
            var createdClient = await _clientRepository.AddAsync(client);
            return CreatedAtAction(nameof(GetById), new { id = createdClient.Id }, createdClient);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ClientModel client)
        {
            if (id != client.Id)
                return BadRequest(new { message = "Client ID mismatch" });

            var updatedClient = await _clientRepository.UpdateAsync(client);
            if (updatedClient == null)
                return NotFound(new { message = "Client not found" });

            return Ok(updatedClient);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _clientRepository.DeleteAsync(id);
            if (!deleted)
                return NotFound(new { message = "Client not found" });

            return NoContent();
        }
    }
}
