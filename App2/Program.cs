using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//работа с файлами
using System.IO;
using System.Text.Json;

namespace App2
{
    class Program
    {
        /*2. Необходимо разработать программу для получения информации о товаре из json-файла.
          Десериализовать файл «Products.json» из задачи 1. Определить название самого дорогого товара.*/
        static void Main(string[] args)
        {
            //String.Empty = ""
            string jsonString = String.Empty;
            using (StreamReader sr = new StreamReader("../../../Products.json"))
            {
                //прочитать весь файл
                jsonString = sr.ReadToEnd();
            }

            //в массив
            Product[] products = JsonSerializer.Deserialize<Product[]>(jsonString);

            Product maxProduct = products[0];
            foreach (Product pr in products)
            {
                if (pr.ProductPrice > maxProduct.ProductPrice)
                {
                    maxProduct = pr;
                }
            }
            Console.WriteLine($"Самый дорогой товар из новогоднего набора - это {maxProduct.ProductName}. \nЕго стоимость: {maxProduct.ProductPrice}.");
            Console.ReadKey();
        }
    }
}
