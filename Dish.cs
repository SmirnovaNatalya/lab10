using LibraryLab10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace lab
{
    public class Dish: IInit, ICloneable
    {
        private double proteins;
        private double fats;
        private double carbohydrates;
        private static int count = 0;
        public static int GetCount => count;

        public double Proteins
        {
            get
            {
                return this.proteins;
                
            }
            set 
            {   
                if (value > 0 && value <= 100)
                {
                    this.proteins = value;
                    return;
                }
                if (value == 0)
                {
                    throw new Exception("Количество белков не может быть равно 0");
                }
                if (value < 0)
                {
                    throw new Exception("Количество белков не может быть меньше 0");
                }
                else { proteins = value; }

            }
        }
        public double Fats
        {
            get
            {
                return this.fats;
            }
            set
            {
                if (value > 0 && value <= 100)
                {
                    this.fats = value;
                }
                if (value == 0)
                {
                    throw new Exception("Количество жиров не может быть равно 0");
                }
                if (value < 0)
                {
                    throw new Exception("Количество жиров не может быть меньше 0");
                }
                else { fats = value; }

            }
        }
        public double Carbohydrates
        {
            get
            {
                return this.carbohydrates;
            }
            set
            {
                if (value > 0 && value <= 100)
                {
                    this.carbohydrates = value;
                }

                if (value == 0)
                {
                    throw new Exception("Количество углеводов не может быть равно 0");
                }
                if (value < 0)
                {
                    throw new Exception("Количество углеводов не может быть меньше 0");
                }
                else {  carbohydrates = value; }
            }
        }

        public Dish(double proteins, double fats, double carbohydrates)
        {
            Proteins = proteins;
            Fats = fats;
            Carbohydrates = carbohydrates;
            count++;

        }
        public Dish()
        {
            Proteins = 30;
            Fats = 30;
            Carbohydrates = 40;
            count++;
        }

        public double CalculateCalories()
        {
            return 4 * proteins + 9 * fats + 4 * carbohydrates;
        }

        public double Calories
        {
            get => Math.Round(4 * proteins + 9 * fats + 4 * carbohydrates, 2);
        }

        public override string ToString()
        {
            return $"В блюде 4 * белки (= {proteins}) + 9 * жиры (= {fats}) + 4 * углеводы (= {carbohydrates}) = {Calories} калорий";
        }

       public static Dish operator++ (Dish dish)
        {
            dish.proteins += 1;
            dish.fats += 1;
            dish.carbohydrates += 1;
            return dish;
        }
        public static double operator~ (Dish dish)
        {
            double percentage = (dish.CalculateCalories() / 2000) * 100;
            return Math.Round(percentage, 2);
        }
        
        public static explicit operator bool(Dish dish)
        {
            double grams = dish.proteins + dish.fats + dish.carbohydrates;
            return (int)dish.proteins/grams * 100 == 30 && (int)dish.fats / grams * 100 == 30 && (int)dish.carbohydrates / grams *  100 == 40;
        }

        public static implicit operator string(Dish dish)
        {
            return ($"Белков – {dish.proteins} г., жиров – {dish.fats} г., углеводов – {dish.carbohydrates} г.");
        }

        public static Dish operator *(Dish d, double portion)
        {
            return d * portion;
        }
        public static Dish operator *(double portion, Dish d)
        {
            return portion * d;
        }

        public static bool operator >(Dish d1, Dish d2)
        {
            return d1.Calories > d2.Calories;
        }
        public static bool operator <(Dish d1, Dish d2)
        {
            return d1.Calories < d2.Calories;
        }

        public string Show()
        {
            return ($"Белков – {proteins} г., жиров – {fats} г., углеводов – {carbohydrates} г.");
        }

        // Реализация IInit
        public void Init()
        {
            Console.Write("Введите белки: ");
            Proteins = double.Parse(Console.ReadLine());
            Console.Write("Введите жиры: ");
            Fats = double.Parse(Console.ReadLine());
            Console.Write("Введите углеводы: ");
            Carbohydrates = double.Parse(Console.ReadLine());
        }

        public object RandomInit()
        {
            Random rnd = new Random();
            Proteins = rnd.Next(1, 100);
            Fats = rnd.Next(1, 100);
            Carbohydrates = rnd.Next(1, 100);
            return this;
        }

        // Реализация ICloneable
        public object Clone()
        {
            return new Dish(proteins, fats, carbohydrates);
        }
        
        // Метод поверхностного копирования
        public Dish ShallowCopy()
        {
            return (Dish)this.MemberwiseClone();
        }

        public override bool Equals(object obj)
        {
            if (obj is not Dish other) return false;
            return proteins == other.proteins && fats == other.fats && carbohydrates == other.carbohydrates;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(proteins, fats, carbohydrates);
        }

        // Реализация IComparable (по калориям)
        public int CompareTo(object obj)
        {
            if (obj is not Dish other)
                throw new ArgumentException("Объект не является блюдом");

            return this.Calories.CompareTo(other.Calories);
        }
    }
}
