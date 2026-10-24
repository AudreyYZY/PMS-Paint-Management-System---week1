namespace MyConsoleApp.Models;

public class PaintSpecification
{
    public string Color { get; set; }
    public int SizeInLiters { get; set; }

    public PaintSpecification(string col, int size)
    {
        Color = col;
        SizeInLiters = size;
    }

    public void DisplaySpecification()
    {
        Console.WriteLine($"Color is {Color}, Size is {SizeInLiters}L");
    }
}
