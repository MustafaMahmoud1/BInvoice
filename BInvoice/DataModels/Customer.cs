namespace BInvoice.DataModels
{
    public class Customer
    {
        public int CustomerId { get; set; }     // Unique ID for the customer
        public string Name { get; set; }        // Customer's name
        public string Code { get; set; }        // Optional: customer code or reference

        // Navigation Property for Invoices (if needed)
        public List<Invoice> Invoices { get; set; } = new List<Invoice>();
    }

}
