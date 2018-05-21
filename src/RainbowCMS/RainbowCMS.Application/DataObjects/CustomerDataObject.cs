using System;
using RainbowCMS.Domain.Model;

namespace RainbowCMS.Application.DataObjects
{
    public class CustomerDataObject
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public AddressDataObject ContactAddress { get; set; }
        public AddressDataObject DeliveryAddress { get; set; }

        public override string ToString()
        {
            return this.Name;
        }

        public static CustomerDataObject CreateFromEntity(Customer customer)
        {
            return new CustomerDataObject
            {
                ID = customer.ID,
                Name = customer.Name,
                Contact = customer.Contact,
                Email = customer.Email,
                ContactAddress = AddressDataObject.CreateFromEntity(customer.ContactAddress),
                DeliveryAddress = AddressDataObject.CreateFromEntity(customer.DeliveryAddress)
            };
        }
    }
}
