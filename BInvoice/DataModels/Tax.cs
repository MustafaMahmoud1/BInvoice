using BInvoice.Pages;

namespace BInvoice.DataModels
{
    public class Tax
    {
        public int TaxId { get; set; }       // Unique ID for the tax
        public string TaxName { get; set; }   // Name of the tax (e.g., VAT, Service Tax)
        public decimal Amount { get; set; }   // Amount of the tax applied on an item

        // Foreign Key (Optional if each Tax is tied to an InvoiceLine)
        public int InvoiceLineId { get; set; } // Optional: FK to associate the tax with an invoice line
        public InvoiceLine InvoiceLine { get; set; } // Navigation Property
    }

}
