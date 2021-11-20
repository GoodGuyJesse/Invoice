using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice
{
    public class Invoice
    {
        private readonly decimal vat;
        /// <summary>
        /// The VAT percentage
        /// </summary>
        public decimal Vat
        {
            get { return vat; }
        }

        private string invoiceNumber;
        /// <summary>
        /// The invoice number
        /// </summary>
        public string InvoiceNumber
        {
            get { return invoiceNumber; }
            set { invoiceNumber = value; }
        }

        private DateTime? invoiceDate;
        /// <summary>
        /// The invoice date
        /// </summary>
        public DateTime? InvoiceDate
        {
            get { return invoiceDate; }
            set { invoiceDate = value; }
        }

        private List<InvoiceLine> invoiceLineList;
        /// <summary>
        /// The invoice lines of the invoice
        /// </summary>
        public List<InvoiceLine> InvoiceLineList
        {
            get { return invoiceLineList; }
            set { invoiceLineList = value; }
        }

        private Supplier objSupplier;
        /// <summary>
        /// An object of the supplier that sends the invoice
        /// </summary>
        public Supplier ObjSupplier
        {
            get { return objSupplier; }
            set { objSupplier = value; }
        }

        private Customer objCustomer;
        /// <summary>
        /// An object of the customer that is being invoiced
        /// </summary>
        public Customer ObjCustomer
        {
            get { return objCustomer; }
            set { objCustomer = value; }
        }

        /// <summary>
        /// Invoice total excluding VAT (BTW)
        /// </summary>
        public decimal TotalExcludingVat
        {
            get
            {
                decimal totalExcludingVat = 0.0m;

                foreach(InvoiceLine objInvoiceInline in invoiceLineList)
                {
                    totalExcludingVat += objInvoiceInline.SubTotal;
                }
                return totalExcludingVat;
            }
        }

        /// <summary>
        /// Invoice total including VAT (BTW)
        /// </summary>
        public decimal TotalIncludingVat
        {
            get { return TotalExcludingVat * (1 + (vat/100)); }
        }

        /// <summary>
        /// The date by which the invoice must be paid
        /// </summary>
        public DateTime ExpirationDate
        {
            get { return invoiceDate.Value.AddDays(30);}
        }

        /// <summary>
        /// Invoice print functionality for printing the invoice
        /// </summary>
        public string Print
        {
            get
            {
                string text = objSupplier.Print + "\r\n\r\n" +
                    "Factuur aan: \r\n" +
                    objCustomer.Print + "\r\n\r\n" +
                    "Datum : " + this.invoiceDate.Value.ToLongDateString() + "\r\n" +
                    "Factuurnummer: " + this.invoiceNumber + "\r\n\r\n" +
                    "Omschrijving\t\tDatum\t\tAantal\t\tprijs\t\tTotaal\r\n";

                foreach(InvoiceLine objInvoiceList in this.invoiceLineList)
                {
                    text += objInvoiceList.Print;
                }

                text += string.Format("\t\t\t\t\t\tTotaal exclusief BTW\t{0:c}\r\n", this.TotalExcludingVat) +
                string.Format("\t\t\t\t\t\tBTW {0}%\r\n", this.vat) +
                string.Format("\t\t\t\t\t\tTotaal inclusief BTW\t{0:c}\r\n", this.TotalIncludingVat);
                return text;
            }
        }

        /// <summary>
        /// Full constructor with object parameters
        /// </summary>
        /// <param name="invoiceNumber">The invoice number</param>
        /// <param name="invoiceDate">The invoice date</param>
        /// <param name="objCustomer">An object of the class Customer</param>
        public Invoice(string invoiceNumber, DateTime? invoiceDate, Customer objCustomer)
        {
            if (invoiceNumber != "" && invoiceDate != null && objCustomer != null)
            {
                this.vat = Provider.VAT;
                this.invoiceNumber = invoiceNumber;
                this.invoiceDate = invoiceDate;
                this.objSupplier = Provider.SupplierCompanyData();
                this.objCustomer = objCustomer;
                this.invoiceLineList = new List<InvoiceLine>();
            }
            else
                throw new ArgumentException("Data input error");
        }

        /// <summary>
        /// Full constructor
        /// </summary>
        /// <param name="invoiceNumber">The invoice number</param>
        /// <param name="invoiceDate">The invoice date</param>
        /// <param name="customerName">The customer name that is being invoiced</param>
        /// <param name="customerAddress">The customer address</param>
        /// <param name="customerPostalCode">The customer postalcode</param>
        /// <param name="customerCity">The customer city</param>
        public Invoice(string invoiceNumber, DateTime? invoiceDate, string customerName, 
            string customerAddress, string customerPostalCode, string customerCity)
        {
            if (invoiceNumber != "" && invoiceDate != null && customerName != "" && customerAddress != "" 
                && customerPostalCode != "" && customerCity != "")
            {
                this.objSupplier = Provider.SupplierCompanyData();

                this.objCustomer = new Customer(customerName, customerAddress, customerPostalCode, customerCity);

                this.vat = Provider.VAT;
                this.invoiceNumber = invoiceNumber;
                this.invoiceDate = invoiceDate;
                this.invoiceLineList = new List<InvoiceLine>();
            }
            else
                throw new ArgumentException("Data input error");
        }

        /// <summary>
        /// An option to add delivered items to the invoice as an invoice line
        /// </summary>
        /// <param name="objInvoiceLine">An object of the class InvoiceLine to add delivered items</param>
        public void AddInvoiceLine(InvoiceLine objInvoiceLine)
        {
            if (objInvoiceLine != null)
            {
                this.invoiceLineList.Add(objInvoiceLine);
            }
            else
                throw new ArgumentNullException();
        }

        /// <summary>
        /// An option to add delivered items to the invoice as an invoice line
        /// </summary>
        /// <param name="description">The name of the delivered item</param>
        /// <param name="date">The deliver date</param>
        /// <param name="amount">The amount of delivered items</param>
        /// <param name="price">The price of the delivered item</param>
        public void AddInvoiceLine(string description, DateTime? date, int amount, decimal price)
        {
            if (description != "" && date != null && amount > 0 && price > 0)
                this.invoiceLineList.Add(new InvoiceLine(description, date, amount, price));
            else
                throw new ArgumentException();
        }

        /// <summary>
        /// An option to remove an invoice line from the invoice
        /// </summary>
        /// <param name="objInvoiceLine">The invoice line object to remove from the invoice</param>
        /// <returns>True if the invoice line was successfully removed from the invoice, otherwise false</returns>
        public bool RemoveInvoiceLine(InvoiceLine objInvoiceLine)
        {
            return this.invoiceLineList.Remove(objInvoiceLine);
        }
    }
}
