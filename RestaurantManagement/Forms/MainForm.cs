using PO2_RestaurantOrderSystem.Forms;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace RestaurantManagement.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            try
            {
                string bannerPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images", "baner.jpg");
                if (File.Exists(bannerPath))
                    pictureBoxBanner.Image = Image.FromFile(bannerPath);
                else
                    pictureBoxBanner.BackColor = Color.LightGray;
            }
            catch
            {
                pictureBoxBanner.BackColor = Color.LightGray;
            }
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            var form = new OrderForm();
            form.ShowDialog();
        }

        private void btnTables_Click(object sender, EventArgs e)
        {
            var form = new TableForm();
            form.ShowDialog();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            var form = new MenuForm();
            form.ShowDialog();
        }
    }
}