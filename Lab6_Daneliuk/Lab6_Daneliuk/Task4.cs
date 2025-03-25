using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_Daneliuk
{
    abstract class Product1
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Product1(string name, decimal price)
        {
            Name = name;
            Price = price;
            Console.WriteLine($"{this.GetType().Name} constructor called");
        }

        public abstract void ShowInfo();
        public abstract bool IsOfType(string type);

        ~Product1()
        {
            Console.WriteLine($"{this.GetType().Name} destructor called");
        }
    }

    class Book1 : Product1
    {
        public string Author { get; set; }
        public string Publisher { get; set; }
        public int AgeGroup { get; set; }

        public Book1(string name, decimal price, string author, string publisher, int ageGroup)
            : base(name, price)
        {
            Author = author;
            Publisher = publisher;
            AgeGroup = ageGroup;
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"Book: {Name}, Price: {Price}, Author: {Author}, Publisher: {Publisher}, Age Group: {AgeGroup}+");
        }

        public override bool IsOfType(string type)
        {
            return type.ToLower() == "book";
        }
    }

    class ProductCollection : IEnumerable<Product1>
    {
        private List<Product1> products = new List<Product1>();

        public void Add(Product1 product)
        {
            products.Add(product);
        }

        public IEnumerator<Product1> GetEnumerator()
        {
            return products.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}
