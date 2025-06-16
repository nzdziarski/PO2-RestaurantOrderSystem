using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PO2_RestaurantOrderSystem.Model;
using PO2_RestaurantOrderSystem.Services;

namespace PO2_RestaurantOrderSystem.Forms
{
    public partial class OrderForm : Form
    {
        private List<MenuItem> menuItems = new List<MenuItem>();
        private List<OrderItem> orderItems = new List<OrderItem>();
        private List<Table> tables = new List<Table>();

        public OrderForm()
        {
            InitializeComponent();
            LoadTables();
            LoadMenu();
        }

        private void LoadTables()
        {
            tables = TableService.GetAllTables();
            comboBoxTables.Items.Clear();
            foreach (var table in tables)
                comboBoxTables.Items.Add($"Stolik {table.Number} {(table.IsReserved ? "(zajęty)" : "")}");
            if (comboBoxTables.Items.Count > 0)
                comboBoxTables.SelectedIndex = 0;
        }

        private void LoadMenu()
        {
            menuItems = MenuService.GetAllMenuItems();
            listBoxMenu.Items.Clear();
            foreach (var item in menuItems)
                listBoxMenu.Items.Add($"{item.Name} - {item.Price:C} ({item.Category})");
        }

        private void btnAddToOrder_Click(object sender, EventArgs e)
        {
            if (listBoxMenu.SelectedIndex < 0)
            {
                MessageBox.Show("Wybierz pozycję z menu.");
                return;
            }
            if (!int.TryParse(txtQuantity.Text, out int qty) || qty <= 0)
            {
                MessageBox.Show("Podaj poprawną ilość.");
                return;
            }

            var menuItem = menuItems[listBoxMenu.SelectedIndex];
            var existing = orderItems.Find(x => x.MenuItemId == menuItem.Id);
            if (existing != null)
                existing.Quantity += qty;
            else
                orderItems.Add(new OrderItem
                {
                    MenuItemId = menuItem.Id,
                    MenuItemName = menuItem.Name,
                    Price = menuItem.Price,
                    Quantity = qty
                });

            RefreshOrderList();
        }

        private void RefreshOrderList()
        {
            listBoxOrder.Items.Clear();
            foreach (var item in orderItems)
                listBoxOrder.Items.Add($"{item.MenuItemName} x{item.Quantity} ({item.Price * item.Quantity:C})");
            UpdateTotal();
        }

        private void UpdateTotal()
        {
            decimal total = 0;
            foreach (var item in orderItems)
                total += item.Price * item.Quantity;
            lblTotal.Text = $"Łącznie: {total:C}";
        }

        private void btnRemoveFromOrder_Click(object sender, EventArgs e)
        {
            if (listBoxOrder.SelectedIndex < 0)
            {
                MessageBox.Show("Wybierz pozycję do usunięcia.");
                return;
            }
            orderItems.RemoveAt(listBoxOrder.SelectedIndex);
            RefreshOrderList();
        }

        private void btnSubmitOrder_Click(object sender, EventArgs e)
        {
            if (orderItems.Count == 0)
            {
                MessageBox.Show("Dodaj przynajmniej jedną pozycję do zamówienia.");
                return;
            }
            if (comboBoxTables.SelectedIndex < 0)
            {
                MessageBox.Show("Wybierz stolik.");
                return;
            }

            var table = tables[comboBoxTables.SelectedIndex];

            if (table.IsReserved)
            {
                MessageBox.Show("Ten stolik jest już zajęty. Wybierz inny.");
                return;
            }


            table.IsReserved = true;
            TableService.UpdateTable(table);
            OrderService.CreateOrder(table.Id, orderItems);
            MessageBox.Show("Zamówienie zostało zapisane.");
            this.Close();
        }
    }
}