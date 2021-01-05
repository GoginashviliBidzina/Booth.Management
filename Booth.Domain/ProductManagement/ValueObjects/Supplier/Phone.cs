namespace Booth.Domain.ProductManagement.ValueObjects.Supplier
{
    public class Phone
    {
        public string PhoneNumber { get; private set; }

        public Phone(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }
    }
}
