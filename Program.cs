
namespace MyConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        PaintProduct p1 = new PaintProduct("White Base", PaintType.BaseCoat, new PaintSpecification("White", 5), 100m);
        PaintProduct p2 = new PaintProduct("Yellow Gloss", PaintType.Glossy, new PaintSpecification("Yellow", 8), 200m);
        PaintProduct p3 = new PaintProduct("Pink Matte", PaintType.Matte, new PaintSpecification("Pink", 12), 100m);
        PaintProduct[] products = {p1, p2, p3};
        foreach (PaintProduct paint in products){
            paint.DisplayInfo();
            Console.WriteLine();
        }
        Order o1 = new Order(p1, 10);
        o1.DisplayOrder();

    }

    enum PaintType{BaseCoat, Glossy, Matte, SemiGloss, Gloss, WhiteOnWhite} //SemiGloss, Gloss, WhiteOnWhite

    class PaintSpecification{
        public string Color{get; set;}
        public int SizeInLiters{get; set;}

        public PaintSpecification(string col, int size){
            Color = col;
            SizeInLiters = size;
        }
        public void DisplaySpecification(){
            Console.WriteLine($"Color is {Color}, Size is {SizeInLiters}L");
        }
    }

    //IBuyable interface 
    interface IBuyable{
        decimal GetFinalPrice();
    }

    //PaintProduct 类
    class PaintProduct : IBuyable{

        public readonly decimal TaxRate;
        public const decimal DefaultDiscount = 0.05m;
        public string Name{get; set;}
        public PaintType Type{get; set;}
        public PaintSpecification Specification{get; set;}
        public decimal Price{get; set;} 

        public PaintProduct(string name, PaintType type, PaintSpecification spec, decimal price){
            Name = name;
            Type = type;
            Specification = spec; 
            Price = price;
            TaxRate = 0.10m;
        }

        public decimal GetFinalPrice(){
            decimal finalPrice = Price * (1 - DefaultDiscount) * (1 + TaxRate);
            return finalPrice;
        }

        public void DisplayInfo(){
            Console.WriteLine($"Name : {Name}" );
            Console.WriteLine($"Type : {Type}" );
            Specification.DisplaySpecification();
            Console.WriteLine($"Price : {Price:0.00}" );
            Console.WriteLine($"Final Price : {GetFinalPrice():0.00}" );
        }

        public decimal GetMaxDiscount(int rate, bool isOverridable){
            if (isOverridable){
                return Math.Max(DefaultDiscount, rate / 100m);
            }
            return DefaultDiscount;
        }
    }

    //Order 类
    class Order{
        public DateTime CreatedAt { get; }
        public PaintProduct Product { get; }
        public int Quantity { get; }
        public decimal TotalPrice { get; }

        public Order(PaintProduct paintProduct, int quantity){
            Product = paintProduct;
            Quantity = quantity;
            CreatedAt = DateTime.Now;
            TotalPrice = Product.GetFinalPrice() * Quantity;
        }

        public void DisplayOrder(){
            Console.WriteLine("Order Details: ");
            Console.WriteLine($"Created: {CreatedAt}");
            Console.WriteLine($"Product: {Product.Name}");
            Console.WriteLine($"Quantity: {Quantity}");
            Console.WriteLine($"Total Price: {TotalPrice:0.00}");
        }

        public decimal GetTotalPrice(){
            return TotalPrice;
        }
    }

}
