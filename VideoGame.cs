using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryLab10
{
    public class VideoGame: Game, IInit
    {
        public string device;
        public int numberLevels;

        public static string[] devices = {"Телефон", "Ноутбук", "ПК", "Nintendo Switch", "PlayStation 5", "Xbox Series X", "Steam Deck", "Смарт ТВ", "Планшет", "VR-шлем",
        "Аркадный автомат", "Ручная консоль", "Smart Display", "Проектор","Автомобильная мультимедиа", "Smart Watch", "Chromebook", "Linux-система","Web-браузер", "Консоль ретро-игр"};

        public string Device
        {
            get
            {
                return this.device;
            }
            set
            {
                if (value == null || value == "")
                {
                    throw new ArgumentNullException("Название устройства должно содержать хотя бы 1 букву");
                }
                if (value == " ")
                {
                    throw new Exception("Название устройства не может состоять из пробела");
                }
            }
        }

        public int NumberLevels
        {
            get
            {
                return this.numberLevels;
            }
            set
            {
                if (value == 0)
                {
                    throw new Exception("В игре должен быть хотя бы 1 уровень");
                }
                if (value <= 0)
                {
                    throw new Exception("Количество уровней в игре не может быть отрицательным");
                }
            }
        }

        public VideoGame()
        {
            device = "Консоль";
            numberLevels = 100;
        }
        public VideoGame(string name, int minNumberPlayers, int maxNumberPlayers, string device, int numberLevels)
        {
            Device = device;
            NumberLevels = numberLevels;
        }

        public override void VirtualShow()
        {
            base.VirtualShow();
            Console.WriteLine($"Устройство: {device}, количество уровней: {numberLevels}");
        }

        public override void Init()
        {
            base.Init();
            Console.Write("Требуемое устройство: ");
            Device = Console.ReadLine();

            Console.WriteLine("Количество уровней:");
            NumberLevels = int.Parse(Console.ReadLine());
        }
        public override object RandomInit()
        {
            base.RandomInit();
            Device = devices[rnd.Next(devices.Length)];
            NumberLevels = rnd.Next(1, 100);
            return new VideoGame(Name, MinNumberPlayers, MaxNumberPlayers, Device, NumberLevels);
        }
    }
}
