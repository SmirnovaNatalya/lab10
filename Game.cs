using System.ComponentModel.Design;
using System.Diagnostics;

namespace LibraryLab10
{
    public class Game : IInit, ICloneable, IComparable
    {
        protected static Random rnd = new Random();
        protected static string[] names = { "Тетрис", "Subway Serf", "Амням", "Шахматы", "Нарды", "Монополия", "CS:GO", "Stardew Valley", "Detroit", "Mario",
            "Genshin Impact", "Hades", "Minecraft", "Overcooked", "Bayonetta", "Outlast", "Взрывные котята", "UNO", "Свинтус", "Jenga", "Нечто", "Undertale", "Slime Rancher", "Little Nightmares", "Gravity Rush", "Loop Hero"};
        


        protected string name;
        protected int minNumberPlayers;
        protected int maxNumberPlayers;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value == null || value == "")
                {
                    throw new ArgumentNullException("Название игры должно содержать хотя бы 1 букву");
                }
                if (value == " ")
                {
                    throw new Exception("Название игры не может состоять из пробела");
                }
                else
                {
                    name = value;
                }
            }

        }

        public int MinNumberPlayers
        {
            get
            {
                return minNumberPlayers;
            }
            set
            {
                if (value == 0)
                {
                    throw new Exception("В игре должен участвовать хотя бы 1 игрок");
                }
                if (value <= 0)
                {
                    throw new Exception("Минимальное количество игроков не может быть отрицательным");
                }
                else
                {
                    minNumberPlayers = value;
                }
            }
        }

        public int MaxNumberPlayers
        {
            get
            {
                return maxNumberPlayers;
            }
            set
            {
                if (value == 0)
                {
                    throw new Exception("В игре должен участвовать хотя бы 1 игрок");
                }
                if (value <= 0)
                {
                    throw new Exception("Максимальное количество игроков не может быть отрицательным");
                }
                if (value > 100)
                {
                    throw new Exception("Максимальное количество игроков не может превышать 100 человек");
                }
                else
                {
                    maxNumberPlayers = value;
                }
            }
        }

        public Game()
        {
            Name = "Тетрис";
            MinNumberPlayers = 1;
            MaxNumberPlayers = 2;
        }
        public Game(string name, int minNumberPlayers, int maxNumberPlayers)
        {
            Name = name;
            MinNumberPlayers = minNumberPlayers;
            MaxNumberPlayers = maxNumberPlayers;
        }

        public virtual void VirtualShow()
        {
            Console.WriteLine($"Название игры {Name}, минимальное количество игроков - {MinNumberPlayers}, максимальное - {MaxNumberPlayers}");
        }

        public string Show()
        {
            return ($"Название игры {Name}, минимальное количество игроков - {MinNumberPlayers}, максимальное - {MaxNumberPlayers}");
        }

        public override string ToString()
        {
            return Name + ", " + MinNumberPlayers.ToString() + ", " + MaxNumberPlayers.ToString();
        }

        public virtual object RandomInit()
        {
            Name = names[rnd.Next(names.Length)];
            MinNumberPlayers = rnd.Next(1, 100);
            MaxNumberPlayers = rnd.Next(1, 100);
            return new Game(Name, MinNumberPlayers, MaxNumberPlayers);
        }

        public virtual void Init()
        {
            Console.WriteLine("Введите название игры:");
            Name = Console.ReadLine();

            Console.WriteLine("Введите минимальное количество игроков:");
            MinNumberPlayers = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите максимальное количество игроков:");
            MaxNumberPlayers = int.Parse(Console.ReadLine());

        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is not Game ) return false;
            Game other = (Game)obj;
            return this.Name == other.Name && this.MinNumberPlayers == other.MinNumberPlayers && this.MaxNumberPlayers == other.MaxNumberPlayers;
        }

        public object Clone()
        {
            return new Game(Name, MinNumberPlayers, maxNumberPlayers);
        }

        public int CompareTo(object? obj)
        {
            if(obj == null) return -1;

            if (obj is Game)
            {
                Game game = (Game)obj;

                return this.MaxNumberPlayers - game.MaxNumberPlayers;
            }

            return -1;

        }
    }
}
