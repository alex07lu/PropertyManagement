namespace PropertyManagement.Models
{
    public class Lease
    {
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public int RentPerMonth { get; set; }
        public Renter renter { get; set; }
        public Property property { get; set; }
    }
}
