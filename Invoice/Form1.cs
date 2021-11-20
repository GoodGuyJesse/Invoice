using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invoice
{
    public partial class Form1 : Form
    {
        private Invoice objInvoice;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpenInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                objInvoice = new Invoice(tbInvoiceNumber.Text, dtpInvoiceDate.Value.Date,
                    new Customer(tbName.Text, tbAddress.Text, tbPostalcode.Text, tbCity.Text));

                tbInvoice.Text = objInvoice.Print; ;   
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddInvoiceLine_Click(object sender, EventArgs e)
        {
            try
            {
                decimal price;
                int amount;

                if (decimal.TryParse(tbInvoiceLinePrice.Text, out price) && 
                    int.TryParse(tbInvoiceLineAmount.Text, out amount) && objInvoice != null)
                {
                    objInvoice.AddInvoiceLine(tbInvoiceLineDescription.Text,
                        dtpInvoiceLineDate.Value.Date, amount, price);

                    tbInvoice.Text = objInvoice.Print;

                    ClearInvoiceLineControls();
                }
                else
                    throw new ArgumentException("Input error");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearInvoiceLineControls()
        {
            tbInvoiceLineDescription.Clear();
            tbInvoiceLineAmount.Clear();
            tbInvoiceLinePrice.Clear();
            dtpInvoiceLineDate.Value = DateTime.Now.Date;
            tbInvoiceLineDescription.Focus();
        }
    }
}
