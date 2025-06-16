using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PO2_RestaurantOrderSystem.Model;
using PO2_RestaurantOrderSystem.Services;

namespace PO2_RestaurantOrderSystem.Forms
{
    public partial class TableForm : Form
    {
        private List<Table> tables = new List<Table>();

        public TableForm()
        {
            InitializeComponent();
            LoadTables();

            listBoxTables.DoubleClick += listBoxTables_DoubleClick!;
        }

        private void LoadTables()
        {
            tables = TableService.GetAllTables();
            listBoxTables.Items.Clear();
            foreach (var table in tables)
            {
                var status = table.IsReserved ? "Zajęty" : "Wolny";
                listBoxTables.Items.Add($"Stolik {table.Number} ({status})");
            }
        }

        private void btnAddTable_Click(object sender, EventArgs e)
        {
            var addForm = new EditTableForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                TableService.AddTable(addForm.EditedTable);
                LoadTables();
            }
        }

        private void btnEditTable_Click(object sender, EventArgs e)
        {
            if (listBoxTables.SelectedIndex < 0)
            {
                MessageBox.Show("Wybierz stolik do edycji.");
                return;
            }

            var table = tables[listBoxTables.SelectedIndex];
            var editForm = new EditTableForm(table);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                bool wasReserved = table.IsReserved;
                bool isNowReserved = editForm.EditedTable.IsReserved;

                TableService.UpdateTable(editForm.EditedTable);

                if (wasReserved && !isNowReserved)
                {
                    OrderService.RemoveOrder(table.Id);
                    OrderService.RemoveOrderFromDatabase(table.Id);
                }

                LoadTables();
            }
        }

        private void btnDeleteTable_Click(object sender, EventArgs e)
        {
            if (listBoxTables.SelectedIndex < 0)
            {
                MessageBox.Show("Wybierz stolik do usunięcia.");
                return;
            }

            var table = tables[listBoxTables.SelectedIndex];
            TableService.DeleteTable(table.Id);
            OrderService.RemoveOrder(table.Id);
            OrderService.RemoveOrderFromDatabase(table.Id);
            LoadTables();
        }

        private void listBoxTables_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxTables.SelectedIndex < 0)
                return;

            
            this.listBoxTables.DoubleClick -= listBoxTables_DoubleClick!;

            var table = tables[listBoxTables.SelectedIndex];
            var orderDetailsForm = new OrderDetailsForm(table.Id);
            orderDetailsForm.FormClosed += (s, args) =>
            {
                
                this.listBoxTables.DoubleClick += listBoxTables_DoubleClick!;
            };
            orderDetailsForm.ShowDialog();
        }
    }
}