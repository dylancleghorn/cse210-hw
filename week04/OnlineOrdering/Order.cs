using System.Runtime.Intrinsics.X86;

class Order
{
    private Customer _customer;
    private List<Product> _products = new List<Product>();


    public Order()
    {

    }
    public void AddCustomer(string fname, string lname, string street, string city, string state, string zip, string country)
    {
        _customer = new Customer(fname, lname);
        _customer.AddAddress(street, city, state, zip, country);
    }
    public void AddProduct(string name, int productId, float price, int quantity)
    {
        Product product = new Product(name, productId, price, quantity);
        _products.Add(product);
    }

    public float TotalPrice()
    {
        //calculate the total cost of the order. 
        //total price = sum of each product + a one-time shipping cost
        float subtotal = 0.00f;
        float shipping;
        float total;

        foreach (Product product in _products)
        {
            subtotal += product.CalculatePrice();
        }

        if (_customer.IsUSA())
        {
            shipping = 5;
        }
        else
        {
            shipping = 35;
        }

        total = subtotal + shipping;
        return total;
    }

    public void GeneratePackingLabel()
    {
        Console.WriteLine();
        Console.WriteLine("--------- PACKING LABEL ---------");
        Console.WriteLine();

        //list the name and product id of each product in the order
        foreach (Product product in _products)
        {
            Console.WriteLine(product.GetName());
            Console.WriteLine(product.GetId());
            Console.WriteLine(product.GetQuantity());
            Console.WriteLine();

        }

        Console.WriteLine("----------------------------------");

    }

    public void GenerateShippingLabel()
    {
        Console.WriteLine();
        Console.WriteLine("--------- SHIPPING LABEL ---------");
        Console.WriteLine();
        Console.WriteLine(_customer.GetName());
        Console.WriteLine(_customer.GetAddress());
        Console.WriteLine();
        Console.WriteLine("----------------------------------");



    }
}