using BookArchieve.Dtos;
using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookArchieve
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection("Server=ADMINISTER\\SQLEXPRESS;initial Catalog =ProductSystem;integrated security=true");

        private async void btnList_Click(object sender, EventArgs e)
        {
            string query = "Select * From TblProduct";
            var values = await connection.QueryAsync<ResultProductDto>(query);
            dataGridView1.DataSource = values;
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            string query = "insert into TblProduct (ProductName,ProductStock,ProductPrice,ProductCategory) values (@name,@stock,@price,@category)";
            var parameters = new DynamicParameters();
            parameters.Add("@name", txtProductName.Text);
            parameters.Add("@stock", txtProductStock.Text);
            parameters.Add("@price", txtProductPrice.Text);
            parameters.Add("@category", txtProductCategory.Text);

            await connection.ExecuteAsync(query, parameters);
            MessageBox.Show("Eklendi");
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            string query = "Delete From TblProduct Where ProductId=@productId";
            var parameters = new DynamicParameters();
            parameters.Add("@productId", txtProductId.Text);
            await connection.ExecuteAsync(query, parameters);

            MessageBox.Show("Silme Tamam");

        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            string query = "Update TblProduct Set ProductName=@name,ProductPrice=@price,ProductStock=@stock,ProductCategory=@category where ProductId =@id";
            var parameters = new DynamicParameters();
            parameters.Add("@name", txtProductName.Text);
            parameters.Add("@price", txtProductPrice.Text);
            parameters.Add("@stock", txtProductStock.Text);
            parameters.Add("@category", txtProductCategory.Text);
            parameters.Add("@id", txtProductId.Text);

            await connection.ExecuteAsync(query, parameters);

            MessageBox.Show("Güncellendi", "Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            string query0 = "Select Count(*) From TblProduct";
            var productTotalCount = await connection.QueryFirstOrDefaultAsync<int>(query0);
            lblTotalProductCount.Text = productTotalCount.ToString();

            string query1 = "Select ProductName From TblProduct Where ProductPrice=(Select Max(ProductPrice) From TblProduct)";
            var maxPriceProductName = await connection.QueryFirstOrDefaultAsync<string>(query1);
            lblMaxPriceProduct.Text = maxPriceProductName.ToString();

            string query2 = "Select Count(Distinct(ProductCategory)) From TblProduct";
            var distinctProductCount = await connection.QueryFirstOrDefaultAsync<int>(query2);
            lblDistinctProductCount.Text = distinctProductCount.ToString();
        }
    }
}
