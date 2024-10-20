namespace BInvoice.DataModels
{
    public class InvoiceLine
    {
        public int InvoiceLineId { get; set; } // Unique ID for each invoice line

        public int ItemId { get; set; }        // FK to the Item
        public Item Item { get; set; }         // Navigation property for Item

        public int Quantity { get; set; }      // Quantity of the item sold
        public decimal AmountSold { get; set; } // Price per item sold

        public decimal Total => Quantity * AmountSold; // Calculated total (without taxes)
        public decimal ItemNetAmount => Total + Taxes.Sum(t => t.Amount); // Total + taxes

        // Navigation Property for Taxes
        public List<Tax> Taxes { get; set; } = new List<Tax>();

        // FK for Invoice
        public int InvoiceId { get; set; }     // FK to the parent Invoice
        public Invoice Invoice { get; set; }   // Navigation Property for parent Invoice
    }

}
