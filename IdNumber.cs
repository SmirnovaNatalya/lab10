using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryLab10
{
    public class IdNumber
    {
        private int number;

        public int Number
        {
            get => number;
            set
            {
                if (value < 0)
                    throw new Exception("ID не может быть отрицательным");
                number = value;
            }
        }

        public IdNumber(int num)
        {
            Number = num;
        }

        public override string ToString() => $"ID: {Number}";

        public override bool Equals(object obj)
        {
            return obj is IdNumber id && this.Number == id.Number;
        }
    }
}
