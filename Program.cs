using System.Net;

namespace SP_HW_2
{
    internal class Program
    {
        // MAIN TASK

        /*static void Main(string[] args)
        {
            Thread thread = new Thread(DownloadFileUrl);
            Console.Write("Enter URL of file: ");
            string url = Console.ReadLine();

            thread.Start(url);

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"From Main " + i);
                Thread.Sleep(100);
            }
        }

        public static void DownloadFileUrl(object obj)
        {
            string url = obj.ToString();
            string file = Path.GetFileName(url);
            using (var client = new WebClient())
            {
                client.DownloadFile(url, file);
            }
            Console.WriteLine("File was downloaded");
        }*/

        // ADDITIONAL TASK 1

        // WITH THREADING ? SLOWER
        /*static void Merge(List<int> numbers, int lowIndex, int middleIndex, int highIndex)
        {
            var left = lowIndex;
            var right = middleIndex + 1;
            var tempArray = new int[highIndex - lowIndex + 1];
            var index = 0;

            while ((left <= middleIndex) && (right <= highIndex))
            {
                if (numbers[left] < numbers[right])
                {
                    tempArray[index] = numbers[left];
                    left++;
                }
                else
                {
                    tempArray[index] = numbers[right];
                    right++;
                }

                index++;
            }

            for (var i = left; i <= middleIndex; i++)
            {
                tempArray[index] = numbers[i];
                index++;
            }

            for (var i = right; i <= highIndex; i++)
            {
                tempArray[index] = numbers[i];
                index++;
            }

            for (var i = 0; i < tempArray.Length; i++)
            {
                numbers[lowIndex + i] = tempArray[i];
            }
        }
        static void MergeSort(List<int> numbers, int lowIndex, int highIndex)
        {
            if (lowIndex < highIndex)
            {
                var middleIndex = (lowIndex + highIndex) / 2;
                Thread left = new Thread(() => MergeSort(numbers, lowIndex, middleIndex));
                Thread right = new Thread(() => MergeSort(numbers, middleIndex + 1, highIndex));

                left.Start();
                right.Start();

                left.Join();
                right.Join();


                Merge(numbers, lowIndex, middleIndex, highIndex);
            }
        }

        static void MergeSort(List<int> numbers)
        {
            MergeSort(numbers, 0, numbers.Count - 1);
        }


        // WITHOUT THREADING ? FASTER
        *//*static void Merge(List<int> numbers, int lowIndex, int middleIndex, int highIndex)
        {
            var left = lowIndex;
            var right = middleIndex + 1;
            var tempArray = new int[highIndex - lowIndex + 1];
            var index = 0;

            while ((left <= middleIndex) && (right <= highIndex))
            {
                if (numbers[left] < numbers[right])
                {
                    tempArray[index] = numbers[left];
                    left++;
                }
                else
                {
                    tempArray[index] = numbers[right];
                    right++;
                }

                index++;
            }

            for (var i = left; i <= middleIndex; i++)
            {
                tempArray[index] = numbers[i];
                index++;
            }

            for (var i = right; i <= highIndex; i++)
            {
                tempArray[index] = numbers[i];
                index++;
            }

            for (var i = 0; i < tempArray.Length; i++)
            {
                numbers[lowIndex + i] = tempArray[i];
            }
        }

        //сортировка слиянием
        static List<int> MergeSort(List<int> numbers, int lowIndex, int highIndex)
        {
            if (lowIndex < highIndex)
            {
                var middleIndex = (lowIndex + highIndex) / 2;
                MergeSort(numbers, lowIndex, middleIndex);
                MergeSort(numbers, middleIndex + 1, highIndex);
                Merge(numbers, lowIndex, middleIndex, highIndex);
            }

            return numbers;
        }

        static List<int> MergeSort(List<int> numbers)
        {
            return MergeSort(numbers, 0, numbers.Count - 1);
        }*//*

        static void Main(string[] args)
        {
            Random random = new Random();
            List<int> numbers = new List<int>();
            for (int i = 0; i < 1_000; i++)
            {
                numbers.Add(random.Next(1_000));
            }

            MergeSort(numbers);

            for(int i = 0; i < numbers.Count; i++)
            {
                Console.Write(numbers[i] + ' ');
            }
        }*/

        // ADDITIONAL TASK 2

        /*static int[] array;
        static int numOfThreads;
        static int[] sums;
        static void Main(string[] args)
        {
            array = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20];

            numOfThreads = (array.Length + 9) / 10;
            sums = new int[numOfThreads];

            Thread[] threads = new Thread[numOfThreads];

            for (int i = 0; i < numOfThreads; i++)
            {
                int start = i * 10;
                int end = Math.Min(start + 10, array.Length);
                int index = i;
                threads[i] = new Thread(() => ThreadingSum(start, end, index));
                threads[i].Start();
            }

            foreach (Thread thread in threads)
            {
                thread.Join();
            }

            int totalSum = 0;
            foreach (int sum in sums)
            {
                totalSum += sum;
            }

            Console.WriteLine("Sum: " + totalSum);
        }

        static void ThreadingSum(int start, int end, int index)
        {
            int sum = 0;
            for (int i = start; i < end; i++)
            {
                sum += array[i];
            }
            sums[index] = sum;
        }*/

        // ADDITIONAL TASK 5

        /*static void Main(string[] args)
        {
            BankAccount account = new BankAccount(14540m);

            Transaction[] transactions =
            {
                new Transaction(Transaction.TransactionType.Withdraw, 15000m, account),
                new Transaction(Transaction.TransactionType.Withdraw, 10000m, account),
                new Transaction(Transaction.TransactionType.Deposit, 5000m, account),
                new Transaction(Transaction.TransactionType.Deposit, 200m, account)
            };

            TransactionProcessor processor = new TransactionProcessor(transactions);

            processor.ProcessTransactions();

            Console.WriteLine($"All transactions is finished!");
        }
        public class BankAccount
        {
            private decimal balance;
            private readonly object locker = new object();

            public BankAccount(decimal initialBalance)
            {
                balance = initialBalance;
            }

            public decimal Balance
            {
                get
                {
                    lock (locker)
                    {
                        return balance;
                    }
                }
            }

            public void Deposit(decimal amount)
            {
                lock (locker)
                {
                    balance += amount;
                    Console.WriteLine($"Deposit: {amount}. Balance: {balance}");
                }
            }

            public void Withdraw(decimal amount)
            {
                lock (locker)
                {
                    if (amount <= balance)
                    {
                        balance -= amount;
                        Console.WriteLine($"Withdraw: {amount}. Balance: {balance}");
                    }
                    else
                    {
                        Console.WriteLine($"Withraw: Not enough costs to withdraw! Balance: {balance}");
                    }
                }
            }
        }
        public class Transaction
        {
            public TransactionType Type { get; }
            public decimal Amount { get; }
            public BankAccount Account { get; }

            public Transaction(TransactionType type, decimal amount, BankAccount account)
            {
                Type = type;
                Amount = amount;
                Account = account;
            }

            public void Process()
            {
                if (Type == TransactionType.Deposit)
                {
                    Account.Deposit(Amount);
                }
                else if (Type == TransactionType.Withdraw)
                {
                    Account.Withdraw(Amount);
                }
            }
            public enum TransactionType
            {
                Deposit,
                Withdraw
            }
        }
        public class TransactionProcessor
        {
            private readonly Transaction[] transactions;

            public TransactionProcessor(Transaction[] transactions)
            {
                this.transactions = transactions;
            }

            public void ProcessTransactions()
            {
                Thread[] threads = new Thread[transactions.Length];

                for (int i = 0; i < transactions.Length; i++)
                {
                    int index = i;
                    threads[index] = new Thread(transactions[index].Process);
                    threads[index].Start();
                }

                foreach (var thread in threads)
                {
                    thread.Join();
                }
            }
        }*/
    }
}
