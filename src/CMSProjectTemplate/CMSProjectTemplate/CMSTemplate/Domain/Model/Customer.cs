using System;

namespace $safeprojectname$.Model
{
    public class Customer : IAggregateRoot
    {
        private Guid id;

        public Customer()
        {
            this.id = Guid.NewGuid();
        }

        public string Name { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public Address ContactAddress { get; set; }
        public Address DeliveryAddress { get; set; }

        public Guid ID
        {
            get { return this.id; }
            set { this.id = value; }
        }
        

        public override string ToString()
        {
            return this.Name;
        }
    }
}
