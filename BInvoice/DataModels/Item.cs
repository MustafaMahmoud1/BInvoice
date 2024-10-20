namespace BInvoice.DataModels
{
    public class Item
    {
        public int ItemId { get; set; }       // Unique ID for the item
        public string Name { get; set; }      // Name of the item
        public string Code { get; set; }      // Optional: item code or SKU

        // Navigation Property for Invoice Lines
        public List<InvoiceLine> InvoiceLines { get; set; } = new List<InvoiceLine>();
    }

}
