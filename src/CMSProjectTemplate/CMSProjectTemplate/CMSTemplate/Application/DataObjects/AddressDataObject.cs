using RainbowCMS.Domain.Model;

namespace $safeprojectname$.DataObjects
{
    public class AddressDataObject
    {
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Zip { get; set; }

        public static AddressDataObject CreateFromEntity(Address address)
        {
            return new AddressDataObject
            {
                City = address.City,
                Country = address.Country,
                State = address.State,
                Street = address.Street,
                Zip = address.Zip
            };
        }
    }
}
