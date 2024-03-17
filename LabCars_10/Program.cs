using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Diagnostics;
using Cars;
using LabAvto_10;

namespace LabaAvto_10
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu choise = new Menu();
            Car car1 = new Car();
            //car.Show();
            //LightCar lightCar = new LightCar(2, 300);
            //lightCar.Show();
            //OffRoad offRoad = new OffRoad();
            //offRoad.Show();
            //Truck truck = new Truck();
            //truck.Show();
            IInit[] objects = new IInit[5];
            Car[] cars = new Car[25];
            Random rnd = new Random();
            while (true)
            {
                choise.MenuChoise();
                var str = Console.ReadLine();
                int i = int.Parse(str);
                Console.Clear();
                switch (i)
                {
                    case 1:
                        for (int j = 0; j < cars.Length; j++)
                        {
                            switch (rnd.Next(1, 4))
                            {
                                case 1:
                                    cars[j] = new LightCar();
                                    break;
                                case 2:
                                    cars[j] = new OffRoad();
                                    break;
                                case 3:
                                    cars[j] = new Truck();
                                    break;
                            }
                        }
                        foreach (var car in cars)
                        {
                            car.RandomInit();
                            car.Show();
                        }
                        break;
                    case 2: // самый дорогой внедорожник (is)
                        double minPrice = 50000;
                        OffRoad offr = null;
                        foreach (var car in cars)
                        {
                            if (car is OffRoad offRoad && offRoad.Price > minPrice && offRoad != null)
                            {
                                minPrice = offRoad.Price;
                                offr = offRoad;
                            }
                        }
                        Console.WriteLine($"Самый дорогой внедоожник: {offr.Price}");
                        break;
                    case 3: // средняя скорость легковых автомобилей (as)
                        double fullSpeed = 0;
                        int count = 0;
                        foreach (var item in cars)
                        {
                            LightCar car = item as LightCar;
                            if (car != null)
                            {
                                fullSpeed += car.GetSpeed();
                                Console.WriteLine(car.GetSpeed());
                                count++;
                            }
                        }
                        double midSpeed = 0;
                        if (count > 0)
                            midSpeed = fullSpeed / count;
                        Console.WriteLine($"Среднняя скорость легковых автомобилей {midSpeed}");
                        break;
                    case 4: // суммарная стоимость всех автомобилей (typeof)
                        double totalPrice = 0;
                        foreach (var item in cars)
                        {
                            if (item.GetType() == typeof(LightCar) || item.GetType() == typeof(OffRoad) || item.GetType() == typeof(Truck))
                            {
                                Car car = item;
                                totalPrice += car.Price;
                            }
                        }
                        Console.WriteLine($"Суммарная стоимость всех автомобилей: {totalPrice}");
                        break;
                    case 5: // вывод объектов на печать и подсчёт кол-ва объектов с помощью цикла foreach и оператора is для определения принадлежности объекта к классу
                        objects[0] = new LightCar();
                        objects[1] = new OffRoad();
                        objects[2] = new Truck();
                        objects[3] = new Pokemon();
                        int lCarount = 0;
                        int truckCount = 0;
                        int offRCount = 0;
                        int pokemonCount = 0;
                        foreach (var item in objects)
                        {
                            if (item != null)
                            {
                                item.RandomInit();
                                item.Show();
                                if (item is LightCar)
                                    lCarount++;
                                else if (item is Truck)
                                    truckCount++;
                                else if (item is OffRoad)
                                    offRCount++;
                                else if (item is Pokemon)
                                    pokemonCount++;
                            }
                        }
                        Console.WriteLine($"\nКоличество легковых автомобилей: {lCarount}");
                        Console.WriteLine($"Количество внедорожников: {offRCount}");
                        Console.WriteLine($"Количество грузовых автомобилей: {truckCount}");
                        Console.WriteLine($"Количество покемонов: {pokemonCount}");
                        break;
                    case 6: // сортировка по бренду с помощью интерфейса IComparable + BinarySearch
                        Array.Sort(cars);
                        try
                        {
                            foreach (var car in cars)
                                car.Show();
                        }
                        catch (Exception ex) { Console.WriteLine(ex.Message); }

                        int searchYear = 2010; // искомый год
                        int index = Array.BinarySearch(cars, new Car { Year_Issue = searchYear });
                        if (index >= 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine($"Объект с годом {searchYear} найден в массиве:");
                            Console.ForegroundColor = ConsoleColor.White;
                            cars[index].Show();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine($"Объект с годом {searchYear} не найден в массиве");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        break;
                    case 7: // сортировка по цвету с помощью интерфейса IComperer НЕ РАБОТАЕТ!!!!
                        Array.Sort(cars, new ColorComparer());

                        foreach (Car car in cars)
                        {
                            car.Show();
                        }

                        string searchColor = "Фиолетовый";
                        int index1 = Array.BinarySearch(cars, new Car { Color = searchColor });
                        if (index1 >= 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine($"Объект с годом {searchColor} найден в массиве:");
                            Console.ForegroundColor = ConsoleColor.White;
                            cars[index1].Show();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine($"Объект с годом {searchColor} не найден в массиве");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        break;
                    case 8: // клонирование и поверхностное копирование
                        IdNumber id = new IdNumber(12);
                        Car newCar = new Car(id, "BMW", 2013, "Серебристый", 1000000, 140);
                        Car clonedCar = (Car)newCar.Clone(); // Клонирование объекта
                        Car shallowCopiedCar = newCar.ShallowCopy();// Поверхностное копирование объекта

                        Console.WriteLine("Исходный объект:");
                        Console.WriteLine($"Id: {newCar.Id.Number}, Brand: {newCar.Brand}");

                        Console.WriteLine("\nКлонированный объект:");
                        Console.WriteLine($"Id: {clonedCar.Id.Number}, Brand: {clonedCar.Brand}");

                        Console.WriteLine("\nПоверхностно скопированный объект:");
                        Console.WriteLine($"Id: {shallowCopiedCar.Id.Number}, Brand: {shallowCopiedCar.Brand}");

                        // Изменение идентификационного номера и проверка
                        id.Number = 25;

                        Console.WriteLine("\nИзменение идентификационного номера:");

                        Console.WriteLine("Исходный объект:");
                        Console.WriteLine($"Id: {newCar.Id.Number}, Brand: {newCar.Brand}");

                        Console.WriteLine("Клонированный объект:");
                        Console.WriteLine($"Id: {clonedCar.Id.Number}, Brand: {clonedCar.Brand}");

                        Console.WriteLine("Поверхностно скопированный объект:");
                        Console.WriteLine($"Id: {shallowCopiedCar.Id.Number}, Brand: {shallowCopiedCar.Brand}");
                        break;
                }
            }
        }
    }
}