using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSP
{
    class Program
    {
        static void Main(string[] args)
        {

            Account account = new Account(23);

        }
    }

    class Account
    {
        protected int capital;
        public Account(int sum)
        {
            if (sum < 100)
                throw new Exception("Некорректная сумма");
            this.capital = sum;
        }

        public virtual int Capital
        {
            get { return capital; }
            set
            {
                if (value < 100)
                    throw new Exception("Некорректная сумма");
                capital = value;
            }
        }
    }

    class MicroAccount : Account
    {
        public MicroAccount(int sum) : base(sum)
        {
        }

        public override int Capital
        {
            get { return capital; }
            set
            {
                capital = value;
            }
        }
    }

}
