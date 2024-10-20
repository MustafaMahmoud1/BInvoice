using BInvoice.DataModels;
using System.Net.Http.Json;

namespace BInvoice
{
    public class InvoiceService
    {
        private readonly HttpClient _httpClient;

        public InvoiceService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Invoice>> GetAllInvoices()
        {
            return await _httpClient.GetFromJsonAsync<List<Invoice>>("api/invoices");
        }

        public async Task<List<Invoice>> SearchInvoices(string searchTerm)
        {
            return await _httpClient.GetFromJsonAsync<List<Invoice>>($"api/invoices/search?term={searchTerm}");
        }

        public async Task<Invoice> GetInvoiceById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Invoice>($"api/invoices/{id}");
        }

        public async Task AddInvoice(Invoice invoice)
        {
            await _httpClient.PostAsJsonAsync("api/invoices", invoice);
        }

        public async Task UpdateInvoice(Invoice invoice)
        {
            await _httpClient.PutAsJsonAsync($"api/invoices/{invoice.InvoiceId}", invoice);
        }

        public async Task DeleteInvoice(int id)
        {
            await _httpClient.DeleteAsync($"api/invoices/{id}");
        }
    }

}
