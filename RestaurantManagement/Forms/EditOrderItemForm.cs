using PO2_RestaurantOrderSystem.Model;
using PO2_RestaurantOrderSystem.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PO2_RestaurantOrderSystem.Forms
{
    public partial class EditOrderItemForm : Form
    {
        public OrderItem EditedOrderItem { get; private set; }
        private List<MenuItem> menuItems = new List<MenuItem>();

        public EditOrderItemForm()
        {
            InitializeComponent();
            LoadMenuItems();
            EditedOrderItem = new OrderItem();
        }

        public EditOrderItemForm(OrderItem item) : this()
        {
            int idx = menuItems.FindIndex(mi => mi.Id == item.MenuItemId);
            if (idx >= 0)
                comboBoxMenu.SelectedIndex = idx;
            txtQuantity.Text = item.Quantity.ToString();
        }

        private void LoadMenuItems()
        {
            menuItems = MenuService.GetAllMenuItems();
            comboBoxMenu.Items.Clear();
            foreach (var item in menuItems)
                comboBoxMenu.Items.Add($"{item.Name} - {item.Price:C}");
            if (comboBoxMenu.Items.Count > 0)
                comboBoxMenu.SelectedIndex = 0;
        }

        private void comboBoxMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMenu.SelectedIndex >= 0)
            {
                var menuItem = menuItems[comboBoxMenu.SelectedIndex];
                lblPrice.Text = $"Cena: {menuItem.Price:C}";
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (comboBoxMenu.SelectedIndex < 0)
            {
                MessageBox.Show("Wybierz pozycję z menu.");
                return;
            }
            if (!int.TryParse(txtQuantity.Text, out int qty) || qty <= 0)
            {
                MessageBox.Show("Podaj poprawną ilość.");
                return;
            }
            var menuItem = menuItems[comboBoxMenu.SelectedIndex];
            EditedOrderItem = new OrderItem
            {
                MenuItemId = menuItem.Id,
                MenuItemName = menuItem.Name,
                Price = menuItem.Price,
                Quantity = qty
            };
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}