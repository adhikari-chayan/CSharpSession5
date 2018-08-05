using Bank.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.UI
{
    class Program
    {
        static List<Customer> _customers = new List<Customer>();
        static List<Account> _accounts = new List<Account>();
        static Random _rand = new Random();
        static void Main(string[] args)
        {
            InitializeAccountsAndCustomers();

            Console.Write("\nBanking Options :\n");
            Console.WriteLine();
            Console.Write("1- Create New Account.\n2- Calculate Interest.\n3- Show All Accounts.\n4- Do A Deposit.\n5- Exit");
            Console.Write("\nInput your choice :");
            var opt = Convert.ToInt32(Console.ReadLine());

            switch (opt)
            {
                case 1:

                    CreateNewAccount();
                    break;

                case 2:

                    CalculateInterest();
                    break;

                case 3:

                    ShowListOfAccounts();
                    break;

                case 4:
                    DoADeposit();
                    break;

                case 5:
                    break;

                default:
                    Console.Write("Input correct option\n");
                    break;
            }

            Console.ReadLine();



            
        }

        private static void DoADeposit()
        {
            string accountNumber;
            double amountToDeposit;
            Console.Clear();
            Console.Write("Enter Account Number: ");
            accountNumber = Console.ReadLine();
            Console.Write("Enter amount to deposit: ");
            amountToDeposit = Convert.ToDouble(Console.ReadLine());
            var account = _accounts.Where(a => a.AccountNumber == accountNumber).FirstOrDefault();
            account.Deposit(amountToDeposit);
            ShowListOfAccounts();

        }

        private static void CalculateInterest()
        {
            string accountNumber;
            int nom = 0;
            Console.Clear();
            Console.Write("Enter Account Number: ");
            accountNumber = Console.ReadLine();
            Console.Write("Enter Number of Months to Calculate Interest: ");
            nom = Convert.ToInt32(Console.ReadLine());
            var account = _accounts.Where(a => a.AccountNumber == accountNumber).FirstOrDefault();
            var interest = account.CalculateInterestAmount(nom);

            Console.WriteLine("Accured Interest= {0}", interest.ToString("c"));

        }

        private static void CreateNewAccount()
        {

            Console.Clear();
            string customerType;
           
            IndividualCustomer inCustomer;
            CompanyCustomer compCustomer;
            
            
            do
            {
                Console.Write("Enter Customer Type(Individual/Company): ");
                customerType = Console.ReadLine();
            }
            while (!String.Equals(customerType, "Individual") && !String.Equals(customerType, "Company"));
            if(String.Equals(customerType,"Individual"))
            {
                Console.Write("Enter First Name: ");
                var firstName = Console.ReadLine();
                Console.Write("Enter Last Name: ");
                var lastName = Console.ReadLine();

                int customerId = (_customers.OrderByDescending(c => c.CustomerId).FirstOrDefault().CustomerId) + 1;
                inCustomer = new IndividualCustomer
                {
                    CustomerId = customerId, FirstName = firstName, LastName = lastName
                };

                _customers.Add(inCustomer);
                CreateAccount(inCustomer);
                
            }
            else
            {
                Console.Write("Enter Company Name");
                var companyName = Console.ReadLine();
                int customerId = (_customers.OrderByDescending(c => c.CustomerId).FirstOrDefault().CustomerId) + 1;

                compCustomer = new CompanyCustomer { CustomerId = customerId, CompanyName = companyName };
                _customers.Add(compCustomer);
                CreateAccount(compCustomer);
            }


            ShowListOfAccounts();

        }

        private static void CreateAccount(Customer customer)
        {
            string accountType;
            double startingBalance;
            string accountNumber = "ABC0000";
            do
            {
                Console.Write("Enter Account Type(Mortgage/Loan/Deposit): ");
                accountType = Console.ReadLine();
            }
            while (!String.Equals(accountType, "Mortgage") && !String.Equals(accountType, "Loan") && !String.Equals(accountType, "Deposit"));

            Console.Write("Enter Starting Balance: ");
            startingBalance = Convert.ToDouble(Console.ReadLine());
            accountNumber = accountNumber + _rand.Next(5, 10);
            if (String.Equals(accountType, "Mortgage"))
            {
                var mortgageAccount = new MortgageAccount(customer, startingBalance, accountNumber);
                _accounts.Add(mortgageAccount);
            }
            else if (String.Equals(accountType, "Loan"))
            {
                var loanAccount = new LoanAccount(customer, startingBalance, accountNumber);
                _accounts.Add(loanAccount);
            }
            else
            {
                var depoAccount = new DepositAccount(customer, startingBalance, accountNumber);
                _accounts.Add(depoAccount);
            }
        }

        private static void ShowListOfAccounts()
        {
            ConsoleTable ct = new ConsoleTable();
            ct.TextAlignment = ConsoleTable.AlignText.ALIGN_LEFT;

            ct.SetHeaders(new string[] { "Account Number","CustomerId" ,"Customer Name","Customer Type", "Balance" ,"Account Type"});
            
            foreach (var account in _accounts)
            {

                ct.AddRow(new List<string> { account.AccountNumber, account.Customer.CustomerId.ToString(), account.Customer.GetName(), account.Customer.GetCustomerType(),account.Balance.ToString("c"),account.GetAccountType() });

            }

            ct.PrintTable();
            
        }

        private static void InitializeAccountsAndCustomers()
        {
            var cust1 = new IndividualCustomer
            {
                CustomerId = 1,
                FirstName = "Tyrion",
                LastName = "Lannister"
            };
            _customers.Add(cust1);
            var cust2 = new IndividualCustomer
            {
                CustomerId = 2,
                FirstName = "Jon",
                LastName = "Snow"
            };
            _customers.Add(cust2);
            var cust3 = new CompanyCustomer
            {
                CustomerId = 3,
                CompanyName="Faceless Men"
            };
            _customers.Add(cust3);

            var acc1 = new DepositAccount(cust1, 20000, "ABC00001");
            _accounts.Add(acc1);
            var acc2 = new DepositAccount(cust2, 25000, "ABC00002");
            _accounts.Add(acc2);
            var acc3 = new MortgageAccount(cust2, 35000, "ABC00003");
            _accounts.Add(acc3);

            var acc4 = new LoanAccount(cust3, 500000, "ABC00004");
            _accounts.Add(acc4);
        }
    }
    class ConsoleTable
    {
        /// <summary>
        /// This will hold the header of the table.
        /// </summary>
        private string[] header;

        /// <summary>
        /// This will hold the rows (lines) in the table, not including the
        /// header. I'm using a List of lists because it's easier to deal with...
        /// </summary>
        private List<List<string>> rows;

        /// <summary>
        /// This is the default element (character/string) that will be put
        /// in the table when user adds invalid data, example:
        ///     ConsoleTable ct = new ConsoleTable();
        ///     ct.AddRow(new List<string> { null, "bla", "bla" });
        /// That null will be replaced with "DefaultElement", also, empty
        /// strings will be replaced with this value.
        /// </summary>
        private const string DefaultElement = "X";

        public enum AlignText
        {
            ALIGN_RIGHT,
            ALIGN_LEFT,
        }

        public ConsoleTable()
        {
            header = null;
            rows = new List<List<string>>();
            TextAlignment = AlignText.ALIGN_LEFT;
        }

        /// <summary>
        /// Set text alignment in table cells, either RIGHT or LEFT.
        /// </summary>
        public AlignText TextAlignment
        {
            get;
            set;
        }

        public void SetHeaders(string[] h)
        {
            header = h;
        }

        public void AddRow(List<string> row)
        {
            rows.Add(row);
        }

        private void AppendLine(StringBuilder hsb, int length)
        {
            // " " length is 1
            // "rn" length is 2
            // +1 length because I want the output to be prettier
            // Hence the length - 4 ...
            hsb.Append(" ");
            hsb.Append(new string('-', length - 4));
            hsb.Append("\r\n");
        }

        /// <summary>
        /// This function returns the maximum possible length of an
        /// individual row (line). Of course that if we use table header,
        /// the maximum length of an individual row should equal the
        /// length of the header.
        /// </summary>
        private int GetMaxRowLength()
        {
            if (header != null)
                return header.Length;
            else
            {
                int maxlen = rows[0].Count;
                for (int i = 1; i < rows.Count; i++)
                    if (rows[i].Count > maxlen)
                        maxlen = rows[i].Count;

                return maxlen;
            }
        }

        private void PutDefaultElementAndRemoveExtra()
        {
            int maxlen = GetMaxRowLength();

            for (int i = 0; i < rows.Count; i++)
            {
                // If we find a line that is smaller than the biggest line,
                // we'll add DefaultElement at the end of that line. In the end
                // the line will be as big as the biggest line.
                if (rows[i].Count < maxlen)
                {
                    int loops = maxlen - rows[i].Count;
                    for (int k = 0; k < loops; k++)
                        rows[i].Add(DefaultElement);
                }
                else if (rows[i].Count > maxlen)
                {
                    // This will apply only when header != null, and we try to
                    // add a line bigger than the header line. Remove the elements
                    // of the line, from right to left, until the line is equal
                    // with the header line.
                    rows[i].RemoveRange(maxlen, rows[i].Count - maxlen);
                }

                // Find bad data, loop through all table elements.
                for (int j = 0; j < rows[i].Count; j++)
                {
                    if (rows[i][j] == null)
                        rows[i][j] = DefaultElement;
                    else if (rows[i][j] == "")
                        rows[i][j] = DefaultElement;
                }
            }
        }

        /// <summary>
        /// This function will return an array of integers, an element at
        /// position 'i' will return the maximum length from column 'i'
        /// of the table (if we look at the table as a matrix).
        /// </summary>
        private int[] GetWidths()
        {
            int[] widths = null;
            if (header != null)
            {
                // Initially we assume that the maximum length from column 'i'
                // is exactly the length of the header from column 'i'.
                widths = new int[header.Length];
                for (int i = 0; i < header.Length; i++)
                    widths[i] = header[i].ToString().Length;
            }
            else
            {
                int count = GetMaxRowLength();
                widths = new int[count];
                for (int i = 0; i < count; i++)
                    widths[i] = -1;
            }

            foreach (List<string> s in rows)
            {
                for (int i = 0; i < s.Count; i++)
                {
                    s[i] = s[i].Trim();
                    if (s[i].Length > widths[i])
                        widths[i] = s[i].Length;
                }
            }

            return widths;
        }

        /// <summary>
        /// Returns a valid format that is to be passed to AppendFormat
        /// member function of StringBuilder.
        /// General form: "|{i, +/-widths[i]}|", where 0 <= i <= widths.Length - 1
        /// and widths[i] represents the maximum width from column 'i'.
        /// </summary>
        /// <param name="widths">The array of widths presented above.</param>
        private string BuildRowFormat(int[] widths)
        {
            string rowFormat = String.Empty;
            for (int i = 0; i < widths.Length; i++)
            {
                if (TextAlignment == AlignText.ALIGN_LEFT)
                    rowFormat += "|{" + i.ToString() + ",-" + (widths[i] + 2) + "}";
                else
                    rowFormat += "|{" + i.ToString() + "," + (widths[i] + 2) + "}";
            }

            rowFormat = rowFormat.Insert(rowFormat.Length, "|\r\n");
            return rowFormat;
        }

        /// <summary>
        /// Prints the table, main function.
        /// </summary>
        public void PrintTable()
        {
            if (rows.Count == 0)
            {
                Console.WriteLine("Can't create a table without any rows.");
                return;
            }
            PutDefaultElementAndRemoveExtra();

            int[] widths = GetWidths();
            string rowFormat = BuildRowFormat(widths);

            // I'm using a temporary string builder to find the total width
            // of the table, and increase BufferWidth of Console if necessary.
            StringBuilder toFindLen = new StringBuilder();
            toFindLen.AppendFormat(rowFormat, (header == null ? rows[0].ToArray() : header));
            int length = toFindLen.Length;
            if (Console.BufferWidth < length)
                Console.BufferWidth = length;

            // Print the first row, or header (if it exist), you can see that AppendLine
            // is called before/after every AppendFormat.
            StringBuilder hsb = new StringBuilder();
            AppendLine(hsb, length);
            hsb.AppendFormat(rowFormat, (header == null ? rows[0].ToArray() : header));
            AppendLine(hsb, length);

            // If header does't exist, we start from 1 because the first row
            // was already printed above.
            int idx = 0;
            if (header == null)
                idx = 1;
            for (int i = idx; i < rows.Count; i++)
            {
                hsb.AppendFormat(rowFormat, rows[i].ToArray());
                AppendLine(hsb, length);
            }

            Console.WriteLine(hsb.ToString());
        }
    }
}
