using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2
{
      //класс для моделирования объекта «Товар»
    class Product
    {
        //«Код товара» (целое число), «Название товара» (строка), «Цена товара» (вещественное число).
        public int ProductCode { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }

    }
}
