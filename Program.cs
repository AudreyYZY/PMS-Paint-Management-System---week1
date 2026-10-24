using MyConsoleApp.Enums;
using MyConsoleApp.Models;

namespace MyConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        Brand b1 = new Brand("Premium Paints");
        Brand b2 = new Brand("Taubmans");

        PaintProduct p1 = new PaintProduct("White Base", PaintType.BaseCoat, new PaintSpecification("White", 5), 100m, b1);
        PaintProduct p2 = new PaintProduct("Yellow Gloss", PaintType.Glossy, new PaintSpecification("Yellow", 8), 200m, b2);
        PaintProduct p3 = new PaintProduct("Pink Matte", PaintType.Matte, new PaintSpecification("Pink", 12), 100m, b1);

        PaintProduct[] products = { p1, p2, p3 };
        PaintStore store = new PaintStore(products);
        store.DisplayProducts();

        PaintProduct[] orderProducts = { p1, p2, p3 };
        int[] quantities = { 10, 2, 1 };

        Order o1 = new Order(orderProducts, quantities);
        o1.DisplayOrder();
    }
}
