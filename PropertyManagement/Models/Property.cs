namespace PropertyManagement.Models
{
    public class Property
    {
        public int Id { get; set; }
        public String AddressLine { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public String PostalCode { get; set; }
        public String? Information { get; set; }
    }
}
