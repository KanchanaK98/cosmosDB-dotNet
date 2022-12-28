using CosmosProject.Models;

namespace CosmosProject.Services
{
    public interface ICarService
    {
        public Task<List<Car>> Get(string sqlCosmosQuery);
        public Task<Car> AddAsync(Car newCar);
        public Task<Car> Update(Car carToUpdate);
        public Task Delete(string id, string ChassisNumber);
    }
}
