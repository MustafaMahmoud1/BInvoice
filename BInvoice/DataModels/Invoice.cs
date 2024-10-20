namespace BInvoice.DataModels
{
    public class Invoice
    {
        public int InvoiceId { get; set; }     // Unique ID for the invoice

        public string Code { get; set; }       // Invoice code (for referencing)

        public int CustomerId { get; set; }    // FK to the Customer
        public Customer Customer { get; set; } // Navigation property for Customer

        public DateTime DateTimeIssued { get; set; } // When the invoice was issued

        public decimal NetAmount => InvoiceLines.Sum(line => line.ItemNetAmount); // Sum of all line net amounts

        // Navigation Property for Invoice Lines
        public List<InvoiceLine> InvoiceLines { get; set; } = new List<InvoiceLine>();
    }

}
