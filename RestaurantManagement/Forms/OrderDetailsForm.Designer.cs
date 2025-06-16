namespace PO2_RestaurantOrderSystem.Forms
{
    partial class OrderDetailsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewOrderItems;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblTotal;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dataGridViewOrderItems = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();

            // 
            // dataGridViewOrderItems
            // 
            this.dataGridViewOrderItems.Location = new System.Drawing.Point(20, 20);
            this.dataGridViewOrderItems.Size = new System.Drawing.Size(440, 200);
            this.dataGridViewOrderItems.ReadOnly = true;
            this.dataGridViewOrderItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewOrderItems.MultiSelect = false;
            this.dataGridViewOrderItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            // 
            // btnAdd
            // 
            this.btnAdd.Text = "Dodaj pozycję";
            this.btnAdd.Location = new System.Drawing.Point(20, 230);
            this.btnAdd.Size = new System.Drawing.Size(100, 30);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // 
            // btnEdit
            // 
            this.btnEdit.Text = "Edytuj pozycję";
            this.btnEdit.Location = new System.Drawing.Point(130, 230);
            this.btnEdit.Size = new System.Drawing.Size(100, 30);
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            // 
            // btnDelete
            // 
            this.btnDelete.Text = "Usuń pozycję";
            this.btnDelete.Location = new System.Drawing.Point(240, 230);
            this.btnDelete.Size = new System.Drawing.Size(100, 30);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // 
            // btnSave
            // 
            this.btnSave.Text = "Zapisz zamówienie";
            this.btnSave.Location = new System.Drawing.Point(350, 230);
            this.btnSave.Size = new System.Drawing.Size(110, 30);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // 
            // btnCancel
            // 
            this.btnCancel.Text = "Anuluj";
            this.btnCancel.Location = new System.Drawing.Point(350, 270);
            this.btnCancel.Size = new System.Drawing.Size(110, 30);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // 
            // lblTotal
            // 
            this.lblTotal.Text = "Łącznie: 0,00 zł";
            this.lblTotal.Location = new System.Drawing.Point(20, 265);
            this.lblTotal.Size = new System.Drawing.Size(200, 23);

            // 
            // OrderDetailsForm
            // 
            this.ClientSize = new System.Drawing.Size(480, 320);
            this.Controls.Add(this.dataGridViewOrderItems);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblTotal);
            this.Text = "Szczegóły zamówienia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        }
    }
}