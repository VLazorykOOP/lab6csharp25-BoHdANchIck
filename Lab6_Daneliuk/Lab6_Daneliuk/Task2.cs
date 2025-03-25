using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_Daneliuk
{
    class InvalidProductPriceException : Exception
    {
        public InvalidProductPriceException(string message) : base(message) { }
    }

    class InvalidAgeGroupException : Exception
    {
        public InvalidAgeGroupException(string message) : base(message) { }
    }

    interface IProduct : IComparable<IProduct>
    {
        string Name { get; }
        decimal Price { get; }
        void ShowInfo();
        bool IsOfType(Type type);
    }

    abstract class Product : IProduct
    {
        public string Name { get; }
        public decimal Price { get; }
        public int AgeGroup { get; }

        public Product(string name, decimal price, int ageGroup)
        {
            if (price <= 0)
                throw new InvalidProductPriceException("Price must be greater than zero.");

            if (ageGroup < 0)
                throw new InvalidAgeGroupException("Age group cannot be negative.");

            Name = name;
            Price = price;
            AgeGroup = ageGroup;
        }

        public abstract void ShowInfo();

        public bool IsOfType(Type type) => GetType() == type;

        public int CompareTo(IProduct other) => Price.CompareTo(other.Price);
    }

    class Toy : Product
    {
        public string Manufacturer { get; }
        public string Material { get; }

        public Toy(string name, decimal price, string manufacturer, string material, int ageGroup)
            : base(name, price, ageGroup)
        {
            Manufacturer = manufacturer ?? throw new ArgumentNullException(nameof(manufacturer), "Manufacturer cannot be null.");
            Material = material ?? throw new ArgumentNullException(nameof(material), "Material cannot be null.");
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"Toy: {Name}, Price: {Price} USD, Manufacturer: {Manufacturer}, Material: {Material}, Age: {AgeGroup}+");
        }
    }

    class Book : Product
    {
        public string Author { get; }
        public string Publisher { get; }

        public Book(string name, string author, decimal price, string publisher, int ageGroup)
            : base(name, price, ageGroup)
        {
            Author = author ?? throw new ArgumentNullException(nameof(author), "Author cannot be null.");
            Publisher = publisher ?? throw new ArgumentNullException(nameof(publisher), "Publisher cannot be null.");
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"Book: {Name}, Author: {Author}, Price: {Price} USD, Publisher: {Publisher}, Age: {AgeGroup}+");
        }
    }

    class SportsEquipment : Product
    {
        public string Manufacturer { get; }

        public SportsEquipment(string name, decimal price, string manufacturer, int ageGroup)
            : base(name, price, ageGroup)
        {
            Manufacturer = manufacturer ?? throw new ArgumentNullException(nameof(manufacturer), "Manufacturer cannot be null.");
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"Sports Equipment: {Name}, Price: {Price} USD, Manufacturer: {Manufacturer}, Age: {AgeGroup}+");
        }
    }
}
