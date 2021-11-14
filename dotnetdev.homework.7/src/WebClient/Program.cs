using System;
using System.Threading.Tasks;

namespace WebClient
{
    static class Program
    {
        static async Task Main()
        {
            WebApi.Program.Main(new string[] { });
			while (true)
			{
                Console.Clear();
                Console.WriteLine("Press:");
                Console.WriteLine("1 - Get Customer by id");
                Console.WriteLine("2 - Create Random Customer");
                Console.WriteLine("other - Exit");
                var key = Console.ReadKey();
                Console.Clear();
                Customer customer = null;
                long id;
                switch (key.KeyChar)
				{
                    case '1':
                        Console.Clear();
                        Console.WriteLine("Enter id :");
						try
						{
                            id = long.Parse(Console.ReadLine());
                        }
						catch (Exception)
						{
                            Console.WriteLine("Incorrect value entered");
                            break;
                        }
                        customer = await CustomerRequests.GetCustomerByIdAsync(id);
                        if (customer == null)
						{
                            Console.WriteLine("Сustomer not found");
                            break;
                        } 
                        Console.WriteLine(string.Format("Customer: Firstname - {0}, Lastname - {1}", customer.Firstname, customer.Lastname));
                        break;
                    case '2':
                        customer = await CustomerRequests.CreateRundomCustomerAsync();
                        id = await CustomerRequests.AddCustomerAsync(customer);
                        if (id > 0)
						{
                            Console.WriteLine("Сustomer added. Id = " + id);
                        }
						else
						{
                            Console.WriteLine("Сustomer already exists");
                        }						
                        break;
                    default:
                        return;
				}
                Console.WriteLine("\nEnter any key to continue");
                Console.ReadKey();
            }
        }
    }
}