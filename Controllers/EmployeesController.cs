using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AspNet_core_203.Infrastructure;
using AspNet_core_203.Models;
using AspNet_core_203.Repository;
using AspNet_core_203.ViewModels;

namespace AspNet_core_203.Controllers {
    [Route ("api/Employees"), ValidateModel, NoCache]
    public class EmployeesController : Controller {
        private readonly IEmployeeRepository _repository;
        private readonly ILogger<EmployeesController> _logger;
        private readonly IMapper _mapper;

        public EmployeesController (IEmployeeRepository repository,
            ILogger<EmployeesController> logger, IMapper mapper) {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get () {
            var getEmployees = await _repository.GetEmployeesAsync ();
            return Ok (_mapper.Map<IEnumerable<EmployeeVm>> (getEmployees));
        }

        [HttpGet ("{EmployeeId}", Name = "getEmployee")]
        public async Task<IActionResult> Get (Guid EmployeeId) {
            if (!await _repository.EmployeeExist (EmployeeId)) {
                return NotFound ($"Unable to find employee with {EmployeeId}");
            }
            var getEmployee = await _repository.GetEmployeeAsync (EmployeeId);
            return Ok (_mapper.Map<EmployeeVm> (getEmployee));
        }

        [HttpPost]
        public async Task<IActionResult> Post ([FromBody] CreateEmployee entity) {
            if (!ModelState.IsValid) {
                return BadRequest ();
            }
            var employeeEntity = _mapper.Map<Employee> (entity);
            await _repository.InsertEmployeeAsync (employeeEntity);
            if (!await _repository.SaveAsync ()) {
                return BadRequest ();
            }
            return Created ("getEmployee", null);
        }

        [HttpDelete ("{EmployeeId}")]
        public async Task<IActionResult> Delete (Guid EmployeeId) {
            //TODO: Implement Realistic Implementation
            await _repository.DeleteEmployeeAsync (EmployeeId);
            if (!await _repository.SaveAsync ()) {
                return BadRequest ();
            }
            return NoContent ();
        }
    }
}