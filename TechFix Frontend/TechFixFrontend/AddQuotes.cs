using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TechFixFrontend
{
    public partial class AddQuotes : Form
    {
        List<OrderProduct> products = new List<OrderProduct>();

        public AddQuotes()
        {
            InitializeComponent();

            selectSupplier1.Items.Add("supplier1");
            selectSupplier1.Items.Add("supplier2");

            selectSupplier1.SelectedIndex = 0;
        }

        string AddProduct(string productCode, string amountText, string supplier)
        {
            if (!string.IsNullOrWhiteSpace(productCode) &&
                !string.IsNullOrWhiteSpace(amountText) &&
                !string.IsNullOrWhiteSpace(supplier) &&
                !"Product Code".Equals(productCode) &&
                !"Amount".Equals(amountText))
            {
                int amount;
                if (!int.TryParse(amountText, out amount))
                {
                    amount = 0;
                }

                products.Add(new OrderProduct { productCode = productCode, amount = amount, supplier = supplier });

                string productData = "Product Code : " + productCode + " | Amount : " + amount + " | Supplier : " + supplier;

                return productData;
            }

            return "failed";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string result = AddProduct(productcode1.Text, amount1.Text, selectSupplier1.Text);

            if ("failed".Equals(result))
            {
                MessageBox.Show("Couldn't add product.");
                return;
            }
            else
            {
                MessageBox.Show("Product Added. \n"+result);
                return;
            }
        }

        private async void submit_Click(object sender, EventArgs e)
        {
            if (products.Count == 0)
            {
                MessageBox.Show("No products to submit.");
                return;
            }

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(products);

            MessageBox.Show(json);

            var apiUrl = "https://localhost:44346/api/Supplier/RequestQuote";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Quotation request sent successfully.\n" + result);
                    }
                    else
                    {
                        MessageBox.Show($"Error requesting quotes. Status: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error requesting quotes: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Close();
        }

    }
}