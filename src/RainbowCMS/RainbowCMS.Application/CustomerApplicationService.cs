using System;
using System.Collections.Generic;
using System.Linq;
using RainbowCMS.Application.DataObjects;
using RainbowCMS.Domain.Model;
using RainbowCMS.Domain.Repositories;
using RainbowCMS.Infrastructure;

namespace RainbowCMS.Application
{
    public class CustomerApplicationService
    {
        public void AddCustomer(CustomerDataObject customerObject)
        {
            IRepository<Customer> customerRepository = IoCFactory.GetObject<IRepository<Customer>>();
            Customer customer = new Customer
            {
                Name = customerObject.Name,
                Contact = customerObject.Contact,
                Email = customerObject.Email,
                ContactAddress = new Address(customerObject.ContactAddress.Country,
                    customerObject.ContactAddress.State,
                    customerObject.ContactAddress.City,
                    customerObject.ContactAddress.Street,
                    customerObject.ContactAddress.Zip),
                DeliveryAddress = new Address(customerObject.DeliveryAddress.Country,
                    customerObject.DeliveryAddress.State,
                    customerObject.DeliveryAddress.City,
                    customerObject.DeliveryAddress.Street,
                    customerObject.DeliveryAddress.Zip)
            };
            customerRepository.Save(customer);
        }

        public void UpdateCustomer(CustomerDataObject customerObject)
        {
            IRepository<Customer> customerRepository = IoCFactory.GetObject<IRepository<Customer>>();
            Customer customer = customerRepository.GetByID(customerObject.ID);
            customer.Name = customerObject.Name;
            customer.Contact = customerObject.Contact;
            customer.Email = customerObject.Email;
            customer.ContactAddress = new Address(customerObject.ContactAddress.Country,
                customerObject.ContactAddress.State,
                customerObject.ContactAddress.City,
                customerObject.ContactAddress.Street,
                customerObject.ContactAddress.Zip);
            customer.DeliveryAddress = new Address(customerObject.DeliveryAddress.Country,
                customerObject.DeliveryAddress.State,
                customerObject.DeliveryAddress.City,
                customerObject.DeliveryAddress.Street,
                customerObject.DeliveryAddress.Zip);
            customerRepository.Save(customer);
        }

        public CustomerDataObject SearchCustomerByName(string name)
        {
            IRepository<Customer> customerRepository = IoCFactory.GetObject<IRepository<Customer>>();
            IEnumerable<Customer> customers = customerRepository.GetBySpecification(customer => customer.Name == name);
            if (customers.Count() > 0)
                return CustomerDataObject.CreateFromEntity(customers.First());
            return null;
        }

        public IEnumerable<CustomerDataObject> GetAllCustomers()
        {
            IRepository<Customer> customerRepository = IoCFactory.GetObject<IRepository<Customer>>();
            List<CustomerDataObject> customerDataObjects = new List<CustomerDataObject>();
            var allCustomers = customerRepository.GetBySpecification(customer => true).ToList();
            allCustomers.ForEach(p =>
                customerDataObjects.Add(CustomerDataObject.CreateFromEntity(p)));
            return customerDataObjects;
        }

        public CustomerDataObject GetByID(Guid id)
        {
            IRepository<Customer> customerRepository = IoCFactory.GetObject<IRepository<Customer>>();
            return CustomerDataObject.CreateFromEntity(customerRepository.GetByID(id));
        }
    }
}
