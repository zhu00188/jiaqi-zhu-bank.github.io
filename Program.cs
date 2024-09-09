using Bank;

internal class Program
{
    private static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\nPlease choose an option:");
            Console.WriteLine("1 - View accounts");
            Console.WriteLine("2 - Create an account");
            Console.WriteLine("3 - Deposit");
            Console.WriteLine("4 - Withdraw");
            Console.WriteLine("5 - Exit");
            string choice = GetResponse("Enter your choice: ");

            switch (choice)
            {
                case "1":
                    Account.ViewAccounts();
                    break;
                case "2":
                    Account.CreateAccount();
                    break;
                case "3":
                    Account.Deposit();
                    break;
                case "4":
                    Account.Withdraw();
                    break;
                case "5":
                    Console.WriteLine("\nGoodbye.");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.\n");
                    break;
            }
        }
    }


    public static string GetResponse (string request) 
    {
      string? response = null;

      while (string.IsNullOrWhiteSpace(response))
      {
        Console.Write(request);
        response = Console.ReadLine();
      }

      return response;
    }

}
