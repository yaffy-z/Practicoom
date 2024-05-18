using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WorkersManagment.Api.Models;
using WorkersManagment.Core.Models;
using WorkersManagment.Core.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WorkersManagment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionsController : ControllerBase
    {

        private readonly IPositionService _positionService;
        private readonly IMapper _mapper;

        public PositionsController(IPositionService positionService, IMapper mapper)
        {
            _positionService = positionService;
            _mapper = mapper;
        }
        // GET: api/<PositionsController>
        [HttpGet]
        public async Task<IEnumerable<Position>> Get()
        {
            return await _positionService.GetPositionsAsync();
        }

        // GET api/<PositionsController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<PositionsController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PositionPostModel position)
        {
            var newPosition = await _positionService.AddPositionAsync(_mapper.Map<Position>(position));
            return Ok(newPosition);
        }

        // PUT api/<PositionsController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<PositionsController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
