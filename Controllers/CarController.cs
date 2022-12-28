using CosmosProject.Models;
using CosmosProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CosmosProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        public readonly ICarService _carService;
        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var sqlCosmosQuery = "Select * from c";
            var result = await _carService.Get(sqlCosmosQuery);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Car newCar)
        {
            newCar.Id = Guid.NewGuid().ToString(); //new id generation
            var result = await _carService.AddAsync(newCar);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Put(Car carToUpdate)
        {
            var result = await _carService.Update(carToUpdate);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(string id, string ChassisNumber)
        {
            await _carService.Delete(id, ChassisNumber);
            return Ok();
        }
    }
}
