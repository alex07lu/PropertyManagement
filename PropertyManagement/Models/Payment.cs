namespace PropertyManagement.Models
{
    public class Payment
    {
        public DateTime DueDate { get; set; }
        public decimal RentDue { get; set; }
        public string PaymentMethod { get; set; }
        public bool OnTime { get; set; }
        public DateTime? PaymentDate { get; set; }
    }
}
