namespace MyConsoleApp.Models;

public class Order
{
    public DateTime CreatedAt { get; }
    public PaintProduct[] Products { get; }
    public int[] Quantities { get; }
    public decimal TotalPrice { get; }

    public Order(PaintProduct[] products, int[] quantities)
    {
        Products = (PaintProduct[])products.Clone();
        Quantities = (int[])quantities.Clone();
        CreatedAt = DateTime.Now;
        TotalPrice = GetTotalOrderPrice();
    }

    public void DisplayOrder()
    {
        Console.WriteLine("Order Details:");
        Console.WriteLine($"Created: {CreatedAt}");

        for (int i = 0; i < Products.Length; i++)
        {
            Console.WriteLine($"Product: {Products[i].Name}");
            Console.WriteLine($"Quantity: {Quantities[i]}");
            Console.WriteLine($"Subtotal: {Products[i].GetFinalPrice() * Quantities[i]:0.00}");
        }

        Console.WriteLine($"Total Price: {TotalPrice:0.00}");
    }

    public decimal GetTotalOrderPrice()
    {
        decimal total = 0m;
        for (int i = 0; i < Products.Length; i++)
        {
            total += Products[i].GetFinalPrice() * Quantities[i];
        }
        return total;
    }
}
