using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice
{
    public class Customer
    {
        /// <summary>
        /// The name of the company being invoiced
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// The address of the company being invoiced
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// The postalcode of the company being invoiced
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// The city of the company being invoiced
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// A company details print functionality for the  company that is being invoiced
        /// </summary>
        public string Print
        {
            get
            {
                return this.CompanyName + "\r\n" +
                    this.Address + "\r\n" +
                    this.PostalCode + "\r\n" +
                    this.City + "\r\n";
            }
        }

        /// <summary>
        /// Default constructor for property initialization
        /// </summary>
        public Customer()
        { }

        /// <summary>
        /// Full constructor
        /// </summary>
        /// <param name="companyName">The name of the company being invoiced</param>
        /// <param name="address">The address of the company being invoiced</param>
        /// <param name="postalCode">The postalcode of the company being invoiced</param>
        /// <param name="city">The city of the company being invoiced</param>
        public Customer(string companyName, string address, string postalCode, string city)
        {
            if (companyName != "" && address != "" && postalCode != "" && city != "")
            {
                CompanyName = companyName;
                Address = address;
                PostalCode = postalCode;
                City = city;
            }
            else
                throw new ArgumentException("Incorrect data entry for the customer");
        }
    }
}
