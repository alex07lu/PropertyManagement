namespace PropertyManagement.Models
{
	public class Insurance
	{
		public Company Company { get; set; }
		public string PolicyNumber { get; set; }
		public int? PropertyId { get; set; }
		public int Price { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		

	}
}
