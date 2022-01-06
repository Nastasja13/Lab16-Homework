using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace Lab16_Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            1. Необходимо разработать программу для записи информации о товаре в текстовый файл в формате json.
            - Разработать класс для моделирования объекта «Товар». 
                Предусмотреть члены класса «Код товара» (целое число), «Название товара» (строка), «Цена товара» (вещественное число).
            - Создать массив из 5-ти товаров, значения должны вводиться пользователем с клавиатуры.
            - Сериализовать массив в json-строку, сохранить ее программно в файл «Products.json».

            2. Необходимо разработать программу для получения информации о товаре из json-файла.
                Десериализовать файл «Products.json» из задачи 1. Определить название самого дорогого товара.
            */

            while (true)
            {
                Console.Clear();

                const int n = 5;
                Product[] products = new Product[n];

                Console.WriteLine("Введите данные новогодних товаров.");

                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine($"\nТовар номер {i + 1}");
                    Console.Write("Введите код товара: ");
                    int productCode = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Введите название товара: ");
                    string productName = Console.ReadLine();

                    Console.Write("Введите цену товара: ");
                    decimal productPrice = Convert.ToInt32(Convert.ToDecimal(Console.ReadLine()));

                    //важно каждую яч. массива проинициализировать
                    products[i] = new Product()
                    {
                        ProductCode = productCode,
                        ProductName = productName,
                        ProductPrice = productPrice
                    };
                }

                JsonSerializerOptions options = new JsonSerializerOptions()
                {
                    //чтение символов
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                    //отступы
                    WriteIndented = true
                };

                string jsonString = JsonSerializer.Serialize(products, options);

                //создание файла с сохранением в общую папку
                using (StreamWriter sw = new StreamWriter("../../../Products.json"))
                {
                    sw.WriteLine(jsonString);
                }
                                
                Console.WriteLine("\nНажмите \"Enter\", чтобы исправить введенные товары на новые.\nЕсли все введено верно, для выхода, нажмите любую другую клавишу.");
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    continue;
                }
                else
                {
                    break;
                }


            }

        }

    }
}
