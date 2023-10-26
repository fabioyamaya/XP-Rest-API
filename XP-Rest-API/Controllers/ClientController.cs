using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using XP_Rest_API.Models;
using XP_Rest_API.Models.DTO;
using XP_Rest_API.Repositories;

namespace XP_Rest_API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _repository;
        private readonly IMapper _mapper;
        public ClientController(IClientRepository clientRepository, IMapper mapper)
        {
            _repository = clientRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Client>>> GetAllClients()
        {
            var clients = await _repository.GetAllClientsAsync();

            if (clients == null || clients.Count == 0)
            {
                return NotFound();
            }

            return Ok(clients);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClientDetailsDTO>> GetClientDetails(int id)
        {
            var client = await _repository.GetClientAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ClientDetailsDTO>(client));
        }



        [HttpPost]
        public async Task<ActionResult<Client>> CreateClient(CreateClientDTO clientDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newClient = _mapper.Map<Client>(clientDto);

            var emails = clientDto.Emails.Select((e, i) => new Email { EmailAddress = e, IsPrimary = i == 0, Client = newClient }).ToList();

            var addresses = clientDto.Addresses.Select((e, i) => new Address { City = e.City, State = e.State, Street = e.Street, IsPrimary = i == 0, Client = newClient }).ToList();

            newClient.Addresses = addresses;
            newClient.Emails = emails;

            await _repository.RegisterClient(newClient);
            return CreatedAtAction("CreateClient", new { id = newClient.Id }, newClient);
        }
    }

}