namespace Booth.Domain.ProductManagement.ValueObjects.Supplier
{
    public class Address
    {
        public string Street { get; private set; }

        public string City { get; private set; }

        public Address(string street,
                       string city)
        {
            City = city;
            Street = street;
        }
    }
}
