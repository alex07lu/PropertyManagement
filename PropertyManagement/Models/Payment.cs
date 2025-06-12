namespace PropertyManagement.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public decimal RentDue { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public bool OnTime { get; set; }
        public DateTime? Date { get; set; }
        public Renter renter { get; set; }
    }
}
