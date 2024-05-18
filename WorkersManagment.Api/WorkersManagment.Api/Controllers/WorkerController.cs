using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WorkersManagment.Api.Models;
using WorkersManagment.Core.Models;
using WorkersManagment.Core.Services;
using WorkersManagment.Service.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WorkersManagment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {


        private readonly IWorkerService _workerService;
        private readonly IMapper _mapper;

        public WorkerController(IWorkerService workerService, IMapper mapper)
        {
            _workerService = workerService;
            _mapper = mapper;
        }
        // GET: api/<WorkerController>
        [HttpGet]
        public async Task<IEnumerable<Worker>> Get()
        {
            return await _workerService.GetWorkerAsync();
        }

        // GET api/<WorkerController>/5
        [HttpGet("{id}")]
        public async Task<Worker> Get(int id)
        {
            return await _workerService.GetWorkerByIdAsync(id);
        }


        // POST api/<WorkerController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] WorkerPostModel worker)
        {
            var newWorker = await _workerService.AddWorkerAsync(_mapper.Map<Worker>(worker));
            return Ok(newWorker);
        }

        // PUT api/<WorkerController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] WorkerPostModel worker)
        {
            var updateWorker = await _workerService.UpdateWorkerAsync(id, _mapper.Map<Worker>(worker));
            return Ok(updateWorker);
        }

        // DELETE api/<WorkerController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _workerService.DeleteWorkerAsync(id);
        }
    }
}
