namespace Assignment6;
public class Furniture
{
    public double Height { get; set; }
    public double Width { get; set; }
    public string Color { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }

    public virtual void Accept()
    {
        Console.Write("Enter height: ");
        Height = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter width: ");
        Width = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter color: ");
        Color = Console.ReadLine();

        Console.Write("Enter quantity: ");
        Quantity = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter price: ");
        Price = Convert.ToDouble(Console.ReadLine());
    }

    public virtual void Display()
    {
        Console.WriteLine($"Height: {Height}");
        Console.WriteLine($"Width: {Width}");
        Console.WriteLine($"Color: {Color}");
        Console.WriteLine($"Quantity: {Quantity}");
        Console.WriteLine($"Price: {Price}");
    }
}

public class BookShelf : Furniture
{
    public int NoOfShelfs { get; set; }

    public override void Accept()
    {
        base.Accept();

        Console.Write("Enter number of shelfs: ");
        NoOfShelfs = Convert.ToInt32(Console.ReadLine());
    }

    public override void Display()
    {
        base.Display();

        Console.WriteLine($"Number of shelves: {NoOfShelfs}");
    }
}

public class DiningTable : Furniture
{
    public int NoOfLegs { get; set; }

    public override void Accept()
    {
        base.Accept();

        Console.Write("Enter number of legs: ");
        NoOfLegs = Convert.ToInt32(Console.ReadLine());
    }

    public override void Display()
    {
        base.Display();

        Console.WriteLine($"Number of legs: {NoOfLegs}");
    }
}

public class Program
{
    public static int AddToStock(Furniture[] stock)
    {
        int count = 0;

        while (count < stock.Length)
        {
            Console.Write("Enter 'BS' for bookshelf or 'DT' for dining table: ");
            string choice = Console.ReadLine();

            Furniture furniture;

            if (choice == "BS")
            {
                furniture = new BookShelf();
            }
            else if (choice == "DT")
            {
                furniture = new DiningTable();
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
                continue;
            }

            furniture.Accept();

            stock[count] = furniture;

            count++;
        }

        return count;
    }

    public static double TotalStockValue(Furniture[] stock)
    {
        double totalValue = 0;

        foreach (Furniture furniture in stock)
        {
            totalValue += furniture.Quantity * furniture.Price;
        }

        return totalValue;
    }

    public static void ShowStockDetails(Furniture[] stock)
    {
        foreach (Furniture furniture in stock)
        {
            furniture.Display();
            Console.WriteLine();
        }
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Enter How many times you are going to select the furniture");
        int n = Convert.ToInt32(Console.ReadLine());
        Furniture[] stock = new Furniture[n];

        int count = AddToStock(stock);

        Console.WriteLine($"Total number of furniture selected are: {count}");
        Console.WriteLine($"Total stock value is : {TotalStockValue(stock)}");

        ShowStockDetails(stock);

        Console.ReadLine();
    }
}
    