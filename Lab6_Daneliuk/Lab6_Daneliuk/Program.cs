using Lab6_Daneliuk;
using System;

class Program
{
    static void CauseStackOverflow()
    {
        try
        {
            CauseStackOverflow(); // Нескінченна рекурсія
        }
        catch (StackOverflowException)
        {
            Console.WriteLine("Stack overflow detected and handled!");
        }
    }
    static void Main()
    {
       ChooseTask();
    }

    static void task1()
    {
        Test test = new Test("Math Test", new DateTime(2025, 5, 12));
        Exam exam = new Exam("Physics Exam", new DateTime(2025, 6, 15), "Physics");
        FinalExam finalExam = new FinalExam("Final Chemistry", new DateTime(2025, 7, 20), "Chemistry", true);
        Trial trial = new Trial("Sports Trial", new DateTime(2025, 8, 10), "Physical Endurance");

        test.Show();
        exam.Show();
        finalExam.Show();
        trial.Show();
    }
    static void task2_3() 
    {
        try
        {
            List<IProduct> products = new List<IProduct>
            {
                new Toy("Lego Set", 29.99m, "LEGO", "Plastic", 6),
                new Book("Harry Potter", "J.K. Rowling", 15.50m, "Bloomsbury", 10),
                new SportsEquipment("Basketball", 20.00m, "Spalding", 8),
                new Toy("Teddy Bear", 19.99m, "Hasbro", "Plush", 3),
                new Book("The Hobbit", "J.R.R. Tolkien", 18.75m, "HarperCollins", 12)
            };

            Console.WriteLine("All Products:");
            foreach (var product in products)
            {
                product.ShowInfo();
            }

            Console.Write("\nEnter product type to search (Toy, Book, SportsEquipment): ");
            string inputType = Console.ReadLine();
            Type typeToSearch = Type.GetType(inputType, false, true);

            if (typeToSearch == null)
            {
                throw new FormatException("Invalid product type entered.");
            }

            var filteredProducts = products.Where(p => p.IsOfType(typeToSearch)).ToList();

            Console.WriteLine($"\nProducts of type {inputType}:");
            foreach (var product in filteredProducts)
            {
                product.ShowInfo();
            }

            CauseStackOverflow();
        }
        catch (InvalidProductPriceException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (InvalidAgeGroupException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine($"Argument Null Error: {ex.ParamName} - {ex.Message}");
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Format Error: {ex.Message}");
        }
        catch (StackOverflowException)
        {
            Console.WriteLine("Critical error: Stack overflow detected!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected Error: {ex.Message}");
        }
    }

    static void task4()
    {
        ProductCollection collection = new ProductCollection();
        collection.Add(new Book1("Harry Potter", 15.99m, "J.K. Rowling", "Bloomsbury", 10) as Product1);
        collection.Add(new Book1("The Hobbit", 18.75m, "J.R.R. Tolkien", "HarperCollins", 12) as Product1);
        Console.WriteLine("\nProducts in collection:");
        foreach (var product in collection)
        {
            product.ShowInfo();
        }
    }


    static void ChooseTask()
    {
        Console.WriteLine("1 - task1");
        Console.WriteLine("2 - task2_3");
        Console.WriteLine("3 - task4");
        Console.WriteLine("0 - exit");
        Console.WriteLine("Choose task number: ");
        int taskNumber = Convert.ToInt32(Console.ReadLine());

        switch (taskNumber)
        {

            case 1:
                Console.WriteLine("Task #1");
                task1();
                ChooseTask();
                break;
            case 2:
                Console.WriteLine("Task #2 & #3");
                task2_3();
                ChooseTask();
                break;
            case 3:
                Console.WriteLine("Task #4");
                task4();
                ChooseTask();
                break;
            case 0:
                Console.WriteLine("Exit");
                break;
        }
    }
}
