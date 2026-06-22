using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace POSencillo.Modelos
{
    public class Producto
    {
        public Producto( string name, decimal price, int stock)
        {
            this.id = RandomNumberGenerator.GetInt32(100000, 999999);
            this.name = name;
            this.price = price;
            this.stock = stock;
        }

        private int id;
        private string name;
        private decimal price;
        private int stock;

        public int Id { get => id; }
        public decimal Price { get => price; set => price = value; }
        public string Name { get => name; set => name = value; }
        public int Stock { get => stock; set => stock = value; }
    }
}
