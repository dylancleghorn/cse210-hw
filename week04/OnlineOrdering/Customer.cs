class Customer
{
    private string _fname;
    private string _lname;
    private Address _address;


    public Customer(string fname, string lname)
    {
        _fname = fname;
        _lname = lname;
    }

    public void AddAddress(string street, string city, string state, string zip, string country)
    {
        _address = new Address(street, city, state, zip, country);
    }

    public bool IsUSA()
    {
        return _address.IsUSA();
    }
    public string GetName()
    {
        return $"{_fname} {_lname}";
    }

    public string GetAddress()
    {
        return _address.GetAddress();
    }
}