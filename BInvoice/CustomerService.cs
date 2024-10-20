using BInvoice.DataModels;
using System.Net.Http.Json;

namespace BInvoice
{
    public class CustomerService
    {
        private readonly HttpClient _httpClient;

        public CustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Get all customers
        public async Task<List<Customer>> GetAllCustomers()
        {
            return await _httpClient.GetFromJsonAsync<List<Customer>>("api/customers");
        }

        // Get a customer by ID
        public async Task<Customer> GetCustomerById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Customer>($"api/customers/{id}");
        }

        // Add a new customer
        public async Task AddCustomer(Customer customer)
        {
            await _httpClient.PostAsJsonAsync("api/customers", customer);
        }

        // Update an existing customer
        public async Task UpdateCustomer(Customer customer)
        {
            await _httpClient.PutAsJsonAsync($"api/customers/{customer.CustomerId}", customer);
        }

        // Delete a customer by ID
        public async Task DeleteCustomer(int id)
        {
            await _httpClient.DeleteAsync($"api/customers/{id}");
        }
    }

}
