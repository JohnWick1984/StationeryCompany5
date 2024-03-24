using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace StationeryCompany5
{
    public partial class MainWindow : Window
    {
        private StationaryDbContext db;

        public MainWindow()
        {
            InitializeComponent();
            db = new StationaryDbContext();
            LoadProducts();
        }

        private void LoadProducts()
        {
            StationeryComboBox.ItemsSource = db.Products.ToList();
        }

        private void StationeryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Product selectedProduct = (Product)StationeryComboBox.SelectedItem;
            if (selectedProduct != null)
            {
                NameTextBox.Text = selectedProduct.Product_Name;
                TypeTextBox.Text = selectedProduct.Product_Type;
                QuantityTextBox.Text = selectedProduct.Quantity.ToString();
                PriceTextBox.Text = selectedProduct.Cost_Price.ToString();
            }
        }

        private void SaveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            Product selectedProduct = (Product)StationeryComboBox.SelectedItem;
            if (selectedProduct != null)
            {
                selectedProduct.Product_Name = NameTextBox.Text;
                selectedProduct.Product_Type = TypeTextBox.Text;
                selectedProduct.Quantity = int.Parse(QuantityTextBox.Text);
                selectedProduct.Cost_Price = decimal.Parse(PriceTextBox.Text);

                db.SaveChanges();
                MessageBox.Show("Изменения сохранены.");
            }
        }
    }

    public class Product
    {
        [Key]
        public int Product_ID { get; set; }
        public string Product_Name { get; set; }
        public string Product_Type { get; set; }
        public int Quantity { get; set; }
        public decimal Cost_Price { get; set; }
    }

    public class Manager
        {
            public int ManagerId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        public class Sale
        {
            public int SaleId { get; set; }
            public int ProductId { get; set; }
            public int ManagerId { get; set; }
            public string BuyerCompanyName { get; set; }
            public int QuantitySold { get; set; }
            public decimal UnitPrice { get; set; }
            public DateTime SaleDate { get; set; }
        }

        public class StationaryDbContext : DbContext
        {
            public StationaryDbContext() : base("Data Source=EUGENE1984; Initial Catalog=StationeryCompany; Integrated Security=True;")
            {
            }

            public DbSet<Product> Products { get; set; }
            public DbSet<Manager> Managers { get; set; }
            public DbSet<Sale> Sales { get; set; }
        }
    }

