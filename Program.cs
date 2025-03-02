using lab;
using LibraryLab10;

namespace lab10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1 часть\n");
            Console.WriteLine("Создание объекта класса Game с использованием конструктора без параметров:");
            Game game = new Game();
            game.VirtualShow();

            Console.WriteLine("\nСоздание объекта класса Game с использованием конструктора с параметрами Амням, 1, 1:");
            Game game2 = new Game("Амням", 1, 1);
            Console.WriteLine(game2.Show());

            Console.WriteLine("\nСоздание объектов подклассов:");
            Console.WriteLine("\nИспользование виртуального метода для Настольной игры");
            BoardGame boardGame = new BoardGame();
            boardGame.VirtualShow();

            Console.WriteLine("\nИспользование обычного метода Show для Настольной игры");
            boardGame.Show();

            Console.WriteLine("\nИспользование виртуального метода для видеоигры и VR игры");
            VideoGame videoGame = new VideoGame();
            videoGame.VirtualShow();
            Console.WriteLine();
            VRGame vrGame = new VRGame();
            vrGame.VirtualShow();

            Console.WriteLine("\nСоздадим массив и выведем его обычным способом");
            Game[] arr = new Game[20];

            for (int i = 0; i < 5; i++)
            {
                Game g = new Game();
                g.RandomInit();
                arr[i] = g;
            }
            for (int i = 5; i < 10; i++)
            {
                BoardGame g = new BoardGame();
                g.RandomInit();
                arr[i] = g;
            }
            for (int i = 10; i < 15; i++)
            {
                VideoGame g = new VideoGame();
                g.RandomInit();
                arr[i] = g;
            }
            for (int i = 15; i < 20; i++)
            {
                VRGame g = new VRGame();
                g.RandomInit();
                arr[i] = g;
            }
            int count = 1;
            foreach (Game g in arr)
            {
                if (count == 6)
                {
                    count = 1;
                    Console.WriteLine();
                }
                Console.Write($"{count})");
                Console.WriteLine(g);
                count++;
                
            }
            Console.WriteLine("\nВыведем тот же массив с помощью виртуальной функции");
            foreach (Game item in arr)
            {
                item.VirtualShow(); 
                Console.WriteLine(); 
            }

            //Console.WriteLine("\nИспользование Init для Game:");
            //game.Init();
            //Console.WriteLine("\nИспользование Init для BoardGame:");
            //boardGame.Init();
            //Console.WriteLine("\nИспользование Init для VideoGame:");
            //videoGame.Init();
            //Console.WriteLine("\nИспользование Init для VRGame:");
            //vrGame.Init();

            Console.WriteLine("\nИспользование Equals для Game:");
            Console.WriteLine($"game {game} и videoGame {videoGame} равны? {game.Equals(videoGame)}");
            Console.WriteLine($"game {game} и game2 {game2} равны? {game.Equals(game2)}");


            Console.WriteLine("\n2 часть\n");
            Console.WriteLine("Использование is");
            int targetPlayers = 25;
            Console.WriteLine($"\nВся информация об играх, в котором минимальное количество игроков не меньше {targetPlayers} и  не превышает максимального количества игроков в игре:\n");
            foreach (var item in arr)
            {
                if (item is Game && item.MinNumberPlayers <= targetPlayers && targetPlayers <= item.MaxNumberPlayers)
                {
                    item.VirtualShow();
                    Console.WriteLine();
                }
            }
            Console.WriteLine("\nИспользование as");
            string targetDevice = "ПК";
            Console.WriteLine($"\nВидеоигры, доступные на {targetDevice}:");
            foreach (var item in arr)
            {
                VideoGame videoGame1 = item as VideoGame;
                if (videoGame1 != null && videoGame1.device == targetDevice)
                {
                    Console.WriteLine(videoGame1.Name);
                }
            }
            Console.WriteLine("\nИспользование typeof");
            Console.WriteLine("\nИгры, поддерживающие VR-очки:");
            foreach (var item in arr)
            {
                if (item.GetType() == typeof(VRGame)) // Проверка через typeof
                {
                    VRGame vrGame1 = (VRGame)item; // Приводим к VRGame
                    if (vrGame1.vrHeadset)
                    {
                        Console.WriteLine(vrGame1.Name);
                    }
                }
            }

            Console.WriteLine("3 часть\n");
            Console.WriteLine("\nДобавляем в массив элементы типа Dish");
            object[] items = new object[25];

            for (int i = 0; i < 20; i++)
            {
                items[i] = arr[i];
            }

            for (int i = 20; i < items.Length; i++)
            {
                Dish dish = new Dish();
                dish.RandomInit();
                items[i] = dish;
            }
            int gameCount = 0, boardGameCount = 0, videoGameCount = 0, vrGameCount = 0, dishCount = 0;

            foreach (var obj in items)
            {
                if (obj is Game)
                {
                    gameCount++;
                }
                if (obj is BoardGame)
                {
                    boardGameCount++;
                }
                if (obj is VideoGame)
                {
                    videoGameCount++;
                }
                if (obj is VRGame)
                {
                    vrGameCount++;
                }
                if (obj is Dish)
                {
                    dishCount++;
                }
            }

            Console.WriteLine($"Элементов типа Game {gameCount}, типа BoardGame {boardGameCount}, типа VideoGame {videoGameCount}, типа VRGame {vrGameCount}, типа Dish {dishCount}");

            Console.WriteLine("Бинарный поиск:");

            Game target = new Game { MaxNumberPlayers = 10 }; // Ищем игру, где макс игроков 10
            int index = Array.BinarySearch(arr, target);

            if (index >= 0)
                Console.WriteLine($"Игра найдена: {arr[index]}");
            else
                Console.WriteLine("Игра не найдена.");

            
        }

    }
}
