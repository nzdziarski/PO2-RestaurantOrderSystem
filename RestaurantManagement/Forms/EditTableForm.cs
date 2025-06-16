using System;
using System.Windows.Forms;
using PO2_RestaurantOrderSystem.Model;
using PO2_RestaurantOrderSystem.Services;

namespace PO2_RestaurantOrderSystem.Forms
{
    public partial class EditTableForm : Form
    {
        public Table EditedTable { get; private set; }

        public EditTableForm()
        {
            InitializeComponent();
            EditedTable = new Table();
        }

        public EditTableForm(Table table) : this()
        {
            EditedTable = new Table
            {
                Id = table.Id,
                Number = table.Number,
                IsReserved = table.IsReserved
            };
            txtNumber.Text = EditedTable.Number.ToString();
            chkReserved.Checked = EditedTable.IsReserved;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtNumber.Text, out int number) || number <= 0)
            {
                MessageBox.Show("Podaj poprawny numer stolika.");
                return;
            }

            // WALIDACJA: unikalność numeru stolika
            bool exists = TableService.TableNumberExists(number, EditedTable.Id == 0 ? null : (int?)EditedTable.Id);
            if (exists)
            {
                MessageBox.Show("Stolik o takim numerze już istnieje.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            EditedTable.Number = number;
            EditedTable.IsReserved = chkReserved.Checked;
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