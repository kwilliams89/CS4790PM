using System.Collections.Generic;


namespace CS4790PM.Models
{
    public class Repository
    {
        public static CustomerTransaction getCustomerAndTransactions(int? id)
        {
            CustomerTransaction CustomerTransaction = BasicCredit.getCustomerAndTransactions(id);
            return CustomerTransaction;
        }

        public static List<Customer> getCustomers()
        {
            return BasicCredit.getCustomers();
        }

        public static Customer getCustomerDetails(int? id)
        {
            return BasicCredit.getCustomerDetails(id);
        }

        public static void createCustomer(Customer customer)
        {
            BasicCredit.createCustomer(customer);
        }

        public static void deleteCustomer(Customer customer)
        {
            BasicCredit.deleteCustomer(customer);
        }

        public static Customer getCustomer(int? id)
        {
            return BasicCredit.getCustomer(id);
        }

        public static void editCustomer(Customer customer)
        {
            BasicCredit.editCustomer(customer);
        }

        public static List<Transaction> getTransactions()
        {
            return BasicCredit.getTransactions();
        }

        public static Transaction getTransactionDetails(int? id)
        {
            return BasicCredit.getTransactionDetails(id);
        }

        public static void createTransaction(Transaction transaction)
        {
            BasicCredit.createTransaction(transaction);
        }

        public static void deleteTransaction(Transaction transaction)
        {
            BasicCredit.deleteTransaction(transaction);
        }

        public static Transaction getTransaction(int? id)
        {
            return BasicCredit.getTransaction(id);
        }

        public static void editTransaction(Transaction transaction)
        {
            BasicCredit.editTransaction(transaction);
        }
    }

    public class CustomerTransaction
    {
        public CustomerTransaction()
        {
        }

        public Customer customer { get; set; }
        public List<Transaction> transactions { get; set; }
    }

}