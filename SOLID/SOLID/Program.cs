using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
{
    class Program
    {
        static void Main(string[] args)
        {
            IPrinter printer = new ConsolePriter();
            Report report = new Report();
            report.Text = "Hello world";
            report.Print(printer);


            MobileStore store = new MobileStore(
    new ConsolePhoneReader(), new GeneralPhoneBinder(),
    new GeneralPhoneValidator(), new TextPhoneSever());
            store.Process();

            Console.ReadKey();
        }
    }

    public interface IPrinter
    {
        void Printer(string text);
    }

    public class ConsolePriter : IPrinter
    {
        public void Printer(string text)
        {
            Console.WriteLine(text);
        }
    }

    public class Report
    {
        public string Text { get; set; }
        
        public void GoToLastPage()
        {
            Console.WriteLine("Go to the last page");
        }

        public void GoToFirstPage()
        {
            Console.WriteLine("Go to the first page");
        }

        public void GoToPage(int pageNumber = 1)
        {
            Console.WriteLine("Page Number:{0}",pageNumber);
        }

        public void Print(IPrinter printer)
        {
            printer.Printer(this.Text);
        }
    }

    public class Phone
    {
        public string Model { get; set; }
        public int Price { get; set; }
    }

    public interface IPhoneReader
    {
        string[] GetInputData();
    }

    public interface IPhoneBinder
    {
        Phone CreatePhone(string[] data);
    }

    public interface IPhoneValidator
    {
        bool isValid(Phone phone);
    }

    public interface IPhoneSaver
    {
       void Save(Phone phone,string fullName);
    }


    public class TextPhoneSever : IPhoneSaver
    {
       public void Save(Phone phone,string name)
        {
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter("data.txt", true))
            {
                writer.Write(phone.Model);
                writer.Write(phone.Price);
            }
        }
    }

    public class GeneralPhoneValidator : IPhoneValidator
    {
        public bool isValid(Phone phone)
        {
            if (String.IsNullOrEmpty(phone.Model) || phone.Price <= 0)
                return false;
            else
                return true;
        }
    }

    public class GeneralPhoneBinder : IPhoneBinder
    {
        public Phone CreatePhone(string[] data)
        {
            if(data.Length >= 2)
            {
                int price = 0;
                if (Int32.TryParse(data[1], out price))
                {
                    return new Phone { Model = data[1], Price = price };
                }else
                {
                    throw new Exception("Phone model binding failed. Not enough data to create model");
                }
            }else
            {
                throw new Exception("Phone model binder error.Not enough data to create model");
            }
        }
    }

    public class ConsolePhoneReader : IPhoneReader
    {
        public string[] GetInputData()
        {
            Console.WriteLine("Enter model: ");
            string model = Console.ReadLine();
            Console.WriteLine("Enter price");
            string price = Console.ReadLine();
            return new string[] { model,price };
        }
    }

    public class MobileStore
    {
        List<Phone> phones = new List<Phone>();
        public IPhoneReader Reader { get; set; }
        public IPhoneBinder Binder { get; set; }
        public IPhoneValidator Validator { get; set; }
        public IPhoneSaver Saver { get; set; }

        public MobileStore(IPhoneReader reader, IPhoneBinder binder, IPhoneValidator validator, IPhoneSaver saver)
        {
            this.Reader = reader;
            this.Binder = binder;
            this.Validator = validator;
            this.Saver = saver;
        }
        public void Process()
        {
            string[] data = Reader.GetInputData();
            Phone phone = Binder.CreatePhone(data);
            if (Validator.isValid(phone))
            {
                phones.Add(phone);
                Saver.Save(phone, "store.txt");
                Console.WriteLine("Данные успешно обработаны");
            }
            else
            {
                Console.WriteLine("Некорректные данные");
            }
        }
    }
}
