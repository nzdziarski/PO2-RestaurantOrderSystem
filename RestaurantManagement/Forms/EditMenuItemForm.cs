using PO2_RestaurantOrderSystem.Model;
using PO2_RestaurantOrderSystem.Services;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace PO2_RestaurantOrderSystem.Forms
{
    public partial class EditMenuItemForm : Form
    {
        public MenuItem EditedItem { get; private set; }

        public EditMenuItemForm()
        {
            InitializeComponent();
            EditedItem = new MenuItem();
        }

        public EditMenuItemForm(MenuItem item) : this()
        {
            EditedItem = new MenuItem
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                Category = item.Category,
                Description = item.Description
            };
            txtName.Text = EditedItem.Name;
            txtPrice.Text = EditedItem.Price.ToString("0.00");
            txtCategory.Text = EditedItem.Category;
            txtDescription.Text = EditedItem.Description;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                MessageBox.Show("Uzupełnij nazwę i cenę.");
                return;
            }
            EditedItem.Name = txtName.Text.Trim();
            EditedItem.Category = txtCategory.Text.Trim();
            EditedItem.Description = txtDescription.Text.Trim();
            if (MenuService.MenuItemNameExists(txtName.Text.Trim(), EditedItem.Id))
            {
                MessageBox.Show("Pozycja o tej nazwie już istnieje w menu.");
                return;
            }
            if (!decimal.TryParse(txtPrice.Text, NumberStyles.Number, new CultureInfo("pl-PL"), out decimal price))
            {
                MessageBox.Show("Błędny format ceny.");
                return;
            }
            EditedItem.Price = price;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}