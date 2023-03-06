using CarAPI.Contexts;
using CarAPI.Models;

namespace CarAPI.Repositories
{
    public class CarRepositoryDB : ICarRepository
    {
        private CarContext _context;

        public CarRepositoryDB(CarContext context)
        {
            _context = context;
        }

        public Car Add(Car newCar)
        {
            newCar.Id = 0;
            _context.cars.Add(newCar);
            _context.SaveChanges();
            return newCar;
        }

        public Car? Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(int? amount, string? namefilter)
        {
            return _context.cars.ToList();
        }

        public Car? GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public Car? Update(int id, Car updates)
        {
            throw new NotImplementedException();
        }
    }
}
