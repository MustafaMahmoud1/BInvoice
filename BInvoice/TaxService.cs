using BInvoice.DataModels;
using System.Net.Http.Json;

namespace BInvoice
{
    public class TaxService
    {
        private readonly HttpClient _httpClient;

        public TaxService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Get all taxes
        public async Task<List<Tax>> GetAllTaxes()
        {
            return await _httpClient.GetFromJsonAsync<List<Tax>>("api/taxes");
        }

        // Get a tax by ID
        public async Task<Tax> GetTaxById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Tax>($"api/taxes/{id}");
        }

        // Add a new tax
        public async Task AddTax(Tax tax)
        {
            await _httpClient.PostAsJsonAsync("api/taxes", tax);
        }

        // Update an existing tax
        public async Task UpdateTax(Tax tax)
        {
            await _httpClient.PutAsJsonAsync($"api/taxes/{tax.TaxId}", tax);
        }

        // Delete a tax by ID
        public async Task DeleteTax(int id)
        {
            await _httpClient.DeleteAsync($"api/taxes/{id}");
        }
    }

}
