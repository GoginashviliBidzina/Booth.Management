using Booth.Shared;
using System.Collections.Generic;
using Booth.Domain.BoothManagement.ValueObjects;

namespace Booth.Domain.BoothManagement
{
    public class Booth : AggregateRoot
    {
        public string Code { get; private set; }

        public Address Address { get; private set; }

        public ICollection<BoothStaff> BoothStaff { get; private set; }

        public Booth(string code,
                     Address address)
        {
            Code = code;
            Address = address;
        }

        public void ChangeDetails(string code,
                                  Address address)
        {
            Code = code;
            Address = address;
        }
    }
}
