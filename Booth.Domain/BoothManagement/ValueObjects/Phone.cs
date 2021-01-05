namespace Booth.Domain.BoothManagement.ValueObjects
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
