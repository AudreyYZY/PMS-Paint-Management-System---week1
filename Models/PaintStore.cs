namespace MyConsoleApp.Models;

public class PaintStore
{
    public PaintProduct[] Products { get; set; }

    public PaintStore(PaintProduct[] products)
    {
        Products = products;
    }

    public void DisplayProducts()
    {
        foreach (PaintProduct paint in Products)
        {
            paint.DisplayInfo();
            Console.WriteLine();
        }
    }
}
