using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCP
{
    class Program
    {
        static void Main(string[] args)
        {
            Cook cook = new Cook("Bob Jack");
            cook.MakeDinner(new PotatoMeal());
            Console.WriteLine("==============================================");
            cook.MakeDinner(new SaladMeal());

            Console.WriteLine("==============================================");

            MealBase[] menu = new MealBase[] { new PotatoMeal2(), new SaladMeal2(), new SaladMeal2() };

            Cook bob = new Cook("Bob");
            bob.MakeDinner(menu);
            Console.ReadKey();


        }
    }

    class Cook
    {
        public string Name { get; set; }

        public Cook(string name)
        {
            this.Name = name;
        }

        public void MakeDinner(MealBase[] menu)
        {
            foreach (MealBase meal in menu)
                meal.Make();
        }

        public void MakeDinner(IMeal meal)
        {
            meal.Make();
        }
    }

    interface IMeal
    {
        void Make();
    }
    class PotatoMeal : IMeal
    {
        public void Make()
        {
            Console.WriteLine("Чистим картошку");
            Console.WriteLine("Ставим почищенную картошку на огонь");
            Console.WriteLine("Сливаем остатки воды, разминаем варенный картофель в пюре");
            Console.WriteLine("Посыпаем пюре специями и зеленью");
            Console.WriteLine("Картофельное пюре готово");
        }
    }
    class SaladMeal : IMeal
    {
        public void Make()
        {
            Console.WriteLine("Нарезаем помидоры и огурцы");
            Console.WriteLine("Посыпаем зеленью, солью и специями");
            Console.WriteLine("Поливаем подсолнечным маслом");
            Console.WriteLine("Салат готов");
        }
    }


    ////=======================================================================
    ///
    

    abstract class MealBase
    {
        public void Make()
        {
            Prepare();
            Cook();
            FinalSteps();
        }
        protected abstract void Prepare();
        protected abstract void Cook();
        protected abstract void FinalSteps();
    }

    class PotatoMeal2 : MealBase
    {
        protected override void Cook()
        {
            Console.WriteLine("Ставим почищенную картошку на огонь");
            Console.WriteLine("Варим около 30 минут");
            Console.WriteLine("Сливаем остатки воды, разминаем варенный картофель в пюре");
        }

        protected override void FinalSteps()
        {
            Console.WriteLine("Посыпаем пюре специями и зеленью");
            Console.WriteLine("Картофельное пюре готово");
        }

        protected override void Prepare()
        {
            Console.WriteLine("Чистим и моем картошку");
        }
    }

    class SaladMeal2 : MealBase
    {
        protected override void Cook()
        {
            Console.WriteLine("Нарезаем помидоры и огурцы");
            Console.WriteLine("Посыпаем зеленью, солью и специями");
        }

        protected override void FinalSteps()
        {
            Console.WriteLine("Поливаем подсолнечным маслом");
            Console.WriteLine("Салат готов");
        }

        protected override void Prepare()
        {
            Console.WriteLine("Моем помидоры и огурцы");
        }
    }
}
