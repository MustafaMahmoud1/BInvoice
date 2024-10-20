using BInvoice.DataModels;
using System.Net.Http.Json;

namespace BInvoice
{
    public class ItemService
    {
        private readonly HttpClient _httpClient;

        public ItemService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Item>> GetAllItems()
        {
            return await _httpClient.GetFromJsonAsync<List<Item>>("api/items");
        }

        public async Task<List<Item>> SearchItems(string searchTerm)
        {
            return await _httpClient.GetFromJsonAsync<List<Item>>($"api/items/search?term={searchTerm}");
        }

        public async Task<Item> GetItemById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Item>($"api/items/{id}");
        }

        public async Task AddItem(Item item)
        {
            await _httpClient.PostAsJsonAsync("api/items", item);
        }

        public async Task UpdateItem(Item item)
        {
            await _httpClient.PutAsJsonAsync($"api/items/{item.ItemId}", item);
        }

        public async Task DeleteItem(int id)
        {
            await _httpClient.DeleteAsync($"api/items/{id}");
        }
    }

}
