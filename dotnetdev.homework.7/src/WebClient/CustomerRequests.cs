using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebClient
{
    public static class CustomerRequests
    {
        static readonly HttpClient client = new HttpClient();
        public static async Task<Customer> GetCustomerByIdAsync(long id)
		{
            var response = await client.GetAsync($"https://localhost:5001/customers/{id}");
            return JsonConvert.DeserializeObject<Customer>(await response.Content.ReadAsStringAsync());
        }
        internal static async Task<Customer> CreateRundomCustomerAsync()
		{
            return new Customer { Firstname = RandomString(10), Lastname = RandomString(10)};
        }

		internal static async Task<long> AddCustomerAsync(Customer customer)
		{
            var response = await client.PostAsync($"https://localhost:5001/customers",
                new StringContent(JsonConvert.SerializeObject(customer),
                    Encoding.UTF8, "application/json"));
			if (response.StatusCode == System.Net.HttpStatusCode.OK)
			{
                return JsonConvert.DeserializeObject<long>(await response.Content.ReadAsStringAsync());
            }            
            return -1;
        }
        private static string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}