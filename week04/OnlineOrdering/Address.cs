class Address
{
    private string _street;
    private string _city;

    private string _state;
    private string _zip;

    private string _country;

    public Address(string street, string city, string state, string zip, string country)
    {
        _street = street;
        _city = city;
        _state = state;
        _zip = zip;
        _country = country;
    }

    public bool IsUSA()
    {
        // the customer lives in the USA, then the shipping cost is $5. 
        // If the customer does not live in the USA, then the shipping cost is $35
        if (_country == "USA" || _country == "United States")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public string GetStreet()
    {

        return _street;
    }
    public string GetCity()
    {

        return _city;
    }
    public string GetState()
    {

        return _state;
    }
    public string GetZip()
    {

        return
        _zip;
    }
    public string GetCountry()
    {

        return _country;
    }
}