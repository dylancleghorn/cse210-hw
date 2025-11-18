class Order
{
    private List<Product> _products = new List<Product>();
    private Customer _customer;

    private Address _address;

    public Order(Customer customer, Address address)
    {
        _customer = customer;
        _address = address;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public float TotalPrice()
    {
        //calculate the total cost of the order. 
        return 0.00f;
    }

    public string GeneratePackingLabel()
    {
        // return a string for the packing label
        return "";

    }

    public string GenerateShippingLabel()
    {
        // return a string for the shipping label
        return "";
    }
}