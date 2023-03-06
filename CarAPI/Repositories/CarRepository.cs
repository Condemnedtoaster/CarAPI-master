using CarAPI.Models;


namespace CarAPI.Repositories
{
    public class CarRepository : ICarRepository
    {
        private int _nextID;
        private List<Car> _cars;

        public CarRepository()
        {
            _nextID = 1;
            _cars = new List<Car>()
            {
                new Car() {Id = _nextID++, Name="Pikachu", Level=9999, PokeDex=25},
                new Car() {Id = _nextID++, Name="Charmander", Level=1000, PokeDex=12},
                new Car() {Id = _nextID++, Name="Arbok", Level=20, PokeDex=80},
            };
        }

        public List<Car> GetAll(int? amount, string? namefilter)
        {
            List<Car> result = new List<Car>(_cars);

            if (namefilter != null)
            {
                result = result.FindAll(car => car.Name.Contains(namefilter,
                    StringComparison.InvariantCultureIgnoreCase));
            }

            if (amount != null)
            {
                int castAmount = (int)amount;
                return result.Take(castAmount).ToList();
            }

            return result;
        }

        public Car? GetByID(int id)
        {
            return _cars.Find(x => x.Id == id);
        }

        public Car Add(Car newCar)
        {
            newCar.Validate();
            newCar.Id = _nextID++;
            _cars.Add(newCar);
            return newCar;
        }

        public Car? Delete(int id)
        {
            Car? foundCar = GetByID(id);
            if (foundCar == null)
            {
                return null;
            }
            _cars.Remove(foundCar);
            return foundCar;
        }

        public Car? Update(int id, Car updates)
        {
            updates.Validate();
            Car? foundCar = GetByID(id);
            if (foundCar == null)
            {
                return null;
            }
            foundCar.Name = updates.Name;
            foundCar.PokeDex = updates.PokeDex;
            foundCar.Level = updates.Level;
            return foundCar;
        }
    }
}
