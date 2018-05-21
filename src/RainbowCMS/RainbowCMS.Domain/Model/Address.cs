using System;

namespace RainbowCMS.Domain.Model
{
    public class Address : IEquatable<Address>
    {
        public static readonly Address Empty = new Address(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);

        public Address() { }
        public Address(string country, string state, string city, string street, string zip)
        {
            this.Country = country;
            this.State = state;
            this.City = city;
            this.Street = street;
            this.Zip = zip;
        }

        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Zip { get; set; }

        public override int GetHashCode()
        {
            return Country.GetHashCode() ^
                State.GetHashCode() ^
                City.GetHashCode() ^
                Street.GetHashCode() ^
                Zip.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
                return true;
            if ((object)obj == (object)null)
                return false;
            Address address = obj as Address;
            if ((object)address == (object)null)
                return false;
            return this.Equals(address);
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4}", Zip,
                Street, City, State, Country);
        }

        #region IEquatable<Address> Members

        public bool Equals(Address other)
        {
            if ((object)other == (object)null)
                return false;
            return this.Country == other.Country &&
                this.State == other.State &&
                this.City == other.City &&
                this.Street == other.Street &&
                this.Zip == other.Zip;
        }

        #endregion

        public static bool operator == (Address a, Address b)
        {
            if ((object)a == (object)null)
            {
                return (object)b == (object)null;
            }
            return a.Equals((object)b);
        }

        public static bool operator != (Address a, Address b)
        {
            return !(a == b);
        }
    }
}
