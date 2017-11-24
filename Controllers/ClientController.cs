using System.Collections.Generic;
using System.Threading.Tasks;
using AspNet_core_203.Repository;
using AspNet_core_203.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AspNet_core_203.Controllers {
    [Route ("api/client")]
    public class ClientController : Controller {
        private readonly IClientRepository _repo;
        private readonly ILogger<ClientController> _logger;
        private readonly IMapper _mapper;

        public ClientController (IClientRepository repository, ILogger<ClientController> logger, IMapper mapper) {
            _repo = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetClients () {
            var getClients = await _repo.ClientsAsync ();
            return Ok (_mapper.Map<IEnumerable<ContactVm>> (getClients));
        }
    }
}