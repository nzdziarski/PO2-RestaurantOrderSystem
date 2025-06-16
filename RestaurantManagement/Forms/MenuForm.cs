using PO2_RestaurantOrderSystem.Model;
using PO2_RestaurantOrderSystem.Services;
using PO2_RestaurantOrderSystem.Forms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PO2_RestaurantOrderSystem.Forms
{
    public partial class MenuForm : Form
    {
        private List<MenuItem> menuItems = new List<MenuItem>();

        public MenuForm()
        {
            InitializeComponent();
            LoadMenu();
        }

        private void LoadMenu()
        {
            menuItems = MenuService.GetAllMenuItems();
            listBoxMenu.Items.Clear();
            foreach (var item in menuItems)
                listBoxMenu.Items.Add($"{item.Name} - {item.Price:C} ({item.Category})");
        }

        private void btnAddMenuItem_Click(object sender, EventArgs e)
        {
            var addForm = new EditMenuItemForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                MenuService.AddMenuItem(addForm.EditedItem);
                LoadMenu();
            }
        }

        private void btnEditMenuItem_Click(object sender, EventArgs e)
        {
            if (listBoxMenu.SelectedIndex < 0)
            {
                MessageBox.Show("Wybierz pozycję do edycji.");
                return;
            }

            var item = menuItems[listBoxMenu.SelectedIndex];
            var editForm = new EditMenuItemForm(item);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                MenuService.UpdateMenuItem(editForm.EditedItem);
                LoadMenu();
            }
        }

        private void btnDeleteMenuItem_Click(object sender, EventArgs e)
        {
            if (listBoxMenu.SelectedIndex < 0)
            {
                MessageBox.Show("Wybierz pozycję do usunięcia.");
                return;
            }

            var item = menuItems[listBoxMenu.SelectedIndex];
            MenuService.DeleteMenuItem(item.Id);
            LoadMenu();
        }
    }
}