using Booth.Shared;
using System.Collections.Generic;
using Booth.Domain.ProductManagement.ValueObjects.Supplier;

namespace Booth.Domain.ProductManagement
{
    public class ProductSupplier : Entity
    {
        public string Name { get; private set; }

        public string Fax { get; private set; }

        public Phone Phone { get; private set; }

        public Address Address { get; private set; }

        public ICollection<Product> Products { get; private set; }

        public ProductSupplier(string name,
                               string fax,
                               Phone phone,
                               Address address)
        {
            Name = name;
            Fax = fax;
            Phone = phone;
            Address = address;
        }

        public void ChangeProductSupplier(string name,
                                          string fax,
                                          Phone phone,
                                          Address address)
        {
            Name = name;
            Fax = fax;
            Phone = phone;
            Address = address;
        }
    }
}
