using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice
{
    public class InvoiceLine
    {
        /// <summary>
        /// A description of the delivered item
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The deliver date of the item
        /// </summary>
        public DateTime? Date { get; set; }

        /// <summary>
        /// The number of items delivered
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// The price of the delivered item
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// The sub total
        /// </summary>
        public decimal SubTotal
        {
            get { return Amount * Price; }
        }

        /// <summary>
        /// The property prints all attributes in one line
        /// </summary>
        public string Print
        {
            get
            {
                return this.Description + "\t\t" +
                    this.Date.Value.ToShortDateString() + "\t" +
                    this.Amount + "\t\t" +
                    string.Format("{0:C}\t\t", this.Price) +
                    string.Format("{0:C}", this.SubTotal) + "\r\n";
            }
        }

        /// <summary>
        /// Default constructor for property initialization
        /// </summary>
        public InvoiceLine()
        { }

        /// <summary>
        /// Full constructor
        /// </summary>
        /// <param name="description">A description of the delivered item</param>
        /// <param name="date">The deliver date of the item</param>
        /// <param name="amount">The number of items delivered</param>
        /// <param name="price">The price of the delivered item</param>
        public InvoiceLine(string description, DateTime? date, int amount, decimal price)
        {
            if (description != "" && date != null && amount > 0 && price > 0)
            {
                Description = description;
                Date = date;
                Amount = amount;
                Price = price;
            }
            else
                throw new ArgumentException();
        }
    }
}
