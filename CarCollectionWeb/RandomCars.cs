using CarCollectionWeb.Data;
using CarCollectionWeb.Models.Domain;
using Microsoft.VisualBasic.FileIO;

namespace CarCollectionWeb
{
    public static class RandomCars
    {
        public static string GenerateRandomCarBrand(Random random)
        {
            string[] carBrands = { "Toyota", "Honda", "Ford", "Chevrolet", "BMW", "Mercedes-Benz" };
            return GetRandomValue(random, carBrands);
        }

        private static string GetRandomValue(Random random, string[] carBrands)
        {
            throw new NotImplementedException();
        }

        // Генерация случайной модели автомобиля
        public static string GenerateRandomCarModel(Random random)
        {
            string[] carModels = { "Camry", "Civic", "Focus", "Cruze", "X5", "E-Class" };
            return GetRandomValue(random, carModels);
        }

        // Генерация случайного года выпуска автомобиля
        public static int GenerateRandomYear(Random random, int minYear, int maxYear)
        {
            return random.Next(minYear, maxYear + 1);
        }

        // Генерация случайной емкости двигателя автомобиля
        public static double GenerateRandomEngineCapacity(Random random, double minCapacity, double maxCapacity)
        {
            return minCapacity + random.NextDouble() * (maxCapacity - minCapacity);
        }

        // Генерация случайного типа топлива автомобиля
        //public static FuelType GenerateRandomFuelType(Random random)
        //{
        //    FuelType[] fuelTypes = { FuelType.Petrol, FuelType.Diesel, FuelType.Gasoline };
        //    return GetRandomValue(random, fuelTypes);
        //}

        // Генерация случайной записи в базу данных
       
    }
}
