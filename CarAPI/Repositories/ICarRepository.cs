using Car.Models;

namespace CarAPI.Repositories
{
    public interface ICarRepository
    {
        Car Add(Car newCar);
        Car? Delete(int id);
        List<Car> GetAll(int? amount, string? namefilter);
        Car? GetByID(int id);
        Car? Update(int id, Car updates);
    }
}