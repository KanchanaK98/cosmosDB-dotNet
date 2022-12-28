using CosmosProject.Models;
using Microsoft.Azure.Cosmos;

namespace CosmosProject.Services
{
    public class CarService : ICarService
    {
        private readonly Container _container;
        public CarService(CosmosClient cosmosClient,
    string databaseName,
    string containerName) {
            _container = cosmosClient.GetContainer(databaseName, containerName);
        }

        public async Task<List<Car>> Get(string sqlCosmosQuery)
        {
            var query = _container.GetItemQueryIterator<Car>(new QueryDefinition(sqlCosmosQuery));

            List<Car> result = new List<Car>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                result.AddRange(response);
            }

            return result;
        }

        public async Task<Car> AddAsync(Car newCar)
        {
            var item = await _container.CreateItemAsync<Car>(newCar, new PartitionKey(newCar.ChassisNumber));
            return item;
        }

        public async Task<Car> Update(Car carToUpdate)
        {
            var item = await _container.UpsertItemAsync<Car>(carToUpdate, new PartitionKey(carToUpdate.ChassisNumber));
            return item;
        }
        public async Task Delete(string id, string ChassisNumber)
        {
            await _container.DeleteItemAsync<Car>(id, new PartitionKey(ChassisNumber));
        }
    }
}
