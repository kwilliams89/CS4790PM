using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS4790PM.Models
{

    [Table("Customer")]
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Email must be 30 characters or less.")]
        [Display(Name = "Email")]
        public string EmailAddress { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "First name must be 20 characters or less.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Last name must be 20 characters or less.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Balance { get; set; }

    }

    [Table("Transaction")]
    public class Transaction
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Transaction Date")]
        public string TransDate { get; set; }

        [Required]
        [Display(Name = "Transaction Description")]
        public string TransDesc { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Transaction Amount")]
        public decimal TransAmt { get; set; }

        [Display(Name = "Customer ID")]
        public int CustID { get; set; }

    }

    public class BasicCreditDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }


    public class BasicCredit
    {
        public static CustomerTransaction getCustomerAndTransactions(int? id)
        {
            BasicCreditDbContext db = new BasicCreditDbContext();
            CustomerTransaction custTransactions = new CustomerTransaction();
            custTransactions.customer = getCustomer(id);

            var transactions = db.Transactions.Where(s => s.CustID == custTransactions.customer.Id);
            custTransactions.transactions = transactions.ToList();

            return custTransactions;
        }

        public static void deleteCustomer(Customer customer)
        {
            BasicCreditDbContext db = new BasicCreditDbContext();
            db.Entry(customer).State = EntityState.Deleted;
            db.Customers.Remove(customer);
            db.SaveChanges();
        }

        public static List<Customer> getCustomers()
        {
            BasicCreditDbContext db = new BasicCreditDbContext();
            return db.Customers.ToList();
        }

        public static Customer getCustomerDetails(int? id)
        {
            BasicCreditDbContext db = new BasicCreditDbContext();
            return db.Customers.Find(id);
        }

        public static void createCustomer(Customer customer)
        {
            BasicCreditDbContext db = new BasicCreditDbContext();
            db.Entry(customer).State = EntityState.Added;
            db.Customers.Add(customer);
            db.SaveChanges();
        }

        public static Customer getCustomer(int? id)
        {
            BasicCreditDbContext db = new BasicCreditDbContext();
            return db.Customers.Find(id);
        }

        public static void editCustomer(Customer customer)
        {
            BasicCreditDbContext db = new BasicCreditDbContext();
            db.Entry(customer).State = EntityState.Modified;
            db.SaveChanges();
        }

        public static void deleteTransaction(Transaction transaction)
        {
            BasicCreditDbContext db = new BasicCreditDbContext();
            db.Entry(transaction).State = EntityState.Deleted;
            db.Transactions.Remove(transaction);
            db.SaveChanges();
        }

        public static List<Transaction> getTransactions()
        {
            BasicCreditDbContext db = new BasicCreditDbContext();
            return db.Transactions.ToList();
        }

        public static Transaction getTransactionDetails(int? id)
        {
            BasicCreditDbContext db = new BasicCreditDbContext();
            return db.Transactions.Find(id);
        }

        public static void createTransaction(Transaction transaction)
        {
            BasicCreditDbContext db = new BasicCreditDbContext();
            db.Entry(transaction).State = EntityState.Added;
            db.Transactions.Add(transaction);
            db.SaveChanges();
        }

        public static Transaction getTransaction(int? id)
        {
            BasicCreditDbContext db = new BasicCreditDbContext();
            return db.Transactions.Find(id);
        }

        public static void editTransaction(Transaction transaction)
        {
            BasicCreditDbContext db = new BasicCreditDbContext();
            db.Entry(transaction).State = EntityState.Modified;
            db.SaveChanges();
        }


    }
}