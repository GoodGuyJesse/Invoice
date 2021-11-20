using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice
{
    public class Supplier
    {
        /// <summary>
        /// The name of the company sending the invoice
        /// </summary>
        public string SupplierName { get; set; }

        /// <summary>
        /// The address of the company sending the invoice
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// The postalcode of the company sending the invoice
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// The city of the company sending the invoice
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// The phone number of the company sending the invoice
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// The KVK number of the company sending the invoice
        /// </summary>
        public string KVK_Nr { get; set; }

        /// <summary>
        /// The VAT number (BTW number) of the company sending the invoice
        /// </summary>
        public string VAT_Nr { get; set; }

        /// <summary>
        /// The bank number of the company sending the invoice
        /// </summary>
        public string Bank_Nr { get; set; }

        /// <summary>
        /// A company details print functionality for the company sending the invoice
        /// </summary>
        public string Print
        {
            get
            {

                return this.SupplierName + "\r\n" +
                    this.Address + "\r\n" +
                    this.PostalCode + "\r\n" +
                    this.City + "\r\n" +
                    this.PhoneNumber + "\r\n\r\n\r\n" +
                    "KVK Nr: " + this.KVK_Nr + "\r\n" +
                    "BTW Nr: " + this.VAT_Nr + "\r\n" +
                    "Bank Nr: " + this.Bank_Nr + "\r\n";
            }
        }

        /// <summary>
        /// Default constructor for property initialization
        /// </summary>
        public Supplier()
        { }

        /// <summary>
        /// Full constructor
        /// </summary>
        /// <param name="supplierName">The name of the company sending the invoice</param>
        /// <param name="address">The address of the company sending the invoice</param>
        /// <param name="postalCode">The postalcode of the company sending the invoice</param>
        /// <param name="city">The city of the company sending the invoice</param>
        /// <param name="phoneNumber">The phone number of the company sending the invoice</param>
        /// <param name="kvk_nr">The KVK number of the company sending the invoice</param>
        /// <param name="btw_nr">The VAT (BTW) of the company sending the invoice</param>
        /// <param name="bank_nr">The bank number of the company sending the invoice</param>
        public Supplier(string supplierName, string address, string postalCode, string city, 
            string phoneNumber, string kvk_nr, string btw_nr, string bank_nr)
        {
            if (supplierName != "" && address != "" && postalCode != "" && city != "" &&
                phoneNumber != "" && kvk_nr != "" && btw_nr != "" && bank_nr != "")
            {
                SupplierName = supplierName;
                Address = address;
                PostalCode = postalCode;
                City = city;
                PhoneNumber = phoneNumber;
                KVK_Nr = kvk_nr;
                VAT_Nr = btw_nr;
                Bank_Nr = bank_nr;
            }
            else
                throw new ArgumentException("Data input erro!");   
        }
    }
}
