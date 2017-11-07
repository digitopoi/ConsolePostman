using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsolePostman
{
    public class UtilityMethods
    {
        public static void Start()
        {
            Console.WriteLine("================================");
            Console.WriteLine("   Welcome to Console Postman   ");
            Console.WriteLine("================================");

            HttpClient client = new HttpClient();

            Console.WriteLine("\n");

            //  Testing: https://api.coindesk.com/v1/bpi/currentprice.json
            Console.Write("Enter the url: ");
            string Url = Console.ReadLine();
            Console.Write("Http method type: ");
            Console.ReadLine();
            Console.WriteLine("\n");
            Console.WriteLine("Choose an option: ");
            Console.WriteLine("  [1]  Print to file");
            Console.WriteLine("  [2]  Read to console");
            Console.WriteLine("\n");
            Console.ReadLine();

            client.BaseAddress = new Uri(Url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            GetAPI(client).Wait();
        }

        public static async Task GetAPI(HttpClient client)
        {
            using (client)
            {
                HttpResponseMessage response = await client.GetAsync(client.BaseAddress + "/");
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("==========================================================================="); ;
                    Console.WriteLine($"GET request sent to: {client.BaseAddress}");
                    Console.WriteLine("==========================================================================="); ;
                    Console.WriteLine("\n");
                    Console.WriteLine($"Status Code: {response.StatusCode}");
                    Console.WriteLine(await response.Content.ReadAsStringAsync());
                    Console.WriteLine("\n");
                    Console.WriteLine("\n");
                    Console.WriteLine("\n");
                }
            }
        }
    }
}
