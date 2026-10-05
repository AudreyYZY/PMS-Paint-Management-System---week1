
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
        PaintProduct[] products = {p1, p2, p3};
        PaintStore store = new PaintStore(products);
        store.DisplayProducts();
        PaintProduct[] orderProducts = {p1, p2, p3};
        int[] quantities = {10, 2, 1};

        Order o1 = new Order(orderProducts, quantities);
        o1.DisplayOrder();
        /*foreach (PaintProduct paint in products){
            paint.DisplayInfo();
            Console.WriteLine();
        }
        Order o1 = new Order(p1, 10);
        o1.DisplayOrder();*/

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

    class Brand
    {
        public string Name{get; set;}

        public Brand(string name){
            Name = name;
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
        public Brand Brand { get; set; }

        public PaintProduct(string name, PaintType type, PaintSpecification spec, decimal price, Brand brand){
            Name = name;
            Type = type;
            Specification = spec; 
            Price = price;
            TaxRate = 0.10m;
            Brand = brand;
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
            Console.WriteLine($"Brand: {Brand.Name}");
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
       /* public Order(PaintProduct paintProduct, int quantity){
            Product = paintProduct;
            Quantity = quantity;
            CreatedAt = DateTime.Now;
            TotalPrice = Product.GetFinalPrice() * Quantity;
        }*/

        public void DisplayOrder()
        {
            Console.WriteLine("Order Details:");
            Console.WriteLine($"Created: {CreatedAt}");

            for (int i = 0; i < Products.Length; i++)
            {
                Console.WriteLine($"Product: {Products[i].Name}");
                Console.WriteLine($"Quantity: {Quantities[i]}");
                Console.WriteLine(
                    $"Subtotal: {Products[i].GetFinalPrice() * Quantities[i]:0.00}");
            }

            Console.WriteLine($"Total Price: {TotalPrice:0.00}");
        }

        public decimal GetTotalOrderPrice()
        {
            decimal total = 0m;

            for (int i = 0; i < Products.Length; i++)
            {
                total += Products[i].GetFinalPrice()
                        * Quantities[i];
            }

            return total;
        }
    }

    class PaintStore
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
}
