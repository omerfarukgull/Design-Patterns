using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var customerManager = CustomerManager.CreateAsSingleton();
            customerManager.Save();
        }
    }
    //Bu yapıda kullanıcıya kendi başına bir nesne yaratma izni verilmez.Kullanıcı bizden sadece nesne talep edebilir.
    //Ve bizden nesne talep ettiğinde de biz ona her defasında bellekte var olan nesneyi veririz.
    //Böylece kullanıcı sadece tek bir nesne ile çalışmak zorunda kalır.
    class CustomerManager
    {
        private static CustomerManager _customerManager;
        static object _lockObject = new object();

        private CustomerManager()
        {

        }

        public static CustomerManager CreateAsSingleton()
        {
            lock (_lockObject)
            {
                if (_customerManager == null)
                {
                    _customerManager = new CustomerManager();
                }
            }
            return _customerManager;
        }

        public void Save()
        {
            Console.WriteLine("Saved!!");
        }

    }
}