using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice
{
    public static class Provider
    {
        /// <summary>
        /// The tax to be paid
        /// </summary>
        public static decimal VAT
        {
            get { return 21; }
        }

        /// <summary>
        /// Company details of the supplier
        /// </summary>
        /// <returns>A string with the supplier company details</returns>
        public static Supplier SupplierCompanyData()
        {
            return new Supplier
            {
                SupplierName = "Computer Perhiperals B.V.",
                Address = "Disketteweg 5",
                PostalCode = "4594 NM",
                City = "Amersfoort",
                PhoneNumber = "0800 45045077",
                VAT_Nr = "NL002982352", 
                KVK_Nr = "11001122", 
                Bank_Nr = "NL ABN 01173479"
            };
        }
    }
}
