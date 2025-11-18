class Product
{
    private string _name;
    private int _productId;
    private float _price;
    private int _quantitiy;

    public Product(string name, int productId, float price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantitiy = quantity;
    }

    public float CalculatePrice()
    {
        float price = _price * _quantitiy;
        return price;
    }

    public string GetName()
    {

        return $"Product Name: {_name}";
    }

    public string GetId()
    {

        return $"Product ID: {_productId}";
    }
    public string GetQuantity()
    {

        return $"Quantity: {_quantitiy}";
    }
}