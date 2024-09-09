namespace Bank
{
    public class Account
    {
        private static Random random = new Random();
        private static List<Account> accounts = new List<Account>();

        public int AccountNumber { get; set; }
        public string OwnerName { get; set; }
        public double Balance { get; set; }
        public const double MinimumInitialBalance = 100;


        public Account(string ownerName, double balance)
        {
            AccountNumber = random.Next(1, int.MaxValue);
            OwnerName = ownerName;
            Balance = balance;
            accounts.Add(this);
        }




        public static void ViewAccounts()
        {
            if (accounts.Count == 0)
            {
                Console.WriteLine("\nNo accounts found.");
                return;
            }

            Console.WriteLine();

            foreach (var account in accounts)
            {
                Console.WriteLine($"{account.AccountNumber}: {account.OwnerName}            ${account.Balance}");
            }
        }



        public static void CreateAccount()
        {
            string ownerName = Program.GetResponse("\nEnter the account owner's name: ");
            double initialBalance;

            while (true)
            {
                Console.Write("Enter the initial balance: ");
                string? balanceInput = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(balanceInput) || !double.TryParse(balanceInput, out initialBalance))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    continue;
                }

                if (initialBalance < Account.MinimumInitialBalance)
                {
                    Console.WriteLine($"The minimum initial balance is {Account.MinimumInitialBalance}.");
                    continue;
                }

                break;
            }

            Account account = new Account(ownerName, initialBalance);
            Console.WriteLine("\nAccount created successfully.");
            Console.WriteLine($"{account.AccountNumber}: {account.OwnerName}            ${account.Balance}");
        }




        private static Account? FindAccountByNumber(int accountNumber)
        {
            return accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
        }



        public static void Deposit()
        {
            int accountNumber;
            Account? account;

            while (true)
            {
                string accountNumberInput = Program.GetResponse("\nPlease enter the account number: ");

                if (!int.TryParse(accountNumberInput, out accountNumber))
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    continue;
                }

                account = FindAccountByNumber(accountNumber);

                if (account == null)
                {
                    Console.WriteLine("Account not found. Please try again.");
                    continue;
                }

                break;
            }

            double depositAmount;

            while (true)
            {
                string amountInput = Program.GetResponse("Enter the deposit amount: ");

                if (!double.TryParse(amountInput, out depositAmount) || depositAmount <= 0)
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    continue;
                }

                break;
            }

            account.Balance += depositAmount;

            Console.WriteLine($"\nDeposit successful.");
            Console.WriteLine($"{account.AccountNumber}: {account.OwnerName}            ${account.Balance}");
        }




        public static void Withdraw()
        {
            int accountNumber;
            Account? account;

            while (true)
            {
                string accountNumberInput = Program.GetResponse("\nPlease enter the account number: ");

                if (!int.TryParse(accountNumberInput, out accountNumber))
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    continue;
                }

                account = FindAccountByNumber(accountNumber);

                if (account == null)
                {
                    Console.WriteLine("Account not found. Please try again.");
                    continue;
                }

                break;
            }

            double withdrawAmount;

            while (true)
            {
                string amountInput = Program.GetResponse("Enter the withdraw amount: ");

                if (!double.TryParse(amountInput, out withdrawAmount) || withdrawAmount <= 0)
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    continue;
                } 

                if (withdrawAmount > account.Balance)
                {
                    Console.WriteLine("Insufficient balance. Please try again.\n");
                    continue;
                } 

                break;
            }

            account.Balance -= withdrawAmount;

            Console.WriteLine($"\nWithdraw successful.");
            Console.WriteLine($"{account.AccountNumber}: {account.OwnerName}            ${account.Balance}");
        }

    
    }
}