using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PO2_RestaurantOrderSystem.Model;
using PO2_RestaurantOrderSystem.Services;

namespace PO2_RestaurantOrderSystem.Forms
{
    public partial class OrderDetailsForm : Form
    {
        private int tableId;
        private int orderId;
        private List<OrderItem> orderItems;

        public OrderDetailsForm(int tableId)
        {
            InitializeComponent();
            this.tableId = tableId;
            LoadOrder();
        }

        private void LoadOrder()
        {
            (orderId, orderItems) = OrderService.GetCurrentOrderWithItemsByTableId(tableId);
            if (orderItems == null)
                orderItems = new List<OrderItem>();
            RefreshGrid();
            UpdateTotal();
        }

        private void RefreshGrid()
        {
            dataGridViewOrderItems.DataSource = null;
            dataGridViewOrderItems.DataSource = orderItems;
            if (dataGridViewOrderItems.Columns["MenuItemId"] != null)
                dataGridViewOrderItems.Columns["MenuItemId"].Visible = false;
        }

        private void UpdateTotal()
        {
            decimal total = 0;
            foreach (var item in orderItems)
                total += item.Price * item.Quantity;
            lblTotal.Text = $"Łącznie: {total:C}";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new EditOrderItemForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                orderItems.Add(form.EditedOrderItem);
                RefreshGrid();
                UpdateTotal();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewOrderItems.CurrentRow == null) return;
            var item = (OrderItem)dataGridViewOrderItems.CurrentRow.DataBoundItem;
            var form = new EditOrderItemForm(item);
            if (form.ShowDialog() == DialogResult.OK)
            {
                int idx = dataGridViewOrderItems.CurrentRow.Index;
                orderItems[idx] = form.EditedOrderItem;
                RefreshGrid();
                UpdateTotal();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewOrderItems.CurrentRow == null) return;
            orderItems.RemoveAt(dataGridViewOrderItems.CurrentRow.Index);
            RefreshGrid();
            UpdateTotal();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (orderId > 0)
                OrderService.UpdateOrderItems(orderId, orderItems);
            else
                OrderService.CreateOrder(tableId, orderItems);
            MessageBox.Show("Zamówienie zapisane!");
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}