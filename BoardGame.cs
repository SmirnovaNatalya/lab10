using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LibraryLab10
{
    public class BoardGame: Game, IInit, ICloneable, IComparable
    {

        public bool spesicalBoard;
        public string spesicalAtributs;

        public static string[] atributs = {"Карты", "Игральные кости", "Дайсы", "Фишки", "Паровозики", "Игральные кости", "Тайлы", "Жетоны", "Песочные часы", "Поле", "Жетоны здоровья", "Фишки персонажей", "Колода событий", "Маркеры урона", "Жетоны ресурсов", "Карты заданий", "Миниатюры", "Маркеры угроз", };

        public bool SpesicalBoard { get; private set; }

        public string SpesicalAtributs
        {
            get
            {
                return this.spesicalAtributs;
            }
            set
            {
                if (value == null || value == "")
                {
                    throw new ArgumentNullException("Название атрибута(ов) должно содержать хотя бы 1 букву");
                }
                if (value == " ")
                {
                    throw new Exception("Название атрибута(ов) не может состоять из пробела");
                }
            }
        }

        public BoardGame(): base()
        {
            spesicalBoard = false;
            spesicalAtributs = "Нет";
        }

        public BoardGame(string name, int minNumberPlayers, int maxNumberPlayers, bool spesicalBoard, string spesicalAtributs) : base(name, minNumberPlayers, maxNumberPlayers)
        {
            SpesicalBoard = spesicalBoard;
            SpesicalAtributs = spesicalAtributs;
        }

        public override void VirtualShow()
        {
            base.VirtualShow();
            Console.WriteLine($"Специальные атрибуты: {spesicalAtributs}, необходимость доски - {spesicalBoard}");
        }

        public void Show()
        {
            base .Show();
            Console.WriteLine($"Специальные атрибуты: {spesicalAtributs}, необходимость доски - {spesicalBoard}");
        }
        public override string ToString()
        {
            return base.ToString() + ", " + this.spesicalBoard + ", " + this.spesicalAtributs;
        }
        public override void Init()
        {
            base.Init();
            Console.Write("Требуется игровое поле (true/false): ");
            SpesicalBoard = bool.Parse(Console.ReadLine());
            Console.WriteLine("Введите атрибут:");
            spesicalAtributs = Console.ReadLine();
        }
        public override object RandomInit()
        {
            base.RandomInit();
            spesicalBoard = rnd.Next(1, 2) == 1;
            SpesicalAtributs = atributs[rnd.Next(atributs.Length)];
            return new BoardGame(Name, MinNumberPlayers, MaxNumberPlayers, SpesicalBoard, SpesicalAtributs);
        }
    }
}
