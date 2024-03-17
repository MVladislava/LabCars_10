using Cars;
namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange - ожидаемое
            Car expected = new Car(new IdNumber(0), "BMW", 2013, "Белый", 1500000, 140);
            LightCar expectedLcar = new LightCar(5, 200);
            OffRoad expOffR = new OffRoad(true, "Гравий");
            Truck expTruck = new Truck(5);
            Pokemon expectedP = new Pokemon(17, 32, 1);
            //Act - что проверяется
            Car actual = new Car();
            LightCar actualLcar = new LightCar();
            OffRoad offRoad = new OffRoad();
            Truck actTruck = new Truck();
            Pokemon actPok = new Pokemon();
            //Assert - сравниваем
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedLcar, actualLcar);
            Assert.AreEqual(expOffR, offRoad);
            Assert.AreEqual(expTruck, actTruck);
            Assert.AreEqual(expectedP, actPok);
        }
        [TestMethod]
        public void ShallowCopy()
        {
            //Arrange - ожидаемое
            var Id = new IdNumber(123);
            var expected = new Car(Id, "BMW", 2010, "Черный", 506000, 150);
            //Act - что проверяется
            var actual = expected.ShallowCopy();
            //Assert - сравниваем
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Clone()
        {
            //Arrange - ожидаемое
            var Id = new IdNumber(123);
            var expected = new Car(Id, "BMW", 2010, "Черный", 770000, 150);
            //Act - что проверяется
            var actual = (Car)expected.Clone();
            //Assert - сравниваем
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Copy()
        {
            //Arrange - ожидаемое
            Car expectedCar = new Car(new IdNumber(0), "BMW", 2013, "Белый", 1500000, 140);
            LightCar expectedLcar = new LightCar(5, 200);
            OffRoad expOffR = new OffRoad(true, "Лес");
            Truck expTruck = new Truck(10);
            Pokemon expected = new Pokemon(20, 42, 13);

            //Act - что проверяется
            Car actualCar = new Car(new IdNumber(0), "BMW", 2013, "Белый", 1500000, 140);
            LightCar actLcar = new LightCar(10, 100);
            OffRoad actOffR = new OffRoad(true, "Лес");
            Truck actTruck = new Truck(21);

            Pokemon actualP = new Pokemon(20, 42, 13);
            Pokemon actual2 = new Pokemon(actualP);

            Car act = new Car(actualCar);
            LightCar act1 = new LightCar(actLcar);
            OffRoad act2 = new OffRoad(actOffR);
            Truck act3 = new Truck(actTruck);

            //Assert - сравниваем
            Assert.AreEqual(expectedCar, act);
            Assert.AreEqual(expectedLcar, act1);
            Assert.AreEqual(expOffR, act2);
            Assert.AreEqual(expTruck, act3);
            Assert.AreEqual(expected, actual2);
        }
        [TestMethod]
        public void Equals()
        {
            //Arrange - ожидаемое
            var expected = new Car(new IdNumber(12), "BMW", 2020, "Белый", 50000, 130);
            var actual = new Car(new IdNumber(12), "BMW", 2020, "Белый", 50000, 130);
            var actual1 = new Car(new IdNumber(12), "BMW", 2024, "Белый", 60000, 130);
            //Act - что проверяется
            //Assert - сравниваем
            Assert.IsTrue(expected.Equals(actual));
            Assert.IsFalse(expected.Equals(actual1));
        }
    }
}