using Business.Concrete;
using DataAccess.Concrete.InEntitiy;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        
        {

            ProductManager productManager = new ProductManager(new IEfProductDal());
            foreach (var product in productManager.GetUnitPrice(50,100))
            {
                Console.WriteLine(product.ProductName);

            }

        }
    }
}
