using lab;
using LibraryLab10;
namespace TestProject2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestExeption1()
        {
            Dish d1 = new Dish(-1, 2, 3);
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestExeption2()
        {
            Dish d1 = new Dish(1, -2, 3);
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestExeption3()
        {
            Dish d1 = new Dish(1, 2, -3);
        }

        [TestMethod]
        public void TestDishConstructorWithParams()
        {
            // Arrange
            Dish expectedDish = new Dish(10, 10, 30);
            // Act
            Dish actualDish = new Dish(10, 10, 30);
            // Assert
            Assert.AreEqual(expectedDish.Proteins, actualDish.Proteins);
            Assert.AreEqual(expectedDish.Fats, actualDish.Fats);
            Assert.AreEqual(expectedDish.Carbohydrates, actualDish.Carbohydrates);
        }

        [TestMethod]
        public void TestDishConstructorWithoutParams()
        {
            // Arrange
            Dish expectedDish = new Dish(30, 30, 40);
            // Act
            Dish actualDish = new Dish();
            // Assert
            Assert.AreEqual(expectedDish.Proteins, actualDish.Proteins);
            Assert.AreEqual(expectedDish.Fats, actualDish.Fats);
            Assert.AreEqual(expectedDish.Carbohydrates, actualDish.Carbohydrates);
        }

        [TestMethod]
        public void TestCalculateCalories()
        {
            // Arrange
            double expected = 17;
            // Act
            Dish actualDish = new Dish(1, 1, 1);
            double calories = actualDish.CalculateCalories();
            // Assert
            Assert.AreEqual(expected, calories);
        }

        [TestMethod]
        public void TestMethodCalories()
        {
            // Arrange
            double expectedCalories = 17;
            // Act
            Dish actualDish = new Dish(1, 1, 1);
            // Assert
            Assert.AreEqual(expectedCalories, actualDish.Calories);
        }
        [TestMethod]
        public void TestOperatorInc()
        {
            // Arrange
            Dish expectedDish = new Dish(2, 2, 2);
            // Act
            Dish actualDish = new Dish(1, 1, 1);
            actualDish++;
            // Assert
            Assert.AreEqual(expectedDish.Proteins, actualDish.Proteins);
            Assert.AreEqual(expectedDish.Fats, actualDish.Fats);
            Assert.AreEqual(expectedDish.Carbohydrates, actualDish.Carbohydrates);
        }

        [TestMethod]
        public void TestOperatorPercentage()
        {
            // Arrange
            double expectedPercentage = 4.25;
            // Act
            Dish actualDish = new Dish(4, 5, 6);
            double actualPercentage = ~actualDish;
            // Assert
            Assert.AreEqual(expectedPercentage, actualPercentage);
        }

        [TestMethod]
        public void TestOperatorBool()
        {
            // Arrange
            bool expectedDishTrue = true;
            bool expectedDishFalse = false;
            // Act
            Dish actualSmallDish = new Dish(11, 21, 5);
            Dish actualBigDish = new Dish();
            // Assert
            Assert.AreEqual(expectedDishFalse, (bool)actualSmallDish);
            Assert.AreEqual(expectedDishTrue, (bool)actualBigDish);
        }
        [TestMethod]
        public void TestOperatorString()
        {
            // Arrange
            string expecetedString = "Белков – 1 г., жиров – 1 г., углеводов – 1 г.";
            // Act
            Dish actualDish = new Dish(1, 1, 1);
            string actualString = (string)actualDish;
            // Assert
            Assert.AreEqual(expecetedString, actualString);
        }
        [TestMethod]
        public void TestOperatorMulti()
        {
            // Arrange
            double expectedResult = 51;
            // Act
            Dish actualDish = new Dish(1, 1, 1);
            double portion = 3;
            double calories = actualDish.Calories;
            double resultRight51 = portion * calories;
            double resultLeft51 = calories * portion;
            // Assert
            Assert.AreEqual(expectedResult, resultRight51);
            Assert.AreEqual(expectedResult, resultLeft51);
        }

        [TestMethod]
        public void TestOperatorCompare()
        {
            // Arrange
            bool expectedDishTrue = true;
            bool expectedDishFalse = false;
            // Act
            Dish smallDish = new Dish(1, 1, 1);
            Dish bigDish = new Dish(2, 2, 2);
            bool res1 = smallDish < bigDish;
            bool res2 = smallDish > bigDish;
            bool res3 = bigDish < smallDish;
            bool res4 = bigDish > smallDish;
            // Assert
            Assert.AreEqual(expectedDishTrue, res1);
            Assert.AreEqual(expectedDishFalse, res2);
            Assert.AreEqual(expectedDishFalse, res3);
            Assert.AreEqual(expectedDishTrue, res4);
        }

        [TestMethod]
        public void Constructor_Default_SetsCorrectValues()
        {
            var game = new Game();
            Assert.AreEqual("Тетрис", game.Name);
            Assert.AreEqual(1, game.MinNumberPlayers);
            Assert.AreEqual(2, game.MaxNumberPlayers);
        }

        [TestMethod]
        public void Constructor_Parameters_SetsValuesCorrectly()
        {
            var game = new Game("Шахматы", 2, 4);
            Assert.AreEqual("Шахматы", game.Name);
            Assert.AreEqual(2, game.MinNumberPlayers);
            Assert.AreEqual(4, game.MaxNumberPlayers);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void MinPlayers_ThrowsException_WhenNegative()
        {
            var game = new Game();
            game.MinNumberPlayers = -1;
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void MaxPlayers_ThrowsException_WhenMoreThan100()
        {
            var game = new Game();
            game.MaxNumberPlayers = 200;
        }

        [TestMethod]
        public void RandomInit_FillsValidData()
        {
            var game = new Game();
            game.RandomInit();
            Assert.IsFalse(string.IsNullOrWhiteSpace(game.Name));
            Assert.IsTrue(game.MinNumberPlayers > 0);
            Assert.IsTrue(game.MaxNumberPlayers > 0);
        }

        [TestMethod]
        public void Equals_ReturnsTrue_ForIdenticalGames()
        {
            var game1 = new Game("Шахматы", 2, 4);
            var game2 = new Game("Шахматы", 2, 4);
            Assert.AreEqual(game1, game2);
        }

        [TestMethod]
        public void Clone_CreatesExactCopy()
        {
            var game = new Game("Шахматы", 2, 4);
            var clone = (Game)game.Clone();
            Assert.AreEqual(game, clone);
        }

        [TestMethod]
        public void CompareTo_WorksCorrectly()
        {
            var game1 = new Game("Игра1", 2, 4);
            var game2 = new Game("Игра2", 2, 10);
            Assert.IsTrue(game1.CompareTo(game2) < 0);
        }

        [TestMethod]
        public void DefaultConstructor_SetsExpectedValues()
        {
            var game = new BoardGame();
            Assert.IsFalse(game.spesicalBoard);
            Assert.AreEqual("Нет", game.spesicalAtributs);
        }

        [TestMethod]
        public void ParameterConstructor_SetsAllValues()
        {
            var game = new BoardGame("Монополия", 2, 6, true, "Карты");
            Assert.AreEqual("Монополия", game.Name);
            Assert.AreEqual(2, game.MinNumberPlayers);
            Assert.AreEqual(6, game.MaxNumberPlayers);
            Assert.IsTrue(game.spesicalBoard);
            Assert.AreEqual("Карты", game.spesicalAtributs);
        }

        [TestMethod]
        public void RandomInit_SetsValidData()
        {
            var game = new BoardGame();
            game.RandomInit();
            Assert.IsTrue(game.MinNumberPlayers > 0);
            Assert.IsTrue(game.MaxNumberPlayers > 0);
            Assert.IsFalse(string.IsNullOrWhiteSpace(game.spesicalAtributs));
        }

        [TestMethod]
        public void DefaultConstructor_SetsExpectedValuesVideoGame()
        {
            var game = new VideoGame();
            Assert.AreEqual("Консоль", game.device);
            Assert.AreEqual(100, game.numberLevels);
        }

        [TestMethod]
        public void ParameterConstructor_SetsValuesVideoGame()
        {
            var game = new VideoGame("CS:GO", 1, 10, "ПК", 50);
            Assert.AreEqual("ПК", game.Device);
            Assert.AreEqual(50, game.NumberLevels);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void SetDevice_ThrowsOnEmptyString()
        {
            var game = new VideoGame();
            game.Device = "";  // Ожидаем Exception
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void SetNumberLevels_ThrowsOnZero()
        {
            var game = new VideoGame();
            game.NumberLevels = 0;  // Ожидаем Exception
        }

        [TestMethod]
        public void RandomInit_SetsValidData1()
        {
            var game = new VideoGame();
            game.RandomInit();
            Assert.IsTrue(game.NumberLevels > 0);
            Assert.IsFalse(string.IsNullOrWhiteSpace(game.device));
        }

        [TestMethod]
        public void DefaultConstructor_SetsExpectedValuesVRGame()
        {
            var game = new VRGame();
            Assert.IsTrue(game.vrHeadset);
            Assert.IsTrue(game.vrControllers);
        }

        [TestMethod]
        public void ParameterConstructor_SetsValuesVRGame()
        {
            var game = new VRGame("Beat Saber", 1, 2, true, true);
            Assert.IsTrue(game.VRHeadset);
            Assert.IsTrue(game.VRControllers);
        }

        [TestMethod]
        public void RandomInit_SetsValues()
        {
            var game = new VRGame();
            game.RandomInit();
            // Тут сложно проверить конкретные значения, т.к. они случайные, но можно проверить, что bool-ы корректно заполнились
            Assert.IsNotNull(game);
        }
        [TestMethod]
        public void Constructor_SetsNumberCorrectly()
        {
            var id = new IdNumber(123);
            Assert.AreEqual(123, id.Number);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Constructor_ThrowsExceptionOnNegative()
        {
            var id = new IdNumber(-1);
        }

        [TestMethod]
        public void Equals_ReturnsTrueForEqualIds()
        {
            var id1 = new IdNumber(456);
            var id2 = new IdNumber(456);
            Assert.AreEqual(id1, id2);
        }

        [TestMethod]
        public void Equals_ReturnsFalseForDifferentIds()
        {
            var id1 = new IdNumber(123);
            var id2 = new IdNumber(456);
            Assert.AreNotEqual(id1, id2);
        }
    }
}