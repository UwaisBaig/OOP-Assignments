using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Task
{
    using System;

    class ATM
    {
        public double Balance;
        public string[] History = new string[5];
        public int count = 0;
        public ATM(double initialBalance)
        {
            Balance = initialBalance;
        }
        public void Deposit(double amount)
        {
            Balance = Balance +amount;
            if (count < 5)
            {
                History[count] ="Deposited Cash: " + amount;
                count++;
            }
        }
        public void Withdraw(double amount)
        {
            if (amount <= Balance)
            {
                Balance = Balance - amount;
                if (count < 5)
                {
                    History[count] = "Withdrew: " + amount;
                    count++;
                }
            }
            else
            {
                Console.WriteLine("Insufficient Balance!");
            }
        }
        public void CheckBalance()
        {
            Console.WriteLine("Current Balance: " + Balance);
        }
        public void ShowHistory()
        {
            Console.WriteLine("--- Transaction History ---");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(History[i]);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ATM myAtm = new ATM(1000);
            myAtm.Deposit(500);
            myAtm.Withdraw(200);            
            myAtm.CheckBalance();            
            myAtm.ShowHistory();
        }
    }
}
