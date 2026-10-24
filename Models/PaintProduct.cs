using MyConsoleApp.Enums;
using MyConsoleApp.Interfaces;

namespace MyConsoleApp.Models;

public class PaintProduct : IBuyable
{
    public readonly decimal TaxRate;
    public const decimal DefaultDiscount = 0.05m;
    public string Name { get; set; }
    public PaintType Type { get; set; }
    public PaintSpecification Specification { get; set; }
    public decimal Price { get; set; }
    public Brand Brand { get; set; }

    public PaintProduct(string name, PaintType type, PaintSpecification spec, decimal price, Brand brand)
    {
        Name = name;
        Type = type;
        Specification = spec;
        Price = price;
        TaxRate = 0.10m;
        Brand = brand;
    }

    public decimal GetFinalPrice()
    {
        decimal finalPrice = Price * (1 - DefaultDiscount) * (1 + TaxRate);
        return finalPrice;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Name : {Name}");
        Console.WriteLine($"Type : {Type}");
        Specification.DisplaySpecification();
        Console.WriteLine($"Price : {Price:0.00}");
        Console.WriteLine($"Final Price : {GetFinalPrice():0.00}");
        Console.WriteLine($"Brand: {Brand.Name}");
    }

    public decimal GetMaxDiscount(int rate, bool isOverridable)
    {
        if (isOverridable)
        {
            return Math.Max(DefaultDiscount, rate / 100m);
        }
        return DefaultDiscount;
    }
}
