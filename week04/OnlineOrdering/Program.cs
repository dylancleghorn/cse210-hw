using System;

class Program
{
    static void Main(string[] args)
    {
        Order order = new Order();
        order.AddCustomer("Dylan", "Cleghorn", "1922 Vestavia CT", "Arlington", "TX", "76018", "USA");
        order.AddProduct("Thing", 111, 2.50f, 3);
        order.AddProduct("Stuff", 222, 9.75f, 2);
        order.AddProduct("Dumaflache", 333, 1234.56f, 1);

        order.GeneratePackingLabel();
        order.GenerateShippingLabel();

    }
}